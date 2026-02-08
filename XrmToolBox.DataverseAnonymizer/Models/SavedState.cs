using System;
using System.Web.Services.Protocols;

namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class SavedState
    {
        public class Filter
        {
            public string Table { get; set; }
            public string FetchXml { get; set; }
        }

        public class Rule
        {
            public class SequenceSettings
            {
                public int SequenceStart { get; set; }
                public string Format { get; set; }
            }

            public class BogusSettings
            {
                public string Locale { get; set; }
                public string DataSet { get; set; }
                public string Method { get; set; }
            }

            public class RandomIntSettings
            {
                public int RangeStart { get; set; }
                public int RangeEnd { get; set; }
            }

            public class RandomDecSettings
            {
                public decimal RangeStart { get; set; }
                public decimal RangeEnd { get; set; }
                public int DecimalPlaces { get; set; }
            }

            public class RandomDateSettings
            {
                public DateTime RangeStart { get; set; }
                public DateTime RangeEnd { get; set; }
            }

            public class FixedIntSettings
            {
                public int Value { get; set; }
            }

            public class FixedDecSettings
            {
                public decimal Value { get; set; }
            }

            public class FixedStringSettings
            {
                public string Value { get; set; }
            }

            public class FixedDateSettings
            {
                public DateTime Value { get; set; }
            }

            public string Table { get; set; }
            public string Field { get; set; }

            public SequenceSettings Sequence { get; set; }
            public BogusSettings Bogus { get; set; }
            public RandomIntSettings RandomInt { get; set; }
            public RandomDecSettings RandomDec { get; set; }
            public RandomDateSettings RandomDate { get; set; }
            public FixedIntSettings FixedInt { get; set; }
            public FixedDecSettings FixedDec { get; set; }
            public FixedStringSettings FixedString { get; set; }
            public FixedDateSettings FixedDate { get; set; }
        }

        public Filter[] Filters { get; set; } = new Filter[0];
        public Rule[] Rules { get; set; } = new Rule[0];
        public WorkSettings WorkSettings = new WorkSettings();
    }
}
