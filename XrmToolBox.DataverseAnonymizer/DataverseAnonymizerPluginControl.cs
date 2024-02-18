#define USE_FAKE_METADATA

using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.DataverseAnonymizer.DataSources;
using XrmToolBox.DataverseAnonymizer.Helpers;
using XrmToolBox.DataverseAnonymizer.Models;
using XrmToolBox.Extensibility;
using static XrmToolBox.DataverseAnonymizer.Models.BogusDataSetWithMethods;

namespace XrmToolBox.DataverseAnonymizer
{
    public partial class DataverseAnonymizerPluginControl : PluginControlBase
    {
        private TableDataSource tableDataSource = null;
        private BogusDataSource bogusDataSource = new BogusDataSource();
        private BindingList<AnonymizationRule> rules = new BindingList<AnonymizationRule>();
        private bool running = false;

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

        private void EditRule(AnonymizationRule rule)
        {
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

        #region Help links

        private void llBogus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/bchavez/Bogus");
        }

        private void llBypassHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://learn.microsoft.com/en-us/power-apps/developer/data-platform/bypass-custom-business-logic");
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
            runner.Done += (object sender, EventArgs e) =>
            {
                FormDisabled(false);
                running = false;
                MessageBox.Show("All data successfully processed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            try
            {
                running = true;
                runner.Run(rules.ToArray());
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex);
            }
        }

        private void FormDisabled(bool disabled)
        {
            contentPanel.Enabled = !disabled;
        }

        public void ShowStop(bool show)
        {
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
                MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}