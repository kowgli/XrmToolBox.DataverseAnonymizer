using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Services.Description;
using System.Windows;
using XrmToolBox.DataverseAnonymizer.DataSources;
using XrmToolBox.DataverseAnonymizer.Models;
using XrmToolBox.Extensibility;

namespace XrmToolBox.DataverseAnonymizer.Helpers
{
    public class DataUpdateRunner
    {
        private readonly DataverseAnonymizerPluginControl control;
        private readonly BogusDataSource bogusDataSource;
        private readonly WorkSettings settings;
        private Queue<RuleProcessing> rulesQueue;

        public DataUpdateRunner(DataverseAnonymizerPluginControl control, BogusDataSource bogusDataSource, WorkSettings settings)
        {
            this.control = control ?? throw new ArgumentNullException(nameof(control));
            this.bogusDataSource = bogusDataSource ?? throw new ArgumentNullException(nameof(bogusDataSource));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void Run(AnonymizationRule[] rules)
        {
            //Queue<AnonymizationRule> rulesQueue = new Queue<AnonymizationRule>(rules);

            RuleProcessing[] rulesGrouped = GroupRules(rules);

            rulesQueue = new Queue<RuleProcessing>(rulesGrouped);

            ProcessRuleQueue();
        }

        private RuleProcessing[] GroupRules(AnonymizationRule[] rules)
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
                        rules.Where(r => r.Table.LogicalName == logicalName).ToArray()
                    )
                );
            }

            return grouped.ToArray();
        }

        private void ProcessRuleQueue()
        {
            if (rulesQueue.Count == 0)
            {
                // TODO: Notify is done
                MessageBox.Show("Done");
                return;
            }

            RuleProcessing groupedRules = rulesQueue.Dequeue();

            control.WorkAsync(new WorkAsyncInfo()
            {
                Message = $"Getting {groupedRules.TableLogicalName} table record ID's...",
                Work = (worker, args) =>
                {
                    Guid[] ids = CrmHelper.GetAllIds(control.Service, groupedRules.TableLogicalName, groupedRules.PrimaryIdFieldLogicalName);

                    groupedRules.RecordIds = ids;

                    args.Result = groupedRules;
                },
                PostWorkCallBack = GetIdsDone
            });
        }

        private void GetIdsDone(RunWorkerCompletedEventArgs args)
        {
            control.HandleAsyncError(args);

            RuleProcessing groupedRules = (RuleProcessing) args.Result;

            control.WorkAsync(new WorkAsyncInfo()
            {
                Message = $"Creating requests for {groupedRules.TableLogicalName}...",
                Work = (worker, args) =>
                {
                    UpdateRequest[] updateRequests = CreateRequests(groupedRules);

                    List<UpdateRequest[]> batches = CreateBatches(updateRequests);

                    args.Result = batches;
                },
                PostWorkCallBack = CreateRequestsDone
            });            
        }

        private void CreateRequestsDone(RunWorkerCompletedEventArgs args)
        {
            control.HandleAsyncError(args);

            List<UpdateRequest[]> batches = (List<UpdateRequest[]>) args.Result;

            string tableName = batches?.FirstOrDefault()?.FirstOrDefault()?.Target?.LogicalName;

            control.WorkAsync(new WorkAsyncInfo()
            {
                Message = $"Anonymizing {tableName} records...",
                Work = (worker, args) =>
                {
                    foreach (UpdateRequest[] batch in batches)
                    {
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

                        if (settings.BypassPlugins)
                        {
                            executeMultipleRequest.Parameters.Add("BypassCustomPluginExecution", true);
                        }
                        if (settings.BypassFlows)
                        {
                            executeMultipleRequest.Parameters.Add("SuppressCallbackRegistrationExpanderJob", true);
                        }

                        control.Service.Execute(executeMultipleRequest);
                    }

                    args.Result = batches;
                },
                PostWorkCallBack = UpdateDataDone
            });
        }

        private void UpdateDataDone(RunWorkerCompletedEventArgs args)
        {
            control.HandleAsyncError(args);

            ProcessRuleQueue();
        }

        private UpdateRequest[] CreateRequests(RuleProcessing groupedRules)
        {
            List<UpdateRequest> updateRequests = new List<UpdateRequest>();

            Dictionary<AnonymizationRule, int> sequences = PrepareSequences(groupedRules.Rules);

            foreach (Guid id in groupedRules.RecordIds)
            {
                Entity updateRecord = new Entity(groupedRules.TableLogicalName);
                updateRecord[groupedRules.PrimaryIdFieldLogicalName] = id;

                foreach (AnonymizationRule rule in groupedRules.Rules)
                {
                    updateRecord[rule.FieldName] = GetRuleValue(rule, sequences);
                }

                UpdateRequest updateRequest = new UpdateRequest
                {
                    Target = updateRecord
                };

                if (settings.BypassPlugins)
                {
                    updateRequest.Parameters.Add("BypassCustomPluginExecution", true);
                }
                if (settings.BypassFlows)
                {
                    updateRequest.Parameters.Add("SuppressCallbackRegistrationExpanderJob", true);
                }

                updateRequests.Add(updateRequest);
            }

            return updateRequests.ToArray();
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

            throw new Exception($"Rule for {rule.TableName}\\{rule.FieldName} is not configured correctly.");
        }
    }
}
