namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class MetadataInfo
    {
        public enum DisplayModes
        {
            DisplayPlusLogicalName = 0,
            LogicalPlusDisplayName = 1,
            DisplayNameOnly = 2,
            LogicalNameOnly = 3
        }

        public DisplayModes DisplayMode { get; set; } = DisplayModes.DisplayPlusLogicalName;

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
