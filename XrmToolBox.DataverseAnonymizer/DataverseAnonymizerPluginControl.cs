#define __USE_FAKE_METADATA
#define __SAVE_MATADATA

using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using XrmToolBox.DataverseAnonymizer.DataSources;
using XrmToolBox.DataverseAnonymizer.Forms;
using XrmToolBox.DataverseAnonymizer.Helpers;
using XrmToolBox.DataverseAnonymizer.Models;
using XrmToolBox.DataverseAnonymizer.Rules;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using static XrmToolBox.DataverseAnonymizer.Rules.BogusDataSetWithMethods;

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

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            tslVersion.Text = string.Format(tslVersion.Text, $"{version.Major}.{version.Minor}");

            BogusLocale[] locale = BogusLocale.Get();
            comboBogusLocale.DataSource = locale;
            comboBogusLocale.SelectedItem = locale.Where(l => l.Name == "en").FirstOrDefault();

            comboBogusDataSet.DataSource = bogusDataSource.DataSets;

            dgvRules.AutoGenerateColumns = false;
            dgvRules.DataSource = rules;

            dtpRandomDateFrom.Value = DateTime.Today;
            dtpRandomDateTo.Value = DateTime.Today.AddDays(1);
            dtpFixedDate.Value = DateTime.Today;
            dtpFixedDateTime.Value = DateTime.Today;

            bTestFilter.Visible = false;

            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            tbStoreProcessedRecordsPath.Visible = false;
            tbSkipProcessedRecordsPath.Visible = false;
            bStoreProcessedRecordsPath.Visible = false;
            bSkipProcessedRecordsPath.Visible = false;

            ExecuteMethod(DisableOnPremNonSupportedFeatures);

            ExecuteMethod(FillEntities);
        }

        private void DisableOnPremNonSupportedFeatures()
        {
            if (Service is CrmServiceClient serviceClient && serviceClient.ConnectedOrgVersion < new Version("9.2"))
            {
                cbBypassFlows.Checked = false;
                cbBypassFlows.Visible = false;
                cbBypassAsync.Checked = false;
                cbBypassAsync.Visible = false;
            }
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
#if SAVE_MATADATA
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(entitiesMetadata, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(@"..\..\..\Misc\crm_metadata.json", json);
#endif
#endif

                    tableDataSource = new TableDataSource(entitiesMetadata);
                    comboTable.DataSource = tableDataSource.Tables;
                    comboField.DataSource = tableDataSource.Fields;

                    TableMetadataInfo accountMetadata = tableDataSource.Tables.Where(e => e.LogicalName == "account").FirstOrDefault();
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
                        PrimaryNameAttribute = e.PrimaryNameAttribute,
                        Fields = e.Attributes
                                        .Where(a => a.IsValidForUpdate == true
                                                    && a.DisplayName.UserLocalizedLabel != null
                                                    &&
                                                    (
                                                        a.AttributeType == AttributeTypeCode.Memo
                                                        || a.AttributeType == AttributeTypeCode.String
                                                        || a.AttributeType == AttributeTypeCode.Integer
                                                        || a.AttributeType == AttributeTypeCode.BigInt
                                                        || a.AttributeType == AttributeTypeCode.Decimal
                                                        || a.AttributeType == AttributeTypeCode.Money
                                                        || a.AttributeType == AttributeTypeCode.Double
                                                        || a.AttributeType == AttributeTypeCode.DateTime
                                                    // TODO: Add more supported types here in the future
                                                    )
                                        )
                                        .Select(a => new MetadataInfo
                                        {
                                            LogicalName = a.LogicalName,
                                            DisplayName = a.DisplayName.UserLocalizedLabel.Label,
                                            AttributeType = a.AttributeType.Value
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
            comboTable.DataSource = tableDataSource.Tables;

            if (selected != null && tableDataSource.Tables.Contains(selected))
            {
                comboTable.SelectedItem = selected;
            }
        }

        private void comboTableFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)comboTable.SelectedItem;

            tableDataSource.SetDisplayMode((MetadataInfo.DisplayModes)comboTableFormat.SelectedIndex);
            comboTable.DataSource = tableDataSource.Tables;

            if (selected != null && tableDataSource.Tables.Contains(selected))
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

        private void comboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<AttributeTypeCode, TabPage[]> typeToTabs = new Dictionary<AttributeTypeCode, TabPage[]>()
            {
                { AttributeTypeCode.Memo, new []{ tpSequence, tpFakeData, tpFixedString } },
                { AttributeTypeCode.String, new []{ tpSequence, tpFakeData, tpFixedString } },
                { AttributeTypeCode.Integer, new []{ tpRandomInt, tpFixedInt } },
                { AttributeTypeCode.BigInt, new []{ tpRandomInt, tpFixedInt } },
                { AttributeTypeCode.Decimal, new []{ tpRandomDec, tpFixedDec } },
                { AttributeTypeCode.Money, new []{ tpRandomDec, tpFixedDec } },
                { AttributeTypeCode.Double, new []{ tpRandomDec, tpFixedDec } },
                { AttributeTypeCode.DateTime, new []{ tpRandomDate, tpFixedDate } },
            };

            MetadataInfo fieldMetadata = (MetadataInfo)comboField.SelectedItem;

            TabPage[] requiredTabs = typeToTabs[fieldMetadata.AttributeType];

            // Show required tabs. Do not change if not needed to avoid flashing.
            foreach (TabPage tabPage in tabcRule.TabPages)
            {
                if (!requiredTabs.Contains(tabPage))
                {
                    tabcRule.TabPages.Remove(tabPage);
                }
            }

            foreach (TabPage tabPage in typeToTabs[fieldMetadata.AttributeType])
            {
                if (!tabcRule.TabPages.Contains(tabPage))
                {
                    tabcRule.TabPages.Add(tabPage);
                }
            }

            if (requiredTabs.Contains(tpRandomInt))
            {
                GenerateRandomIntSample();
            }
            if (requiredTabs.Contains(tpRandomDec))
            {
                GenerateRandomDecSample();
            }
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

        #region Random Int
        private void bRandomIntSample_Click(object sender, EventArgs e)
        {
            GenerateRandomIntSample();
        }

        private void nudRandomIntRangeFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nudRandomIntRangeFrom.Value >= nudRandomIntRangeTo.Value)
            {
                ShowErrorNotification("The 'From' value must be less than the 'To' value.", null);
                nudRandomIntRangeFrom.Value = nudRandomIntRangeTo.Value - 1;
            }
            GenerateRandomIntSample();
        }

        private void nudRandomIntRangeTo_ValueChanged(object sender, EventArgs e)
        {
            if (nudRandomIntRangeFrom.Value >= nudRandomIntRangeTo.Value)
            {
                ShowErrorNotification("The 'From' value must be less than the 'To' value.", null);
                nudRandomIntRangeTo.Value = nudRandomIntRangeFrom.Value + 1;
            }
            GenerateRandomIntSample();
        }

        private void GenerateRandomIntSample()
        {
            tbRandomIntSample.Text = RandomHelper.GetRandomInt((int)nudRandomIntRangeFrom.Value, (int)nudRandomIntRangeTo.Value).ToString();
        }
        #endregion

        #region Random Dec
        private void nudRandomDecRangeFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nudRandomDecRangeFrom.Value >= nudRandomDecRangeTo.Value)
            {
                ShowErrorNotification("The 'From' value must be less than the 'To' value.", null);
                nudRandomDecRangeFrom.Value = nudRandomDecRangeTo.Value - 1;
            }

            GenerateRandomDecSample();
        }

        private void nudRandomDecRangeTo_ValueChanged(object sender, EventArgs e)
        {
            if (nudRandomDecRangeFrom.Value >= nudRandomDecRangeTo.Value)
            {
                ShowErrorNotification("The 'From' value must be less than the 'To' value.", null);
                nudRandomDecRangeTo.Value = nudRandomDecRangeFrom.Value + 1;
            }

            GenerateRandomDecSample();
        }

        private void nudRandomDecDecimals_ValueChanged(object sender, EventArgs e)
        {
            GenerateRandomDecSample();
        }

        private void bRandomDecSample_Click(object sender, EventArgs e)
        {
            GenerateRandomDecSample();
        }

        private void GenerateRandomDecSample()
        {
            tbRandomDecSample.Text = RandomHelper.GetRandomDecimal(nudRandomIntRangeFrom.Value, nudRandomIntRangeTo.Value).ToString($"N{(int)nudRandomDecDecimals.Value}");
        }
        #endregion

        #region Random date
        private void dtpRandomDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRandomDateFrom.Value >= dtpRandomDateTo.Value)
            {
                ShowErrorNotification("The 'From' value must be less than the 'To' value.", null);
                dtpRandomDateFrom.Value = dtpRandomDateTo.Value.AddDays(-1);
            }

            GenerateRandomDateSample();
        }

        private void dtpRandomDateTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRandomDateFrom.Value >= dtpRandomDateTo.Value)
            {
                ShowErrorNotification("The 'From' value must be less than the 'To' value.", null);
                dtpRandomDateTo.Value = dtpRandomDateFrom.Value.AddDays(1);
            }

            GenerateRandomDateSample();
        }

        private void bRandomDateSample_Click(object sender, EventArgs e)
        {
            GenerateRandomDateSample();
        }

        private void GenerateRandomDateSample()
        {
            tbRandomDateSample.Text = RandomHelper.GetRandomDate(dtpRandomDateFrom.Value, dtpRandomDateTo.Value).ToString();
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
                } : null;

                existingRule.BogusRule = tabcRule.SelectedTab == tpFakeData ? new BogusRule
                {
                    Locale = (BogusLocale)comboBogusLocale.SelectedItem,
                    BogusDataSet = (BogusDataSetWithMethods)comboBogusDataSet.SelectedItem,
                    BogusMethod = (MethodWithFriendlyName)comboBogusMethod.SelectedItem
                } : null;

                existingRule.RandomIntRule = tabcRule.SelectedTab == tpRandomInt ? new RandomIntRule
                {
                    RangeStart = (int)nudRandomIntRangeFrom.Value,
                    RangeEnd = (int)nudRandomIntRangeTo.Value
                } : null;

                existingRule.RandomDecimalRule = tabcRule.SelectedTab == tpRandomDec ? new RandomDecimalRule
                {
                    RangeStart = nudRandomDecRangeFrom.Value,
                    RangeEnd = nudRandomDecRangeTo.Value,
                    DecimalPlaces = (int)nudRandomDecDecimals.Value
                } : null;

                existingRule.RandomDateRule = tabcRule.SelectedTab == tpRandomDate ? new RandomDateRule
                {
                    RangeStart = dtpRandomDateFrom.Value,
                    RangeEnd = dtpRandomDateTo.Value
                } : null;

                existingRule.FixedStringRule = tabcRule.SelectedTab == tpFixedString ? new FixedStringRule
                {
                    Value = tbFixedString.Text
                } : null;

                existingRule.FixedIntRule = tabcRule.SelectedTab == tpFixedInt ? new FixedIntRule
                {
                    Value = (int)nudFixedInt.Value
                } : null;

                existingRule.FixedDecimalRule = tabcRule.SelectedTab == tpFixedDec ? new FixedDecimalRule
                {
                    Value = nudFixedDec.Value
                } : null;

                existingRule.FixedDateRule = tabcRule.SelectedTab == tpFixedDate ? new FixedDateRule
                {
                    Value = dtpFixedDate.Value.Date.Add(dtpFixedDateTime.Value.TimeOfDay)
                } : null;

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
                    } : null,
                    BogusRule = tabcRule.SelectedTab == tpFakeData ? new BogusRule
                    {
                        Locale = (BogusLocale)comboBogusLocale.SelectedItem,
                        BogusDataSet = (BogusDataSetWithMethods)comboBogusDataSet.SelectedItem,
                        BogusMethod = (MethodWithFriendlyName)comboBogusMethod.SelectedItem
                    } : null,
                    RandomIntRule = tabcRule.SelectedTab == tpRandomInt ? new RandomIntRule
                    {
                        RangeStart = (int)nudRandomIntRangeFrom.Value,
                        RangeEnd = (int)nudRandomIntRangeTo.Value
                    } : null,
                    RandomDecimalRule = tabcRule.SelectedTab == tpRandomDec ? new RandomDecimalRule
                    {
                        RangeStart = nudRandomDecRangeFrom.Value,
                        RangeEnd = nudRandomDecRangeTo.Value,
                        DecimalPlaces = (int)nudRandomDecDecimals.Value
                    } : null,
                    RandomDateRule = tabcRule.SelectedTab == tpRandomDate ? new RandomDateRule
                    {
                        RangeStart = dtpRandomDateFrom.Value,
                        RangeEnd = dtpRandomDateTo.Value
                    } : null,
                    FixedStringRule = tabcRule.SelectedTab == tpFixedString ? new FixedStringRule
                    {
                        Value = tbFixedString.Text
                    } : null,
                    FixedIntRule = tabcRule.SelectedTab == tpFixedInt ? new FixedIntRule
                    {
                        Value = (int)nudFixedInt.Value
                    } : null,
                    FixedDecimalRule = tabcRule.SelectedTab == tpFixedDec ? new FixedDecimalRule
                    {
                        Value = nudFixedDec.Value
                    } : null,
                    FixedDateRule = tabcRule.SelectedTab == tpFixedDate ? new FixedDateRule
                    {
                        Value = dtpFixedDate.Value.Date.Add(dtpFixedDateTime.Value.TimeOfDay)
                    } : null
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
            else if (rule.RandomIntRule != null)
            {
                nudRandomIntRangeFrom.Value = rule.RandomIntRule.RangeStart;
                nudRandomIntRangeTo.Value = rule.RandomIntRule.RangeEnd;
                GenerateRandomIntSample();

                tabcRule.SelectedTab = tpRandomInt;
            }
            else if (rule.RandomDecimalRule != null)
            {
                nudRandomDecRangeFrom.Value = rule.RandomDecimalRule.RangeStart;
                nudRandomDecRangeTo.Value = rule.RandomDecimalRule.RangeEnd;
                nudRandomDecDecimals.Value = rule.RandomDecimalRule.DecimalPlaces;
                GenerateRandomDecSample();

                tabcRule.SelectedTab = tpRandomDec;
            }
            else if (rule.RandomDateRule != null)
            {
                dtpRandomDateFrom.Value = rule.RandomDateRule.RangeStart;
                dtpRandomDateTo.Value = rule.RandomDateRule.RangeEnd;
                GenerateRandomDateSample();

                tabcRule.SelectedTab = tpRandomDate;
            }
            else if (rule.FixedStringRule != null)
            {
                tbFixedString.Text = rule.FixedStringRule.Value;
                tabcRule.SelectedTab = tpFixedString;
            }
            else if (rule.FixedIntRule != null)
            {
                nudFixedInt.Value = rule.FixedIntRule.Value;
                tabcRule.SelectedTab = tpFixedInt;
            }
            else if (rule.FixedDecimalRule != null)
            {
                nudFixedDec.Value = rule.FixedDecimalRule.Value;
                tabcRule.SelectedTab = tpFixedDec;
            }
            else if (rule.FixedDateRule != null)
            {
                dtpFixedDate.Value = rule.FixedDateRule.Value.Date;
                dtpFixedDateTime.Value = DateTime.Today.Add(rule.FixedDateRule.Value.TimeOfDay);
                tabcRule.SelectedTab = tpFixedDate;
            }
        }

        #endregion

        #region Running

        private void bRun_Click(object sender, EventArgs e)
        {
            try
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

                string storeProcessedRecordsPath = InitProcessedRecordsFile(out bool abort);
                if (abort) { return; }

                FormDisabled(true);

                WorkSettings settings = new WorkSettings
                {
                    BatchSize = (int)nudBatchSize.Value,
                    Threads = (int)nudThreads.Value,
                    BypassSync = cbBypassSync.Checked,
                    BypassAsync = cbBypassAsync.Checked,
                    BypassFlows = cbBypassFlows.Checked,
                    StoreProcessedRecordsPath = storeProcessedRecordsPath,
                    SkipRecordsPath = tbSkipProcessedRecordsPath.Text
                };

                DataUpdateRunner runner = new DataUpdateRunner(this, bogusDataSource, settings);
                runner.OnDone += (object sender, EventArgs e) =>
                {
                    if (this.IsDisposed) { return; }

                    FinalizeProcessedRecordsFile();

                    FormDisabled(false);
                    running = false;
                    MessageBox.Show("All data successfully processed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                running = true;
                runner.Run(rules.ToArray(), fetchFilters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (running)
                {
                    bStop_Click(null, null);
                }
            }
        }

        private string InitProcessedRecordsFile(out bool abort)
        {
            abort = false;

            if (!cbStoreProcessedRecords.Checked) { return null; }

            string path = tbStoreProcessedRecordsPath.Text;

            if (File.Exists(path))
            {
                DialogResult res = MessageBox.Show("Processed records file already exists. Do you want to append to the existing file? Choosing 'No' will overwrite it.", "File exists", MessageBoxButtons.YesNoCancel);

                if (res == DialogResult.No)
                {
                    File.WriteAllText(path, "");
                }
                else if (res == DialogResult.Cancel)
                {
                    abort = true;
                    return null;
                }
            }

            return path;
        }

        private void FinalizeProcessedRecordsFile()
        {
            if (!cbStoreProcessedRecords.Checked) { return; }

            string path = tbStoreProcessedRecordsPath.Text;

            File.AppendAllText(path, $"{Environment.NewLine}]");
        }

        private void FormDisabled(bool disabled)
        {
            contentPanel.Enabled = !disabled;
            ttbSave.Enabled = !disabled;
            ttbLoad.Enabled = !disabled;
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

                if (this.Parent != null)
                {
                    ShowWarningNotification("The connection has changed. The currently running job has been cancelled. Consider reopening the tool if the metadata has changed.", null);
                }
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
            bTestFilter.Visible = bFetchXmlBuilder.Visible = rbFilterFetchXml.Checked;

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

        private void bTestFilter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFetchXml.Text))
            {
                MessageBox.Show("Please enter a valid FetchXML.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string idField = ((TableMetadataInfo)comboTable.SelectedItem).PrimaryIdAttribute;
            string nameField = ((TableMetadataInfo)comboTable.SelectedItem).PrimaryNameAttribute;

            ExecuteMethod(TestFilter, (CurrentTable, idField, nameField, tbFetchXml.Text));
        }

        private void TestFilter((string currentTable, string idField, string nameField, string fetchXml) arg)
        {
            FormDisabled(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Executing query. Please wait...",
                MessageWidth = 800,
                Work = (worker, args) =>
                {
                    CrmRecord[] records = CrmHelper.GetAll(Service, arg.currentTable, arg.idField, arg.fetchXml, includeName: true, arg.nameField);

                    args.Result = records;
                },
                PostWorkCallBack = (args) =>
                {
                    FormDisabled(false);

                    if (HandleAsyncError(args)) { return; }

                    CrmRecord[] records = (CrmRecord[])args.Result;

                    RecordViewer recordViewer = new RecordViewer(records);
                    recordViewer.ShowDialog();
                }
            });

        }

        #endregion

        #region Save / Load

        private void ttbSave_Click(object sender, EventArgs e)
        {
            if (Service != null)
            {
                saveFileDialog.FileName = $"{((CrmServiceClient)Service).ConnectedOrgFriendlyName} - anonymization.json";
            }

            if (saveFileDialog.ShowDialog() != DialogResult.OK) { return; }

            WorkSettings settings = new WorkSettings
            {
                BatchSize = (int)nudBatchSize.Value,
                Threads = (int)nudThreads.Value,
                BypassSync = cbBypassSync.Checked,
                BypassAsync = cbBypassAsync.Checked,
                BypassFlows = cbBypassFlows.Checked,
                StoreProcessedRecordsPath = tbStoreProcessedRecordsPath.Text,
                SkipRecordsPath = tbSkipProcessedRecordsPath.Text
            };

            StateSaveLoadHelper.Save(fetchFilters, rules, settings, saveFileDialog.FileName);
        }

        private void ttbLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) { return; }

            try
            {
                bool allOk = StateSaveLoadHelper.Load(fetchFilters, rules, bogusDataSource, tableDataSource, openFileDialog.FileName, out WorkSettings settings);

                if (rules.Count > 0)
                {
                    EditRule(rules[0]);
                }

                RestoreFiltersForTable();

                cbBypassSync.Checked = settings.BypassSync;
                cbBypassAsync.Checked = settings.BypassAsync;
                cbBypassFlows.Checked = settings.BypassFlows;
                nudThreads.Value = settings.Threads;
                nudBatchSize.Value = settings.BatchSize;
                tbStoreProcessedRecordsPath.Text = settings.StoreProcessedRecordsPath;
                tbSkipProcessedRecordsPath.Text = settings.SkipRecordsPath;
                cbSkipProcessedRecords.Checked = !string.IsNullOrWhiteSpace(settings.SkipRecordsPath);
                cbStoreProcessedRecords.Checked = !string.IsNullOrWhiteSpace(settings.StoreProcessedRecordsPath);

                if (!allOk)
                {
                    MessageBox.Show("Some rule or filters couldn't be loaded due to invalid configuration or missing metadata.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading saved file. Details: {ex.Message}.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ttbFeedback_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/kowgli/XrmToolBox.DataverseAnonymizer/issues/new");
        }

        #endregion

        private void cbStoreProcessedRecords_CheckedChanged(object sender, EventArgs e)
        {
            tbStoreProcessedRecordsPath.Visible = bStoreProcessedRecordsPath.Visible = cbStoreProcessedRecords.Checked;
            if (!tbStoreProcessedRecordsPath.Visible)
            {
                tbStoreProcessedRecordsPath.Text = "";
            }
        }

        private void cbSkipProcessedRecords_CheckedChanged(object sender, EventArgs e)
        {
            tbSkipProcessedRecordsPath.Visible = bSkipProcessedRecordsPath.Visible = cbSkipProcessedRecords.Checked;
            if (!tbSkipProcessedRecordsPath.Visible)
            {
                tbSkipProcessedRecordsPath.Text = "";
            }
        }

        private void bStoreProcessedRecordsPath_Click(object sender, EventArgs e)
        {
            string originalFilter = saveFileDialog.Filter;
            saveFileDialog.OverwritePrompt = false;

            saveFileDialog.Filter = "Text files|*.txt|All files|*.*";

            if (Service != null)
            {
                saveFileDialog.FileName = $"{((CrmServiceClient)Service).ConnectedOrgFriendlyName} - processed - {DateTime.Now:yyyyMMdd_HHmmss}.txt";
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbStoreProcessedRecordsPath.Text = saveFileDialog.FileName;
            }

            saveFileDialog.Filter = originalFilter;
            saveFileDialog.OverwritePrompt = true;
        }

        private void bSkipProcessedRecordsPath_Click(object sender, EventArgs e)
        {
            string originalFilter = openFileDialog.Filter;

            openFileDialog.FileName = "";
            openFileDialog.Filter = "Text files|*.txt|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbSkipProcessedRecordsPath.Text = openFileDialog.FileName;
            }

            openFileDialog.Filter = originalFilter;
        }
    }
}