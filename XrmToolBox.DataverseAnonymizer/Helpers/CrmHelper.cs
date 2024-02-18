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
        public static Guid[] GetAllIds(IOrganizationService orgService, string entityName, string idField)
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
