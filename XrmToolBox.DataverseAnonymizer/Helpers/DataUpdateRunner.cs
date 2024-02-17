using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XrmToolBox.DataverseAnonymizer.Models;
using XrmToolBox.Extensibility;

namespace XrmToolBox.DataverseAnonymizer.Helpers
{
    public class DataUpdateRunner
    {
        private readonly DataverseAnonymizerPluginControl control;

        public DataUpdateRunner(DataverseAnonymizerPluginControl control)
        {
            this.control = control ?? throw new ArgumentNullException(nameof(control));
        }

        public void Run(AnonymizationRule[] rules)
        {
            control.WorkAsync(new WorkAsyncInfo()
            {
                Message = "Getting all ID's...",
                Work = (worker, args) =>
                {
                    args.Result = CrmHelper.GetAllIds(control.Service, rules.ToArray());
                },
                PostWorkCallBack = GetAllIdsDone
            });
        }

        private void GetAllIdsDone(RunWorkerCompletedEventArgs args)
        {
            if (control.HandleAsyncError(args)) { return; }

            Dictionary<string, (string idField, Guid[] ids)> result = (Dictionary<string, (string, Guid[])>)args.Result;

            foreach (string logicalNames in result.Keys)
            {
                (string idField, Guid[] ids) = result[logicalNames];

                control.WorkAsync(new WorkAsyncInfo()
                {
                    Message = $"Updating {logicalNames}",
                    Work = (worker, args) =>
                    {
                        System.Threading.Thread.Sleep(3000);
                    }
                });
            }

            // TODO: Needs a callback loop
        }
    }
}
