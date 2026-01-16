namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class WorkSettings
    {        
        public bool BypassSync { get; set; }
        public bool BypassAsync { get; set; }
        public bool BypassFlows { get; set; }
        
        public int Threads { get; set; } = 8;
        public int BatchSize { get; set; } = 50;

        public string StoreProcessedRecordsPath { get; set; }
        public string SkipRecordsPath { get; set; }
    }
}
