namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class TableMetadataInfo : MetadataInfo
    {
        public string PrimaryIdAttribute { get; set; }
        public string PrimaryNameAttribute { get; set; }
        public MetadataInfo[] Fields { get; set; }
    }
}
