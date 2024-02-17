using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using XrmToolBox.DataverseAnonymizer.Models;

namespace XrmToolBox.DataverseAnonymizer.Helpers
{
    public static class CrmHelper
    {
        /// <returns>key: logical name, value: all id's</returns>
        public static Dictionary<string, (string, Guid[])> GetAllIds(IOrganizationService orgService, AnonymizationRule[] rules)
        {
            orgService = orgService ?? throw new ArgumentNullException(nameof(orgService));
            rules = rules ?? throw new ArgumentNullException(nameof(rules));

            Dictionary<string, (string, Guid[])> result = new Dictionary<string, (string, Guid[])>();

            Dictionary<string, string> tables = GetInvolvedTables(rules);

            foreach (string logicalName in tables.Keys)
            {
                string idField = tables[logicalName];
                result.Add(logicalName, (idField, GetAllIds(orgService, logicalName, idField)));
            }

            return result;
        }

        /// <returns>key: logical name, value: primary attribute</returns>
        private static Dictionary<string, string> GetInvolvedTables(AnonymizationRule[] rules)
        {
            string[] logicalNames = (rules ?? new AnonymizationRule[0])
                                .Select(r => r.Table.LogicalName)
                                .Distinct()
                                .OrderBy(t => t)
                                .ToArray();

            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (string logicalName in logicalNames)
            {
                result.Add(logicalName, rules.First(r => r.Table.LogicalName == logicalName).Table.PrimaryIdAttribute);
            }

            return result;
        }

        private static Guid[] GetAllIds(IOrganizationService orgService, string entityName, string idField)
        {
            QueryExpression query = new QueryExpression(entityName);
            query.NoLock = true;
            query.ColumnSet = new ColumnSet(idField);
            query.PageInfo = new PagingInfo
            {
                PageNumber = 1,
                Count = 5000
            };

            List<Guid> result = new List<Guid>();

            int pageNr = 1;

            while (true)
            {
                EntityCollection ecoll = orgService.RetrieveMultiple(query);

                result.AddRange(ecoll.Entities.Select(e => e.Id).ToArray());

                if (!ecoll.MoreRecords)
                {
                    break;
                }

                pageNr++;
                query.PageInfo.PageNumber = pageNr;
                query.PageInfo.PagingCookie = ecoll.PagingCookie;
            }

            return result.ToArray();
        }
    }
}
