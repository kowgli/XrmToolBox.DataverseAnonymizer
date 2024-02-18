namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class MetadataInfo
    {
        public enum DisplayModes
        {
            LogicalNameOnly = 0,
            DisplayNameOnly = 1,
            LogicalPlusDisplayName = 2,
            DisplayPlusLogicalName = 3
        }

        public DisplayModes DisplayMode { get; set; } = DisplayModes.LogicalNameOnly;

        public string LogicalName { get; set; }
        public string DisplayName { get; set; }

        public override string ToString() => DisplayMode switch
        {
            DisplayModes.DisplayPlusLogicalName => $"{DisplayName} ({LogicalName})",
            DisplayModes.LogicalPlusDisplayName => $"{LogicalName} ({DisplayName})",
            DisplayModes.DisplayNameOnly => $"{DisplayName}",
            _ => $"{LogicalName}"
        };
    }
}
