using System;

namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class RandomDateRule
    {
        public DateTime RangeStart { get; set; }
        public DateTime RangeEnd { get; set; }

        public override string ToString() => $"{{RND:{RangeStart.ToShortDateString()}..{RangeEnd.ToShortDateString()}}}";
    }
}
