using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XrmToolBox.DataverseAnonymizer.DataSources;
using XrmToolBox.DataverseAnonymizer.Models;
using XrmToolBox.DataverseAnonymizer.Rules;
using XrmToolBox.Extensibility;

namespace XrmToolBox.DataverseAnonymizer.Helpers
{
    public class DataUpdateRunner
    {
        private readonly DataverseAnonymizerPluginControl control;
        private readonly BogusDataSource bogusDataSource;
        private readonly WorkSettings settings;
        private Queue<RuleProcessing> rulesQueue;

        public event EventHandler OnDone;

        public DataUpdateRunner(DataverseAnonymizerPluginControl control, BogusDataSource bogusDataSource, WorkSettings settings)
        {
            this.control = control ?? throw new ArgumentNullException(nameof(control));
            this.bogusDataSource = bogusDataSource ?? throw new ArgumentNullException(nameof(bogusDataSource));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void Run(AnonymizationRule[] rules, Dictionary<string, string> fetchFilters)
        {
            try
            {
                RuleProcessing[] rulesGrouped = GroupRules(rules, fetchFilters);

                rulesQueue = new Queue<RuleProcessing>(rulesGrouped);

                ProcessRuleQueue();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            RunWorkerCompletedEventArgs args = new RunWorkerCompletedEventArgs(null, ex, true);

            control.HandleAsyncError(args);
        }

        private RuleProcessing[] GroupRules(AnonymizationRule[] rules, Dictionary<string, string> fetchFilters)
        {
            try
            {
                List<RuleProcessing> grouped = new List<RuleProcessing>();

                string[] logicalNames = (rules ?? new AnonymizationRule[0])
                                    .Select(r => r.Table.LogicalName)
                                    .Distinct()
                                    .OrderBy(t => t)
                                    .ToArray();

                foreach (string logicalName in logicalNames)
                {
                    grouped.Add(new RuleProcessing
                        (
                            logicalName,
                            rules.First(r => r.Table.LogicalName == logicalName).Table.PrimaryIdAttribute,
                            rules.Where(r => r.Table.LogicalName == logicalName).ToArray(),
                            fetchFilters.ContainsKey(logicalName) ? fetchFilters[logicalName] : null
                        )
                    );
                }

                return grouped.ToArray();
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return new RuleProcessing[0];
            }
        }

        private void ProcessRuleQueue()
        {
            if (rulesQueue.Count == 0)
            {
                OnDone?.Invoke(this, null);
                return;
            }

            try
            {
                RuleProcessing groupedRules = rulesQueue.Dequeue();

                control.WorkAsync(new WorkAsyncInfo()
                {
                    Message = $"Getting {groupedRules.TableLogicalName} table records...",
                    Work = (worker, args) =>
                    {
                        CrmRecord[] records = CrmHelper.GetAll(control.Service, groupedRules.TableLogicalName, groupedRules.PrimaryIdFieldLogicalName, groupedRules.FetchXmlFilter);

                        groupedRules.RecordIds = records.Select(r => r.Id).ToArray();

                        args.Result = groupedRules;
                    },
                    PostWorkCallBack = GetIdsDone
                });
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void GetIdsDone(RunWorkerCompletedEventArgs args)
        {
            if (control.HandleAsyncError(args)) { return; }

            try
            {
                RuleProcessing groupedRules = (RuleProcessing)args.Result;

                control.WorkAsync(new WorkAsyncInfo
                {
                    Message = $"Creating requests for {groupedRules.TableLogicalName}...",
                    Work = (worker, args) =>
                    {
                        CreateBatches(args, groupedRules);
                    },
                    PostWorkCallBack = CreateBatchesDone
                });
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void CreateBatches(DoWorkEventArgs args, RuleProcessing groupedRules)
        {
            try
            {
                UpdateRequest[] updateRequests = CreateRequests(groupedRules);

                List<UpdateRequest[]> batches = CreateBatches(updateRequests);

                args.Result = batches;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void CreateBatchesDone(RunWorkerCompletedEventArgs args)
        {
            try
            {
                if (control.HandleAsyncError(args)) { return; }

                List<UpdateRequest[]> batches = (List<UpdateRequest[]>)args.Result;

                string tableName = batches?.FirstOrDefault()?.FirstOrDefault()?.Target?.LogicalName;
                if (tableName == null)
                {
                    throw new Exception("Missing data to process.");
                }

                control.WorkAsync(new WorkAsyncInfo
                {
                    Message = $"Anonymizing {tableName}...",
                    Work = (worker, args) =>
                    {
                        UpdateData(args, batches, worker);
                    },
                    PostWorkCallBack = UpdateDataDone,
                    IsCancelable = true,
                });
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void UpdateData(DoWorkEventArgs args, List<UpdateRequest[]> batches, BackgroundWorker worker)
        {
            try
            {
                string tableName = batches.FirstOrDefault().FirstOrDefault().Target.LogicalName;
                int totalCount = batches.Sum(b => b.Length);

                int count = 0;

                control.ShowStop(true);

                control.SetWorkingMessage($"Anonymizing {tableName}. Updated 0/{totalCount}...");

                

                List<string> bypass = new List<string>();
                if (settings.BypassSync) { bypass.Add("CustomSync"); }
                if (settings.BypassAsync) { bypass.Add("CustomAsync"); }
                string bypassString = string.Join(",", bypass);
          
                bool isDataverse = IsDataverse;

                Parallel.ForEach(batches, new ParallelOptions { MaxDegreeOfParallelism = settings.Threads }, (UpdateRequest[] batch) =>
                {
                    if (worker.CancellationPending)
                    {
                        args.Cancel = true;
                        return;
                    }

                    ExecuteMultipleRequest executeMultipleRequest = new ExecuteMultipleRequest
                    {
                        Requests = new OrganizationRequestCollection(),
                        Settings = new ExecuteMultipleSettings
                        {
                            ContinueOnError = true,
                            ReturnResponses = true
                        }
                    };

                    executeMultipleRequest.Requests.AddRange(batch);

                    if (!isDataverse)
                    {
                        if (settings.BypassSync)
                        {
                            executeMultipleRequest.Parameters.Add("BypassCustomPluginExecution", true);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(bypassString))
                        {
                            executeMultipleRequest.Parameters.Add("BypassBusinessLogicExecution", bypassString);
                        }

                        if (settings.BypassFlows)
                        {
                            executeMultipleRequest.Parameters.Add("SuppressCallbackRegistrationExpanderJob", true);
                        }
                    }

                    if (control.IsDisposed) { return; }

                    if (isDataverse)
                    {
                        (control.Service as CrmServiceClient).Clone().Execute(executeMultipleRequest);
                    }
                    else
                    {
                        control.Service.Execute(executeMultipleRequest);
                    }

                    if (control.IsDisposed) { return; }

                    try
                    {
                        int progress = (int)((decimal)count / totalCount * 100);
                        Interlocked.Add(ref count, batch.Length);

                        if (control.IsDisposed) { return; }

                        string msg = $"Anonymizing {tableName}. Updated {count}/{totalCount}...";
                        control.SetWorkingMessage(msg);

                        if(settings.StoreProcessedRecordsPath != null)
                        {
                            AppendToProgressFile(batch);
                        }
                    }
                    catch { }

                });

                control.ShowStop(false);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private object progressFileLock = new object();
        private bool isFirstAppend = true;
        private void AppendToProgressFile(UpdateRequest[] batch)
        {
            StringBuilder textBlock = new StringBuilder();

            foreach (UpdateRequest request in batch)
            {
                textBlock.AppendLine(SerializationHelper.FormatRecord(request.Target));
            }
           
            lock (progressFileLock)
            {
                System.IO.File.AppendAllText(settings.StoreProcessedRecordsPath, textBlock.ToString());
            }
        }

        private void UpdateDataDone(RunWorkerCompletedEventArgs args)
        {
            if (control.HandleAsyncError(args)) { return; }

            try
            {
                if (!args.Cancelled)
                {
                    ProcessRuleQueue();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private UpdateRequest[] CreateRequests(RuleProcessing groupedRules)
        {
            try
            {
                List<UpdateRequest> updateRequests = new List<UpdateRequest>();

                Dictionary<AnonymizationRule, int> sequences = PrepareSequences(groupedRules.Rules);
                
                bool isDataverse = IsDataverse;

                List<string> bypass = new List<string>();
                if (settings.BypassSync) { bypass.Add("CustomSync"); }              
                if (settings.BypassAsync) { bypass.Add("CustomAsync"); }
                string bypassString = string.Join(",", bypass);

                foreach (Guid id in groupedRules.RecordIds)
                {
                    Entity updateRecord = new Entity(groupedRules.TableLogicalName);
                    updateRecord.Id = id;
                    updateRecord[groupedRules.PrimaryIdFieldLogicalName] = id;

                    foreach (AnonymizationRule rule in groupedRules.Rules)
                    {
                        if (rule.Field.AttributeType == AttributeTypeCode.Money)
                        {
                            updateRecord[rule.Field.LogicalName] = new Money((decimal)GetRuleValue(rule, sequences));
                        }
                        if (rule.Field.AttributeType == AttributeTypeCode.Double)
                        {
                            updateRecord[rule.Field.LogicalName] = (double)(decimal)GetRuleValue(rule, sequences);
                        }
                        else
                        {
                            updateRecord[rule.Field.LogicalName] = GetRuleValue(rule, sequences);
                        }                        
                    }

                    UpdateRequest updateRequest = new UpdateRequest
                    {
                        Target = updateRecord
                    };

                    if (!isDataverse)
                    {
                        if (settings.BypassSync)
                        {
                            updateRequest.Parameters.Add("BypassCustomPluginExecution", true);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(bypassString))
                        {
                            updateRequest.Parameters.Add("BypassBusinessLogicExecution", bypassString);
                        }

                        if (settings.BypassFlows)
                        {
                            updateRequest.Parameters.Add("SuppressCallbackRegistrationExpanderJob", true);
                        }
                    }

                    updateRequests.Add(updateRequest);
                }

                return updateRequests.ToArray();
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return new UpdateRequest[0];
            }
        }

        private List<UpdateRequest[]> CreateBatches(UpdateRequest[] updateRequests)
        {
            return Enumerable.Range(0, (int)Math.Ceiling((double)updateRequests.Length / settings.BatchSize))
                             .Select(i => updateRequests.Skip(i * settings.BatchSize).Take(settings.BatchSize).ToArray())
                             .ToList();
        }

        private Dictionary<AnonymizationRule, int> PrepareSequences(AnonymizationRule[] rules)
        {
            Dictionary<AnonymizationRule, int> sequences = new Dictionary<AnonymizationRule, int>();

            foreach (AnonymizationRule rule in rules.Where(r => r.SequenceRule != null))
            {
                sequences.Add(rule, rule.SequenceRule.SequenceStart);
            }

            return sequences;
        }

        private object GetRuleValue(AnonymizationRule rule, Dictionary<AnonymizationRule, int> sequences)
        {
            if (rule.SequenceRule != null)
            {
                int value = sequences[rule];
                sequences[rule] = value + 1;

                return rule.SequenceRule.Format.Replace("{SEQ}", value.ToString());
            }
            else if (rule.BogusRule != null)
            {
                return bogusDataSource.Generate(rule.BogusRule.Locale.Name, rule.BogusRule.BogusDataSet, rule.BogusRule.BogusMethod);
            }
            else if (rule.RandomIntRule != null)
            {
                return RandomHelper.GetRandomInt(rule.RandomIntRule.RangeStart, rule.RandomIntRule.RangeEnd);
            }
            else if (rule.RandomDecimalRule != null)
            {
                return Math.Round(RandomHelper.GetRandomDecimal(rule.RandomDecimalRule.RangeStart, rule.RandomDecimalRule.RangeEnd), rule.RandomDecimalRule.DecimalPlaces);
            }
            else if (rule.RandomDateRule != null)
            {
                return RandomHelper.GetRandomDate(rule.RandomDateRule.RangeStart, rule.RandomDateRule.RangeEnd);
            }

            throw new Exception($"Rule for {rule.TableName}\\{rule.FieldName} is not configured correctly.");
        }

        private bool IsDataverse
        {
            get
            {
                Version vOnline = new Version("9.2");
                return control.Service is CrmServiceClient serviceClient && serviceClient.ConnectedOrgVersion >= vOnline;
            }
        }
    }
}

