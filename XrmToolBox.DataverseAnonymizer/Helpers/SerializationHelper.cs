using Microsoft.Xrm.Sdk;
using System;
using XrmToolBox.DataverseAnonymizer.Models;

namespace XrmToolBox.DataverseAnonymizer.Helpers
{
    public static class SerializationHelper
    {
        public static string FormatRecord(Entity record)
        {
            record = record ?? throw new ArgumentNullException(nameof(record));

            return $"{record.LogicalName}|{record.Id:N}";
        }

        public static CrmRecord ParseRecord(string formattedRecord)
        {
            formattedRecord = formattedRecord ?? throw new ArgumentException(nameof(formattedRecord));

            string[] parts = formattedRecord.Split('|');
            if (parts.Length != 2) { throw new ArgumentOutOfRangeException(nameof(formattedRecord)); }

            return new CrmRecord()
            {
                Name = parts[0].Trim(),
                Id = Guid.Parse(parts[1])
            };
        }
    }
}
