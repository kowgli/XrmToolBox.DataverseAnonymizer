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

        public DataverseAnonymizerPluginControl()
        {
            InitializeComponent();
        }

        private void DataverseAnonymizerPluginControl_Load(object sender, EventArgs e)
        {
            cbTableFormat.SelectedIndex = 0;
            cbFieldFormat.SelectedIndex = 0;

            BogusLocale[] locale = BogusLocale.Get();
            cbBogusLocale.DataSource = locale;
            cbBogusLocale.SelectedItem = locale.Where(l => l.Name == "en").FirstOrDefault();

            cbBogusDataSet.DataSource = bogusDataSource.DataSets;

            dgvRules.AutoGenerateColumns = false;
            dgvRules.DataSource = rules;

            ExecuteMethod(FillEntities);
        }

        private void FillEntities()
        {
            contentPanel.Enabled = false;

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
                    contentPanel.Enabled = true;

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
                    cbTable.DataSource = tableDataSource.Entities;
                    cbField.DataSource = tableDataSource.Fields;

                    TableMetadataInfo accountMetadata = tableDataSource.Entities.Where(e => e.LogicalName == "account").FirstOrDefault();
                    if (accountMetadata != null)
                    {
                        cbTable.SelectedItem = accountMetadata;
                    }
                }
            });
        }

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


        #region Metadata filter handling

        private void tbTableFilter_TextChanged(object sender, EventArgs e)
        {
            if (tableDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)cbTable.SelectedItem;

            tableDataSource.Filter(tbTableFilter.Text);
            cbTable.DataSource = tableDataSource.Entities;

            if (selected != null && tableDataSource.Entities.Contains(selected))
            {
                cbTable.SelectedItem = selected;
            }
        }

        private void cbTableFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)cbTable.SelectedItem;

            tableDataSource.SetDisplayMode((MetadataInfo.DisplayModes)cbTableFormat.SelectedIndex);
            cbTable.DataSource = tableDataSource.Entities;

            if (selected != null && tableDataSource.Entities.Contains(selected))
            {
                cbTable.SelectedItem = selected;
            }
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTable.SelectedItem == null) { return; }

            TableMetadataInfo table = (TableMetadataInfo)cbTable.SelectedItem;

            tableDataSource.SetFieldsFromTable(table);

            cbField.DataSource = tableDataSource.Fields;

            tbSequenceFormat.Text = $"{table.DisplayName} {{SEQ}}";
        }

        private void tbFieldFilter_TextChanged(object sender, EventArgs e)
        {
            if (tableDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)cbField.SelectedItem;

            tableDataSource.FilterFields(tbFieldFilter.Text);
            cbField.DataSource = tableDataSource.Fields;

            if (selected != null && tableDataSource.Fields.Contains(selected))
            {
                cbField.SelectedItem = selected;
            }
        }

        private void cbFieldFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)cbField.SelectedItem;

            tableDataSource.SetFieldDisplayMode((MetadataInfo.DisplayModes)cbFieldFormat.SelectedIndex);
            cbField.DataSource = tableDataSource.Fields;

            if (selected != null && tableDataSource.Fields.Contains(selected))
            {
                cbField.SelectedItem = selected;
            }
        }

        #endregion

        #region XrmToolBox stuff
        private bool HandleAsyncError(RunWorkerCompletedEventArgs args)
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
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
        }
        #endregion

        #region Bogus stuff

        private void cbBogusDataSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBogusMethod.DataSource = ((BogusDataSetWithMethods)cbBogusDataSet.SelectedItem).Methods;
        }

        private void cbBogusMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bBogusSample_Click(null, null);
        }

        private void bBogusSample_Click(object sender, EventArgs e)
        {
            var language = (BogusLocale)cbBogusLocale.SelectedItem;
            var bogusDs = (BogusDataSetWithMethods)cbBogusDataSet.SelectedItem;
            var method = (MethodWithFriendlyName)cbBogusMethod.SelectedItem;

            tbBogusSample.Text = bogusDataSource.Generate(language.Name, bogusDs, method);
        }

        #endregion

        private void bSave_Click(object sender, EventArgs e)
        {
            AnonymizationRule existingRule = rules.Where(r => r.Field == (MetadataInfo)cbField.SelectedItem).FirstOrDefault();

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
                    Locale = (BogusLocale)cbBogusLocale.SelectedItem,
                    BogusDataSet = (BogusDataSetWithMethods)cbBogusDataSet.SelectedItem,
                    BogusMethod = (MethodWithFriendlyName)cbBogusMethod.SelectedItem
                }
                                                                              : null;

                dgvRules.Refresh();
            }
            else
            {
                rules.Add(new AnonymizationRule
                {
                    Table = (TableMetadataInfo)cbTable.SelectedItem,
                    Field = (MetadataInfo)cbField.SelectedItem,
                    SequenceRule = tabcRule.SelectedTab == tpSequence ? new SequenceRule
                    {
                        SequenceStart = (int)nudSequenceStartFrom.Value,
                        Format = tbSequenceFormat.Text
                    }
                                                                        : null,
                    BogusRule = tabcRule.SelectedTab == tpFakeData ? new BogusRule
                    {
                        Locale = (BogusLocale)cbBogusLocale.SelectedItem,
                        BogusDataSet = (BogusDataSetWithMethods)cbBogusDataSet.SelectedItem,
                        BogusMethod = (MethodWithFriendlyName)cbBogusMethod.SelectedItem
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
            cbTable.SelectedItem = rule.Table;
            cbField.SelectedItem = rule.Field;

            if (rule.SequenceRule != null)
            {
                nudSequenceStartFrom.Value = rule.SequenceRule.SequenceStart;
                tbSequenceFormat.Text = rule.SequenceRule.Format;
                tabcRule.SelectedTab = tpSequence;
            }
            else if (rule.BogusRule != null)
            {
                cbBogusLocale.SelectedItem = rule.BogusRule.Locale;
                cbBogusDataSet.SelectedItem = rule.BogusRule.BogusDataSet;
                cbBogusMethod.SelectedItem = rule.BogusRule.BogusMethod;
                bBogusSample_Click(null, null);

                tabcRule.SelectedTab = tpFakeData;
            }
        }

        private void llBogus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/bchavez/Bogus");
        }

        private void llBypassHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://learn.microsoft.com/en-us/power-apps/developer/data-platform/bypass-custom-business-logic");
        }
    }
}