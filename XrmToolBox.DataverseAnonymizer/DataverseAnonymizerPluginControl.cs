using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
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
        private EntityDataSource entityDataSource = null;
        private BogusDataSource bogusDataSource = new BogusDataSource();
        private BindingList<Models.AnonymizationRule> rules = new BindingList<Models.AnonymizationRule>();

        public DataverseAnonymizerPluginControl()
        {
            InitializeComponent();
        }

        private void DataverseAnonymizerPluginControl_Load(object sender, EventArgs e)
        {
            cbEntityFormat.SelectedIndex = 0;
            cbAttributeFormat.SelectedIndex = 0;

            BogusLocale[] locale = BogusLocale.Get();
            cbBogusLocale.DataSource = locale;
            cbBogusLocale.SelectedItem = locale.Where(l => l.Name == "en").FirstOrDefault();

            cbBogusDataSet.DataSource = bogusDataSource.DataSets;
            
            dgvRules.DataSource = rules;         

            ExecuteMethod(FillEntities);
        }

        private void FillEntities()
        {
            contentPanel.Enabled = false;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading tables. This will take a short moment...",
                Work = (worker, args) =>
                {
                    //args.Result = Service.Execute(new RetrieveAllEntitiesRequest
                    //{
                    //    EntityFilters = EntityFilters.Attributes,
                    //    RetrieveAsIfPublished = false
                    //});

                    args.Result = Service.Execute(new WhoAmIRequest());
                },
                PostWorkCallBack = (args) =>
                {
                    contentPanel.Enabled = true;

                    if (HandleAsyncError(args)) { return; }

                    //EntityMetadata[] entities = (args.Result as RetrieveAllEntitiesResponse).EntityMetadata;

                    //if (entities == null || entities.Length == 0)
                    //{
                    //    MessageBox.Show("Failed to retrieve entities", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    //EntityMetadataInfo[] entitiesMetadata = entities
                    //                                            .Where(e => e.DisplayName.UserLocalizedLabel != null)
                    //                                            .Select(e => new EntityMetadataInfo
                    //                                            {
                    //                                                LogicalName = e.LogicalName,
                    //                                                DisplayName = e.DisplayName.UserLocalizedLabel.Label,
                    //                                                PrimaryIdAttribute = e.PrimaryIdAttribute,
                    //                                                Fields = e.Attributes
                    //                                                              .Where(a => a.IsValidForUpdate == true
                    //                                                                          && a.DisplayName.UserLocalizedLabel != null
                    //                                                                          &&
                    //                                                                          (
                    //                                                                               a.AttributeType == AttributeTypeCode.Memo
                    //                                                                               || a.AttributeType == AttributeTypeCode.String
                    //                                                                          // TODO: Add more supported types here in the future
                    //                                                                          )
                    //                                                              )
                    //                                                              .Select(a => new MetadataInfo
                    //                                                              {
                    //                                                                  LogicalName = a.LogicalName,
                    //                                                                  DisplayName = a.DisplayName.UserLocalizedLabel.Label
                    //                                                              })
                    //                                                             .ToArray()
                    //                                            })
                    //                                            .ToArray();                    

                    //string json = Newtonsoft.Json.JsonConvert.SerializeObject(entitiesMetadata);
                    //System.IO.File.WriteAllText(@"C:\temp\crm_metadata.json", json);

                    string json = System.IO.File.ReadAllText(@"C:\temp\crm_metadata.json");
                    EntityMetadataInfo[] entitiesMetadata = Newtonsoft.Json.JsonConvert.DeserializeObject<EntityMetadataInfo[]>(json);

                    entityDataSource = new EntityDataSource(entitiesMetadata);
                    cbEntity.DataSource = entityDataSource.Entities;
                    cbAttribute.DataSource = entityDataSource.Attributes;
                }
            });
        }

        #region Metadata filter handling

        private void tbEntityFilter_TextChanged(object sender, EventArgs e)
        {
            if (entityDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)cbEntity.SelectedItem;

            entityDataSource.Filter(tbEntityFilter.Text);
            cbEntity.DataSource = entityDataSource.Entities;

            if (selected != null && entityDataSource.Entities.Contains(selected))
            {
                cbEntity.SelectedItem = selected;
            }
        }

        private void cbEntityFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entityDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)cbEntity.SelectedItem;

            entityDataSource.SetDisplayMode((MetadataInfo.DisplayModes)cbEntityFormat.SelectedIndex);
            cbEntity.DataSource = entityDataSource.Entities;

            if (selected != null && entityDataSource.Entities.Contains(selected))
            {
                cbEntity.SelectedItem = selected;
            }
        }

        private void cbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEntity.SelectedItem == null) { return; }

            EntityMetadataInfo entity = (EntityMetadataInfo)cbEntity.SelectedItem;

            entityDataSource.SetAttributesFromEntity(entity);

            cbAttribute.DataSource = entityDataSource.Attributes;
        }

        private void tbAttributeFilter_TextChanged(object sender, EventArgs e)
        {
            if (entityDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)cbAttribute.SelectedItem;

            entityDataSource.FilterAttributes(tbAttributeFilter.Text);
            cbAttribute.DataSource = entityDataSource.Attributes;

            if (selected != null && entityDataSource.Attributes.Contains(selected))
            {
                cbAttribute.SelectedItem = selected;
            }
        }

        private void cbAttributeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entityDataSource == null) { return; }

            MetadataInfo selected = (MetadataInfo)cbAttribute.SelectedItem;

            entityDataSource.SetAttributeDisplayMode((MetadataInfo.DisplayModes)cbAttributeFormat.SelectedIndex);
            cbAttribute.DataSource = entityDataSource.Attributes;

            if (selected != null && entityDataSource.Attributes.Contains(selected))
            {
                cbAttribute.SelectedItem = selected;
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
            // Before leaving, save the settings
            //SettingsManager.Instance.Save(GetType(), mySettings);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            //if (mySettings != null && detail != null)
            //{
            //    mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
            //    LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            //}
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
            rules.Add(new Models.AnonymizationRule()
            {
                Table = (MetadataInfo)cbEntity.SelectedItem,
                Field = (MetadataInfo)cbAttribute.SelectedItem
            });
            dgvRules.AutoResizeColumns();
        }
    }
}