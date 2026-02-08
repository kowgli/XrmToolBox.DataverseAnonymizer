namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class FixedStringRule
    {
        public string Value { get; set; }

        public override string ToString() => Value.ToString();
    }
}
