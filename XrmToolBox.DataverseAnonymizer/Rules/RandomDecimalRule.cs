namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class RandomDecimalRule
    {
        public decimal RangeStart { get; set; }
        public decimal RangeEnd { get; set; }
        public int DecimalPlaces { get; set; }

        public override string ToString() => $"{{RND:{RangeStart.ToString($"N{DecimalPlaces}")}..{RangeEnd.ToString($"N{DecimalPlaces}")}}}";
    }
}
