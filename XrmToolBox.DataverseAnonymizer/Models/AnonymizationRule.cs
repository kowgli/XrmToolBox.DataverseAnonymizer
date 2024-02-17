namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class AnonymizationRule
    {
        public MetadataInfo Table { get; set; }

        public MetadataInfo Field { get; set; }
       
        public string Rule => "Some rule 123";
    }
}
