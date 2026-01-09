namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class WorkSettings
    {
        public int BatchSize { get; set; }
        public bool BypassSync { get; set; }
        public bool BypassAsync { get; set; }
        public bool BypassFlows { get; set; }       
        public int Threads { get; set; }
        public string StoreProcessedRecordsPath { get; internal set; }
    }
}
