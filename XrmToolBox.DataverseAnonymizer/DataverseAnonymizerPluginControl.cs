using Bogus;
using Bogus.Premium;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
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
using XrmToolBox.Extensibility;

namespace XrmToolBox.DataverseAnonymizer
{
    public partial class DataverseAnonymizerPluginControl : PluginControlBase
    {
        private Settings mySettings;

        public DataverseAnonymizerPluginControl()
        {
            InitializeComponent();
        }

        class Account
        {
            public string Name { get; set; }

            public string Address1_Street { get; set; }

            public string PhoneNumber { get; set; }
        }

        private void DataverseAnonymizerPluginControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            Faker faker = new Faker("sv");

            //Account acc = new Account()
            //{
            //    Name = faker.Company.CompanyName(),
            //    Address1_Street = faker.Address.StreetAddress(),
            //    PhoneNumber = faker.Phone.PhoneNumber()
            //};

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





        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAccounts);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataverseAnonymizerPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

       
    }
}