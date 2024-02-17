using System;
using System.Linq;
using XrmToolBox.DataverseAnonymizer.Models;
using static XrmToolBox.DataverseAnonymizer.Models.MetadataInfo;

namespace XrmToolBox.DataverseAnonymizer.DataSources
{
    public class TableDataSource
    {
        private TableMetadataInfo[] originalEntities = null;
        private MetadataInfo[] originalAttributes = null;
        private string entityFilter = "";
        private string attributeFilter = "";

        public TableMetadataInfo[] Entities { get; private set; }
        public MetadataInfo[] Fields { get; private set; }

        public TableDataSource(TableMetadataInfo[] entitiesMetadata)
        {
            entitiesMetadata = entitiesMetadata ?? throw new ArgumentNullException(nameof(entitiesMetadata));

            originalEntities = entitiesMetadata;
            originalAttributes = entitiesMetadata.FirstOrDefault()?.Fields;

            RefreshEntities();
            RefreshAttributes();
        }

        public void SetDisplayMode(DisplayModes displayMode)
        {
            foreach (MetadataInfo ntity in Entities)
            {
                ntity.DisplayMode = displayMode;
            }

            RefreshEntities();
        }

        public void Filter(string filter)
        {
            entityFilter = (filter ?? "").Trim();

            RefreshEntities();
        }

        public void FilterFields(string filter)
        {
            attributeFilter = (filter ?? "").Trim();

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

        public void SetFieldsFromTable(TableMetadataInfo entity)
        {
            originalAttributes = entity.Fields;
            RefreshAttributes();
        }

        private void RefreshEntities()
        {
            if (string.IsNullOrWhiteSpace(entityFilter)) { entityFilter = ""; }

            if (entityFilter.StartsWith("*"))
            {
                string filter = entityFilter.TrimStart('*');
                Entities = originalEntities.Where(e => e.ToString().IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
            else
            {
                Entities = originalEntities.Where(e => e.ToString().StartsWith(entityFilter, StringComparison.OrdinalIgnoreCase))
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
        }

        private void RefreshAttributes()
        {
            if (string.IsNullOrWhiteSpace(attributeFilter)) { attributeFilter = ""; }

            if (attributeFilter.StartsWith("*"))
            {
                string filter = attributeFilter.TrimStart('*');
                Fields = originalAttributes.Where(e => e.ToString().IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
            else
            {
                Fields = originalAttributes.Where(e => e.ToString().StartsWith(attributeFilter, StringComparison.OrdinalIgnoreCase))
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
        }
    }
}
