using System;

namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class FixedDateRule
    {
        public DateTime Value { get; set; }

        public override string ToString() => Value.ToShortDateString();
    }
}
