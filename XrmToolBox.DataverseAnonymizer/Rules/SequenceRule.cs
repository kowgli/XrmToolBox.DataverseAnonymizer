namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class SequenceRule
    {
        public int SequenceStart { get; set; }
        public string Format { get; set; }

        public override string ToString() => (Format ?? "").Replace("{SEQ}", $"{{SEQ:{SequenceStart}..N}}");
    }
}
