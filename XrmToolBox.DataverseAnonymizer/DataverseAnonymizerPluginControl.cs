using Bogus;
using Bogus.Premium;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.DataverseAnonymizer.Controls;
using XrmToolBox.DataverseAnonymizer.Models;
using XrmToolBox.Extensibility;

namespace XrmToolBox.DataverseAnonymizer
{
    public partial class DataverseAnonymizerPluginControl : PluginControlBase
    {
        private EntityDataSource entityDataSource = null;  

        public DataverseAnonymizerPluginControl()
        {
            InitializeComponent();
        }

        private void DataverseAnonymizerPluginControl_Load(object sender, EventArgs e)
        {
            cbEntityFormat.SelectedIndex = 0;
            cbAttributeFormat.SelectedIndex = 0;

            ExecuteMethod(FillEntities);
        }

        private void FillEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading tables...",
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

            MetadataInfo selected = (MetadataInfo) cbEntity.SelectedItem;
            
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
            
            MetadataInfo selected = (MetadataInfo) cbEntity.SelectedItem;

            entityDataSource.SetDisplayMode((MetadataInfo.DisplayModes) cbEntityFormat.SelectedIndex);
            cbEntity.DataSource = entityDataSource.Entities;

            if (selected != null && entityDataSource.Entities.Contains(selected))
            {
                cbEntity.SelectedItem = selected;
            }
        }

        private void cbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEntity.SelectedItem == null) { return; }

            EntityMetadataInfo entity = (EntityMetadataInfo) cbEntity.SelectedItem;

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
        //private Settings mySettings;

        private void PartOfOnload()
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            //if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            //{
            //    mySettings = new Settings();

            //    LogWarning("Settings not found => a new settings file has been created!");
            //}
            //else
            //{
            //    LogInfo("Settings found and loaded");
            //}

            //BogusStuff();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataverseAnonymizerPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            //SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
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
        private bool HandleAsyncError(RunWorkerCompletedEventArgs args)
        {
            if (args.Error != null)
            {
                MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void BogusStuff()
        {
            Faker faker = new Faker("sv");

            Type baseClass = typeof(Bogus.DataSet);

            Assembly bogusAssembly = Assembly.GetAssembly(baseClass);

            Type[] bogusDataSets = bogusAssembly.GetTypes().Where(type => type != baseClass && baseClass.IsAssignableFrom(type)).ToArray();

            BogusDataSetWithMethods[] bindableDataSets = bogusDataSets
                                                            .Where(ds => ds.Name != "PremiumDataSet")
                                                            .OrderBy(ds => ds.Name)
                                                            .Select(ds => new BogusDataSetWithMethods
                                                            {
                                                                Name = ds.Name,
                                                                DataSetType = ds,
                                                                Methods = ds.GetMethods()
                                                                            .Where(m =>
                                                                                m.ReturnType == typeof(string)
                                                                                && m.IsPublic
                                                                                && !m.ContainsGenericParameters
                                                                                && !m.IsVirtual
                                                                                &&
                                                                                (
                                                                                    m.GetParameters().Length == 0
                                                                                    || m.GetParameters().All(param => param.IsOptional)
                                                                                )
                                                                            )
                                                                            .OrderBy(m => m.Name)
                                                                            .Select(m => m)
                                                                            .ToArray()

                                                            })
                                                            .Where(ds => ds.Methods.Length > 0)
                                                            .ToArray();

            string dep = faker.Address.StreetName();

            cbBogusDataSet.DataSource = bindableDataSets;
        }

        public class BogusDataSetWithMethods
        {
            public string Name { get; set; }
            public Type DataSetType { get; set; }

            public MethodInfo[] Methods { get; set; }
        }

        private void cbBogusDataSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBogusMethod.DataSource = ((BogusDataSetWithMethods)cbBogusDataSet.SelectedItem).Methods;
        }

        private void bGenerate_Click(object sender, EventArgs e)
        {
            var bogusDs = (BogusDataSetWithMethods)cbBogusDataSet.SelectedItem;
            var methodInfo = (MethodInfo)cbBogusMethod.SelectedItem;

            Faker faker = new Faker("sv");

            PropertyInfo dataSetProperty = faker.GetType().GetProperties().Where(p => p.PropertyType == bogusDs.DataSetType).FirstOrDefault();
            object dataSetInstance = dataSetProperty.GetValue(faker);

            object[] parameterValues = null;

            // If any parameters are optional, prepare their default values
            if (methodInfo.GetParameters().Any(param => param.IsOptional))
            {
                parameterValues = new object[methodInfo.GetParameters().Length];
                for (int i = 0; i < parameterValues.Length; i++)
                {
                    ParameterInfo parameter = methodInfo.GetParameters()[i];
                    if (parameter.IsOptional)
                    {
                        parameterValues[i] = parameter.DefaultValue;
                    }
                    else
                    {
                        // Handle required parameters (e.g., throw an exception)
                        throw new ArgumentException("Required parameter not found");
                    }
                }
            }

            string result = methodInfo.Invoke(dataSetInstance, parameterValues) as string;

            textBox1.Text = result + "\r\n" + textBox1.Text;
        }
        #endregion

        
    }
}