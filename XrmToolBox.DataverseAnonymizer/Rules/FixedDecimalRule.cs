namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class FixedDecimalRule
    {
        public decimal Value { get; set; }

        public override string ToString() => Value.ToString();
    }
}
