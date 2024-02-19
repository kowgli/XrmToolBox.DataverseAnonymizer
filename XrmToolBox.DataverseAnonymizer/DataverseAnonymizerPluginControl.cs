#define __USE_FAKE_METADATA

using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.DataverseAnonymizer.DataSources;
using XrmToolBox.DataverseAnonymizer.Helpers;
using XrmToolBox.DataverseAnonymizer.Models;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using static XrmToolBox.DataverseAnonymizer.Models.BogusDataSetWithMethods;

namespace XrmToolBox.DataverseAnonymizer
{
    public partial class DataverseAnonymizerPluginControl : PluginControlBase, IMessageBusHost, IGitHubPlugin
    {
        public string RepositoryName => "XrmToolBox.DataverseAnonymizer";
        public string UserName => "kowgli";

        private TableDataSource tableDataSource = null;
        private BogusDataSource bogusDataSource = new BogusDataSource();
        private readonly BindingList<AnonymizationRule> rules = new BindingList<AnonymizationRule>();
        private bool running = false;
        private readonly Dictionary<string, string> fetchFilters = new Dictionary<string, string>();

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        public DataverseAnonymizerPluginControl()
        {
            InitializeComponent();
        }

        #region Load

        private void DataverseAnonymizerPluginControl_Load(object sender, EventArgs e)
        {
            comboTableFormat.SelectedIndex = 0;
            comboFieldFormat.SelectedIndex = 0;

            BogusLocale[] locale = BogusLocale.Get();
            comboBogusLocale.DataSource = locale;
            comboBogusLocale.SelectedItem = locale.Where(l => l.Name == "en").FirstOrDefault();

            comboBogusDataSet.DataSource = bogusDataSource.DataSets;

            dgvRules.AutoGenerateColumns = false;
            dgvRules.DataSource = rules;

            ExecuteMethod(FillEntities);
        }

        private void FillEntities()
        {
            FormDisabled(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Loading tables...\r\nHere is a random piece of wisdom to think on while you wait:\r\n\"{QuotesDataSource.GetQuote()}\"\r\n-- Chat GPT, 2024",
                MessageWidth = 800,
                Work = (worker, args) =>
                {
#if USE_FAKE_METADATA
                    args.Result = Service.Execute(new WhoAmIRequest());
#else
                    args.Result = Service.Execute(new RetrieveAllEntitiesRequest
                    {
                        EntityFilters = EntityFilters.Attributes,
                        RetrieveAsIfPublished = false
                    });
#endif

                },
                PostWorkCallBack = (args) =>
                {
                    FormDisabled(false);

                    if (HandleAsyncError(args)) { return; }

#if USE_FAKE_METADATA
                    string json = System.IO.File.ReadAllText(@"..\..\..\Misc\crm_metadata.json");
                    TableMetadataInfo[] entitiesMetadata = Newtonsoft.Json.JsonConvert.DeserializeObject<TableMetadataInfo[]>(json);
#else
                    EntityMetadata[] entities = (args.Result as RetrieveAllEntitiesResponse).EntityMetadata;

                    if (entities == null || entities.Length == 0)
                    {
                        MessageBox.Show("Failed to retrieve entities", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    TableMetadataInfo[] entitiesMetadata = TransformMetadata(entities);
#endif

                    tableDataSource = new TableDataSource(entitiesMetadata);
                    comboTable.DataSource = tableDataSource.Entities;
                    comboField.DataSource = tableDataSource.Fields;

                    TableMetadataInfo accountMetadata = tableDataSource.Entities.Where(e => e.LogicalName == "account").FirstOrDefault();
                    if (accountMetadata != null)
                    {
                        comboTable.SelectedItem = accountMetadata;
                    }
                }
            });
        }

#if !USE_FAKE_METADATA

        private TableMetadataInfo[] TransformMetadata(EntityMetadata[] entities) => entities
                    .Where(e => e.DisplayName.UserLocalizedLabel != null)
                    .Select(e => new TableMetadataInfo
                    {
                        LogicalName = e.LogicalName,
                        DisplayName = e.DisplayName.UserLocalizedLabel.Label,
                        PrimaryIdAttribute = e.PrimaryIdAttribute,
                        Fields = e.Attributes
                                        .Where(a => a.IsValidForUpdate == true
                                                    && a.DisplayName.UserLocalizedLabel != null
                                                    &&
                                                    (
                                                        a.AttributeType == AttributeTypeCode.Memo
                                                        || a.AttributeType == AttributeTypeCode.String
                                                    // TODO: Add more supported types here in the future
                                                    )
                                        )
                                        .Select(a => new MetadataInfo
                                        {
                                            LogicalName = a.LogicalName,
                                            DisplayName = a.DisplayName.UserLocalizedLabel.Label
                                        })
                                        .ToArray()
                    })
                    .ToArray();
#endif

        #endregion

        #region Metadata filter handling

        private void tbTableFilter_TextChanged(object sender, EventArgs e)
        {
            if (tableDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)comboTable.SelectedItem;

            tableDataSource.Filter(tbTableFilter.Text);
            comboTable.DataSource = tableDataSource.Entities;

            if (selected != null && tableDataSource.Entities.Contains(selected))
            {
                comboTable.SelectedItem = selected;
            }
        }

        private void comboTableFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)comboTable.SelectedItem;

