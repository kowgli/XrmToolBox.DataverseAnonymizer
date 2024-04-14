using XrmToolBox.DataverseAnonymizer.DataSources;
using static XrmToolBox.DataverseAnonymizer.Rules.BogusDataSetWithMethods;

namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class BogusRule
    {
        public BogusLocale Locale { get; set; }
        public BogusDataSetWithMethods BogusDataSet { get; set; }
        public MethodWithFriendlyName BogusMethod { get; set; }

        public override string ToString() => $"{Locale.FriendlyName}\\{BogusDataSet.FriendlyName}\\{BogusMethod.FriendlyName}";


    }
}
