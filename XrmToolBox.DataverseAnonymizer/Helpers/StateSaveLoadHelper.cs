﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using XrmToolBox.DataverseAnonymizer.DataSources;
using XrmToolBox.DataverseAnonymizer.Models;
using static XrmToolBox.DataverseAnonymizer.Models.BogusDataSetWithMethods;

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

        /// <returns>True if all rules loaded successfully, false otherwise.</returns>
        public static bool Load(Dictionary<string, string> fetchFilters, BindingList<AnonymizationRule> rules, BogusDataSource bogusDataSource, TableDataSource tableDataSource, string fileName)
        {
            bool allOk = true;
            
            string fileContents = File.ReadAllText(fileName);

            SavedState savedState = JsonConvert.DeserializeObject<SavedState>(fileContents);

            fetchFilters.Clear();
            foreach (var filter in savedState.Filters)
            {
                fetchFilters.Add(filter.Table, filter.FetchXml);
            }

            BogusLocale[] allBogusLocale = BogusLocale.Get();

            rules.Clear();
            foreach (var rule in savedState.Rules)
            {
                if (rule.Table == null || rule.Field == null || rule.Bogus == null && rule.Sequence == null)
                {
                    allOk = false;
                    continue;
                }
                
                var table = tableDataSource.Tables.FirstOrDefault(e => e.LogicalName == rule.Table);
                var field = table?.Fields?.FirstOrDefault(f => f.LogicalName == rule.Field);                

                if (table == null || field == null)
                {
                    allOk = false;
                    continue;
                }

                BogusLocale bogusLocale = null;
                BogusDataSetWithMethods bogusDataSet = null;
                MethodWithFriendlyName bogusMethod = null;

                if (rule.Bogus != null)
                {
                    bogusLocale = allBogusLocale.FirstOrDefault(l => l.Name == rule.Bogus.Locale);
                    bogusDataSet = bogusDataSource.DataSets.FirstOrDefault(ds => ds.Name == rule.Bogus.DataSet);
                    bogusMethod = bogusDataSet?.Methods?.FirstOrDefault(m => m.Method?.Name == rule.Bogus.Method);

                    if (bogusLocale == null || bogusDataSet == null || bogusMethod == null)
                    {
                        allOk = false;
                        continue;
                    }
                }

                rules.Add(new AnonymizationRule
                {
                    Table = table,
                    Field = field,
                    SequenceRule = rule.Sequence == null ? null : new SequenceRule
                    {
                        SequenceStart = rule.Sequence.SequenceStart,
                        Format = rule.Sequence.Format
                    },
                    BogusRule = rule.Bogus == null ? null : new BogusRule
                    {
                        Locale = bogusLocale,
                        BogusDataSet = bogusDataSet,
                        BogusMethod = bogusMethod
                    }
                });
            }

            return allOk;
        }
    }
}
