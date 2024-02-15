using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Linq;

namespace XrmToolBox.DataverseAnonymizer.Models
{
    public class EntityDataSource
    {
        private MetadataInfo[] original = null;
        private string filter = "";      

        public MetadataInfo[] Entities { get; private set; }

        public EntityDataSource(EntityMetadata[] entitiesMetadata)
        {
            entitiesMetadata = entitiesMetadata ?? throw new ArgumentNullException(nameof(entitiesMetadata));

            original = entitiesMetadata
                        .Where(e => e.DisplayName.UserLocalizedLabel != null)
                        .Select(e => new EntityMetadataInfo
                        {
                            LogicalName = e.LogicalName,
                            DisplayName = e.DisplayName.UserLocalizedLabel.Label,
                            PrimaryIdAttribute = e.PrimaryIdAttribute,
                            Fields = e.Attributes
                                      .Where(a => a.IsValidForUpdate == true
                                                  && a.DisplayName.UserLocalizedLabel != null
                                                  &&
                                                  (
                                                       a.AttributeType == AttributeTypeCode.Memo
                                                       || a.AttributeType == AttributeTypeCode.String
                                                  // TODO: Add more supported types here in the future
                                                  )
                                      )
                                      .Select(a => new MetadataInfo
                                      {
                                         LogicalName = a.LogicalName,
                                         DisplayName = a.DisplayName.UserLocalizedLabel.Label
                                      })
                                     .ToArray()
                        })
                        .ToArray();

            RefreshEntities();
        }

        public void SetDisplayMode(MetadataInfo.DisplayModes displayMode)
        {
            foreach (MetadataInfo entry in Entities)
            {
                entry.DisplayMode = displayMode;
            }

            RefreshEntities();
        }

        public void Filter(string filter)
        {
            this.filter = (filter ?? "").Trim();

            RefreshEntities();
        }

        private void RefreshEntities()
        {
            if (string.IsNullOrWhiteSpace(filter)) { filter = ""; }

            Entities = original.Where(e => e.ToString().IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                               .OrderBy(e => e.ToString())
                               .ToArray();
        }
    }
}
