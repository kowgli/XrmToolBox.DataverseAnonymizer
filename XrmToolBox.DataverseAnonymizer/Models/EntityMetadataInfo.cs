namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class EntityMetadataInfo : MetadataInfo
    {
        public string PrimaryIdAttribute { get; set; }
        public MetadataInfo[] Fields { get; set; }
    }
}
