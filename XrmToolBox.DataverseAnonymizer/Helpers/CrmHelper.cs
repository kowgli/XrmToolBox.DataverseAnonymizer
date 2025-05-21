using Microsoft.Crm.Sdk.Messages;
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
        public static CrmRecord[] GetAll(IOrganizationService orgService, string entityName, string idField, string fetchXmlFilter, bool includeName = false, string nameField = null)
        {
            if (includeName && string.IsNullOrWhiteSpace(nameField))
            {
                throw new ArgumentNullException(nameof(nameField));
            }
            
            QueryExpression query = null;

            int? filterTop = null;

            if (fetchXmlFilter == null)
            {
                query = new QueryExpression(entityName);
                query.NoLock = true;
            }
            else
            {
                query = GetQueryFromFilter(orgService, fetchXmlFilter);
                query.NoLock = true;
                filterTop = query.TopCount; // Will be null or <= 5000

                if (query.EntityName != entityName)
                {
                    throw new Exception($"FetchXML filter is on the wrong table. Expected \"{entityName}\", got \"{query.EntityName}\".");
                }
            }

            query.TopCount = null;
            query.ColumnSet = includeName ? new ColumnSet(idField, nameField) : new ColumnSet(idField);
            query.PageInfo = new PagingInfo
            {
                PageNumber = 1,
                Count = filterTop != null ? filterTop.Value : 5000
            };

            List<CrmRecord> result = new List<CrmRecord>();

            int pageNr = 1;

            while (true)
            {
                EntityCollection ecoll = orgService.RetrieveMultiple(query);

                result.AddRange(ecoll.Entities.Select(e => new CrmRecord 
                { 
                    Id = e.Id,
                    Name = !string.IsNullOrWhiteSpace(nameField) ? e.GetAttributeValue<string>(nameField) : null 
                }).ToArray());

                if (filterTop != null)
                {
                    break;               
                }

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

        private static QueryExpression GetQueryFromFilter(IOrganizationService orgService, string fetchXmlFilter)
        {
            FetchXmlToQueryExpressionRequest convertReq = new FetchXmlToQueryExpressionRequest()
            {
                FetchXml = fetchXmlFilter
            };
            FetchXmlToQueryExpressionResponse convertResp = (FetchXmlToQueryExpressionResponse)orgService.Execute(convertReq);

            return convertResp.Query;
        }
    }
}
