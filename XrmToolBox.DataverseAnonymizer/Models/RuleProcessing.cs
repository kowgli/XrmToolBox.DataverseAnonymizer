using System;

namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class RuleProcessing
    {
        public RuleProcessing(string tableLogicalName, string primaryIdFieldLogicalName, AnonymizationRule[] rules)
        {
            this.TableLogicalName = tableLogicalName ?? throw new ArgumentNullException(nameof(tableLogicalName));
            this.PrimaryIdFieldLogicalName = primaryIdFieldLogicalName ?? throw new ArgumentNullException(nameof(primaryIdFieldLogicalName));
            this.Rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }


        public string TableLogicalName { get; set; }

        public string PrimaryIdFieldLogicalName { get; set; }

        public AnonymizationRule[] Rules { get; set; }

        public Guid[] RecordIds { get; set; }

    }
}
