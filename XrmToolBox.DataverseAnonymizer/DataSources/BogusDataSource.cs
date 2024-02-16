using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using XrmToolBox.DataverseAnonymizer.Models;
using static XrmToolBox.DataverseAnonymizer.Models.BogusDataSetWithMethods;

namespace XrmToolBox.DataverseAnonymizer.DataSources
{
    public class BogusDataSource
    {
        public BogusDataSetWithMethods[] DataSets = null;

        private Regex friendlyNameRegex = new Regex(@"(?<=[a-z])(?=[A-Z])", RegexOptions.Compiled);

        public BogusDataSource()
        {
            Type baseClass = typeof(Bogus.DataSet);
            Assembly bogusAssembly = Assembly.GetAssembly(baseClass);

            Type[] bogusDataSets = bogusAssembly.GetTypes().Where(type => type != baseClass && baseClass.IsAssignableFrom(type)).ToArray();

            DataSets = bogusDataSets
                        .Where(ds => ds.Name != "PremiumDataSet")
                        .OrderBy(ds => ds.Name)
                        .Select(ds => new BogusDataSetWithMethods
                        {
                            Name = ds.Name,
                            FriendlyName = GetFriendlyName(ds.Name),
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
                                        .Select(m => new MethodWithFriendlyName
                                        {
                                            Method = m,
                                            FriendlyName = GetFriendlyName(m.Name)
                                        })
                                        .ToArray()

                        })
                        .Where(ds => ds.Methods.Length > 0)
                        .ToArray();
        }

        private string GetFriendlyName(string name) => !string.IsNullOrWhiteSpace(name) ? friendlyNameRegex.Replace(name, " ") : "";
    }
}
