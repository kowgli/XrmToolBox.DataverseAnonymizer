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

            public string Table { get; set; }
            public string Field { get; set; }

            public SequenceSettings Sequence { get; set; }
            public BogusSettings Bogus { get; set; }
        }

        public Filter[] Filters { get; set; } = new Filter[0];
        public Rule[] Rules { get; set; } = new Rule[0];
    }
}
