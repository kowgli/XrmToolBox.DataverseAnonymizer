namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class FixedIntRule
    {
        public int Value { get; set; }

        public override string ToString() => Value.ToString();
    }
}
