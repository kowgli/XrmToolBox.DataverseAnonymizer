using System;
using System.Linq;
using static XrmToolBox.DataverseAnonymizer.Models.MetadataInfo;

namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class EntityDataSource
    {
        private EntityMetadataInfo[] originalEntities = null;
        private MetadataInfo[] originalAttributes = null;
        private string entityFilter = "";
        private string attributeFilter = "";

        public EntityMetadataInfo[] Entities { get; private set; }
        public MetadataInfo[] Attributes { get; private set; }

        public EntityDataSource(EntityMetadataInfo[] entitiesMetadata)
        {
            entitiesMetadata = entitiesMetadata ?? throw new ArgumentNullException(nameof(entitiesMetadata));

            originalEntities = entitiesMetadata;
            originalAttributes = entitiesMetadata.FirstOrDefault()?.Fields;

            RefreshEntities();
            RefreshAttributes();
        }

        public void SetDisplayMode(MetadataInfo.DisplayModes displayMode)
        {
            foreach (MetadataInfo ntity in Entities)
            {
                ntity.DisplayMode = displayMode;
            }

            RefreshEntities();
        }

        public void Filter(string filter)
        {
            this.entityFilter = (filter ?? "").Trim();

            RefreshEntities();
        }

        public void FilterAttributes(string filter)
        {
            this.attributeFilter = (filter ?? "").Trim();

            RefreshAttributes();
        }

        public void SetAttributeDisplayMode(DisplayModes displayMode)
        {
            foreach (MetadataInfo field in Attributes)
            {
                field.DisplayMode = displayMode;
            }

            RefreshAttributes();
        }

        public void SetAttributesFromEntity(EntityMetadataInfo entity)
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
                Attributes = originalAttributes.Where(e => e.ToString().IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
            else
            {
                Attributes = originalAttributes.Where(e => e.ToString().StartsWith(attributeFilter, StringComparison.OrdinalIgnoreCase))
                               .OrderBy(e => e.ToString())
                               .ToArray();
            }
        }
    }
}
