using System;
using System.Linq;
using XrmToolBox.DataverseAnonymizer.Models;
using static XrmToolBox.DataverseAnonymizer.Models.MetadataInfo;

namespace XrmToolBox.DataverseAnonymizer.DataSources
{
    public class TableDataSource
    {
        private TableMetadataInfo[] originalTables = null;
        private MetadataInfo[] originalFields = null;
        private string tableFilter = "";
        private string fieldFilter = "";

        public TableMetadataInfo[] Tables { get; private set; }
        public MetadataInfo[] Fields { get; private set; }

        public TableDataSource(TableMetadataInfo[] entitiesMetadata)
        {
            entitiesMetadata = entitiesMetadata ?? throw new ArgumentNullException(nameof(entitiesMetadata));

            originalTables = entitiesMetadata;
            originalFields = entitiesMetadata.FirstOrDefault()?.Fields;

            RefreshEntities();
            RefreshAttributes();
        }

        public void SetDisplayMode(DisplayModes displayMode)
        {
            foreach (MetadataInfo ntity in Tables)
            {
                ntity.DisplayMode = displayMode;
            }

            RefreshEntities();
        }

        public void Filter(string filter)
        {
            tableFilter = (filter ?? "").Trim();

            RefreshEntities();
        }

        public void FilterFields(string filter)
        {
            fieldFilter = (filter ?? "").Trim();

            RefreshAttributes();
        }

        public void SetFieldDisplayMode(DisplayModes displayMode)
        {
            foreach (MetadataInfo field in Fields)
            {
                field.DisplayMode = displayMode;
            }

            RefreshAttributes();
        }

        public void SetFieldsFromTable(TableMetadataInfo table)
        {
            originalFields = table.Fields;
            RefreshAttributes();
        }

        private void RefreshEntities()
        {
            if (string.IsNullOrWhiteSpace(tableFilter)) { tableFilter = ""; }

            if (tableFilter.StartsWith("*"))
            {
                string filter = tableFilter.TrimStart('*');
                Tables = originalTables.Where(e => e.ToString().IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
            else
            {
                Tables = originalTables.Where(e => e.ToString().StartsWith(tableFilter, StringComparison.OrdinalIgnoreCase))
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
        }

        private void RefreshAttributes()
        {
            if (string.IsNullOrWhiteSpace(fieldFilter)) { fieldFilter = ""; }

            if (fieldFilter.StartsWith("*"))
            {
                string filter = fieldFilter.TrimStart('*');
                Fields = originalFields.Where(e => e.ToString().IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
            else
            {
                Fields = originalFields.Where(e => e.ToString().StartsWith(fieldFilter, StringComparison.OrdinalIgnoreCase))
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
        }
    }
}