            tableDataSource.SetDisplayMode((MetadataInfo.DisplayModes)comboTableFormat.SelectedIndex);
            comboTable.DataSource = tableDataSource.Entities;

            if (selected != null && tableDataSource.Entities.Contains(selected))
            {
                comboTable.SelectedItem = selected;
            }
        }

        private void comboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTable.SelectedItem == null) { return; }

            TableMetadataInfo table = (TableMetadataInfo)comboTable.SelectedItem;

            tableDataSource.SetFieldsFromTable(table);

            tbFieldFilter.Text = "";

            comboField.DataSource = tableDataSource.Fields;

            tbSequenceFormat.Text = $"{table.DisplayName} {{SEQ}}";

            RestoreFiltersForTable();
        }

        private void tbFieldFilter_TextChanged(object sender, EventArgs e)
        {
            if (tableDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)comboField.SelectedItem;

            tableDataSource.FilterFields(tbFieldFilter.Text);
            comboField.DataSource = tableDataSource.Fields;

            if (selected != null && tableDataSource.Fields.Contains(selected))
            {
                comboField.SelectedItem = selected;
            }
        }

        private void comboFieldFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)comboField.SelectedItem;

            tableDataSource.SetFieldDisplayMode((MetadataInfo.DisplayModes)comboFieldFormat.SelectedIndex);
            comboField.DataSource = tableDataSource.Fields;

            if (selected != null && tableDataSource.Fields.Contains(selected))
            {
                comboField.SelectedItem = selected;
            }
        }

        private void bClearTableFilter_Click(object sender, EventArgs e)
        {
            tbTableFilter.Text = "";
            tbTableFilter_TextChanged(null, null);
        }

        private void bClearFieldFilter_Click(object sender, EventArgs e)
        {
            tbFieldFilter.Text = "";
            tbFieldFilter_TextChanged(null, null);
        }

        #endregion

        #region Bogus stuff

        private void comboBogusDataSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBogusMethod.DataSource = ((BogusDataSetWithMethods)comboBogusDataSet.SelectedItem).Methods;
        }

        private void comboBogusMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bBogusSample_Click(null, null);
        }

        private void bBogusSample_Click(object sender, EventArgs e)
        {
            var language = (BogusLocale)comboBogusLocale.SelectedItem;
            var bogusDs = (BogusDataSetWithMethods)comboBogusDataSet.SelectedItem;
            var method = (MethodWithFriendlyName)comboBogusMethod.SelectedItem;

            tbBogusSample.Text = bogusDataSource.Generate(language.Name, bogusDs, method);
        }

        #endregion

        #region Rule handling

        private void bSave_Click(object sender, EventArgs e)
        {
            if (comboTable.SelectedItem == null || comboField.SelectedItem == null)
            {
                MessageBox.Show("Please select a table and field first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            AnonymizationRule existingRule = rules.Where(r => r.Field == (MetadataInfo)comboField.SelectedItem).FirstOrDefault();

            if (existingRule != null)
            {
                existingRule.SequenceRule = tabcRule.SelectedTab == tpSequence ? new SequenceRule
                {
                    SequenceStart = (int)nudSequenceStartFrom.Value,
                    Format = tbSequenceFormat.Text
                }
                                                                                 : null;

                existingRule.BogusRule = tabcRule.SelectedTab == tpFakeData ? new BogusRule
                {
                    Locale = (BogusLocale)comboBogusLocale.SelectedItem,
                    BogusDataSet = (BogusDataSetWithMethods)comboBogusDataSet.SelectedItem,
                    BogusMethod = (MethodWithFriendlyName)comboBogusMethod.SelectedItem
                }
                                                                              : null;

                dgvRules.Refresh();
            }
            else
            {
                rules.Add(new AnonymizationRule
                {
                    Table = (TableMetadataInfo)comboTable.SelectedItem,
                    Field = (MetadataInfo)comboField.SelectedItem,
                    SequenceRule = tabcRule.SelectedTab == tpSequence ? new SequenceRule
                    {
                        SequenceStart = (int)nudSequenceStartFrom.Value,
                        Format = tbSequenceFormat.Text
                    }
                                                                        : null,
                    BogusRule = tabcRule.SelectedTab == tpFakeData ? new BogusRule
                    {
                        Locale = (BogusLocale)comboBogusLocale.SelectedItem,
                        BogusDataSet = (BogusDataSetWithMethods)comboBogusDataSet.SelectedItem,
                        BogusMethod = (MethodWithFriendlyName)comboBogusMethod.SelectedItem
                    }
                                                                     : null,
                });
            }


            dgvRules.AutoResizeColumns();
        }

        private void dgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            
            AnonymizationRule rule = (AnonymizationRule)dgvRules.Rows[e.RowIndex].DataBoundItem;

            if (e.ColumnIndex == colEdit.Index)
            {
                EditRule(rule);
            }
            else if (e.ColumnIndex == colDelete.Index)
            {
                rules.Remove(rule);
                dgvRules.Refresh();
            }
        }

        private void dgvRules_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRules.SelectedRows.Count == 0) { return; }
            
            AnonymizationRule rule = (AnonymizationRule)dgvRules.SelectedRows[0].DataBoundItem;

            EditRule(rule);
        }

        private void EditRule(AnonymizationRule rule)
        {
            tbTableFilter.Text = "";
            tbFieldFilter.Text = "";
            comboTable.SelectedItem = rule.Table;
            comboField.SelectedItem = rule.Field;

            if (rule.SequenceRule != null)
            {
                nudSequenceStartFrom.Value = rule.SequenceRule.SequenceStart;
                tbSequenceFormat.Text = rule.SequenceRule.Format;
                tabcRule.SelectedTab = tpSequence;
            }
            else if (rule.BogusRule != null)
            {
                comboBogusLocale.SelectedItem = rule.BogusRule.Locale;
                comboBogusDataSet.SelectedItem = rule.BogusRule.BogusDataSet;
                comboBogusMethod.SelectedItem = rule.BogusRule.BogusMethod;
                bBogusSample_Click(null, null);

                tabcRule.SelectedTab = tpFakeData;
            }
        }

        #endregion

        #region Misc events

        private void llBogus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/bchavez/Bogus");
        }

        private void llBypassHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://learn.microsoft.com/en-us/power-apps/developer/data-platform/bypass-custom-business-logic");
        }

        private void bFeedback_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/kowgli/XrmToolBox.DataverseAnonymizer/issues/new");
        }

        #endregion

        #region Running

        private void bRun_Click(object sender, EventArgs e)
        {
            if (rules.Count == 0)
            {
                MessageBox.Show("Nothing to do. Add some fields and try again...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Anonymize the selected {rules.Count} fields?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            FormDisabled(true);

            WorkSettings settings = new WorkSettings()
            {
                BatchSize = (int)nudBatchSize.Value,
                BypassPlugins = cbBypassPlugins.Checked,
                BypassFlows = cbBypassFlows.Checked
            };

            DataUpdateRunner runner = new DataUpdateRunner(this, bogusDataSource, settings);
            runner.OnDone += (object sender, EventArgs e) =>
            {
                if (this.IsDisposed) { return; }

                FormDisabled(false);
                running = false;
                MessageBox.Show("All data successfully processed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            try
            {
                running = true;
                runner.Run(rules.ToArray(), fetchFilters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bStop_Click(null, null);
            }
        }

        private void FormDisabled(bool disabled)
        {
            contentPanel.Enabled = !disabled;
        }

        public void ShowStop(bool show)
        {
            if (this.IsDisposed) { return; }
            this.Invoke((MethodInvoker)delegate
            {
                bStop.BringToFront();
                bStop.Visible = show;
            });
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            CancelWorker();

            running = false;
            FormDisabled(false);
            ShowStop(false);

            MessageBox.Show("Stopped. The currently submitted batch will continue to run on the server. No next batch will be submitted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region XrmToolBox stuff
        public bool HandleAsyncError(RunWorkerCompletedEventArgs args)
        {
            if (args.Error != null)
            {
                MessageBox.Show(args.Error?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                running = false;
                FormDisabled(false);
                ShowStop(false);

                return true;
            }
            return false;
        }

        private void DataverseAnonymizerPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            try
            {
                CancelWorker();
            }
            catch { }
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            try
            {
                if (running)
                {
                    bStop_Click(null, null);
                }

                ShowWarningNotification("The connection has changed. The currently running job has been cancelled. Consider reopening the tool if the metadata has changed.", null);
            }
            catch { }

            base.UpdateConnection(newService, detail, actionName, parameter);
        }

        #endregion

        #region FXB integration

        private void bFetchXmlBuilder_Click(object sender, EventArgs e)
        {
            OnOutgoingMessage(this, new MessageBusEventArgs("FetchXML Builder")
            {
                TargetArgument = tbFetchXml.Text
            });
        }

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin == "FetchXML Builder" &&
                message.TargetArgument is string fetchXml &&
                !string.IsNullOrWhiteSpace(fetchXml))
            {
                tbFetchXml.Text = fetchXml;
            }
        }

        #endregion

        #region FetchXML filter handling

        private void rbFilter_CheckedChanged(object sender, EventArgs e)
        {
            tbFetchXml.Visible = rbFilterFetchXml.Checked;
            labelFetchXmlInfo.Visible = rbFilterFetchXml.Checked;
            bFetchXmlBuilder.Visible = rbFilterFetchXml.Checked;
           
            if (rbFilterNone.Checked && CurrentTable != null && fetchFilters.ContainsKey(CurrentTable))
            {
                fetchFilters.Remove(CurrentTable);
            }
        }

        private string CurrentTable => (comboTable.SelectedItem as TableMetadataInfo)?.LogicalName;        

        private void tbFetchXml_TextChanged(object sender, EventArgs e)
        {
            if (CurrentTable != null)
            {
                fetchFilters[CurrentTable] = tbFetchXml.Text;
            }
        }

        private void RestoreFiltersForTable()
        {
            if (CurrentTable != null && fetchFilters.ContainsKey(CurrentTable))
            {
                tbFetchXml.Text = fetchFilters[CurrentTable];
                rbFilterFetchXml.Checked = true;                
            }
            else
            {
                tbFetchXml.Text = "";
                rbFilterNone.Checked = true;
            }

            rbFilter_CheckedChanged(null, null);
        }


        #endregion
    }
}