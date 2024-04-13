namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class RandomIntRule
    {
        public int RangeStart { get; set; }
        public int RangeEnd { get; set; }

        public override string ToString() => $"{{RND:{RangeStart}..{RangeEnd}}}";
    }
}
