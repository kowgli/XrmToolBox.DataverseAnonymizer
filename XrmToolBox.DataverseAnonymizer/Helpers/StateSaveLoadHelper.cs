using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using XrmToolBox.DataverseAnonymizer.Models;

namespace XrmToolBox.DataverseAnonymizer.Helpers
{
    public class StateSaveLoadHelper
    {
        public static void Save(Dictionary<string, string> fetchFilters, BindingList<AnonymizationRule> rules, string filePath)
        {
            SavedState savedState = new SavedState
            {
                Filters = fetchFilters.Select(ff => new SavedState.Filter { Table = ff.Key, FetchXml = ff.Value }).ToArray(),
                Rules = rules.Select(r => r.ToSaveModel()).ToArray()
            };

            string fileContents = JsonConvert.SerializeObject(savedState, Formatting.Indented);

            File.WriteAllText(filePath, fileContents);
        }
    }
}
