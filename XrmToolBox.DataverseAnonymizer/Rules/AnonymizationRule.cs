using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XrmToolBox.DataverseAnonymizer.Models;

namespace XrmToolBox.DataverseAnonymizer.Rules
{
    public class AnonymizationRule : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public TableMetadataInfo Table { get; set; }

        public MetadataInfo Field { get; set; }

        private SequenceRule sequenceRule;
        public SequenceRule SequenceRule 
        {
            get => sequenceRule;
            set
            {
                sequenceRule = value;
                NotifyPropertyChanged();
            }
        }

        private BogusRule bogusRule;
        public BogusRule BogusRule
        {
            get => bogusRule;
            set
            {
                bogusRule = value;
                NotifyPropertyChanged();
            }
        }

        private RandomIntRule randomIntRule;
        public RandomIntRule RandomIntRule
        {
            get => randomIntRule;
            set
            {
                randomIntRule = value;
                NotifyPropertyChanged();
            }
        }

        private RandomDecimalRule randomDecimalRule;
        public RandomDecimalRule RandomDecimalRule
        {
            get => randomDecimalRule;
            set
            {
                randomDecimalRule = value;
                NotifyPropertyChanged();
            }
        }

        private RandomDateRule randomDateRule;
        public RandomDateRule RandomDateRule
        {
            get => randomDateRule;
            set
            {
                randomDateRule = value;
                NotifyPropertyChanged();
            }
        }

        private FixedDateRule fixedDateRule;
        public FixedDateRule FixedDateRule
        {
            get => fixedDateRule;
            set
            {
                fixedDateRule = value;
                NotifyPropertyChanged();
            }
        }

        private FixedDecimalRule fixedDecimalRule;
        public FixedDecimalRule FixedDecimalRule
        {
            get => fixedDecimalRule;
            set
            {
                fixedDecimalRule = value;
                NotifyPropertyChanged();
            }
        }

        private FixedIntRule fixedIntRule;
        public FixedIntRule FixedIntRule
        {
            get => fixedIntRule;
            set
            {
                fixedIntRule = value;
                NotifyPropertyChanged();
            }
        }

        private FixedStringRule fixedStringRule;
        public FixedStringRule FixedStringRule
        {
            get => fixedStringRule;
            set
            {
                fixedStringRule = value;
                NotifyPropertyChanged();
            }
        }

        public string TableName => Table.ToString();

        public string FieldName => Field.ToString();

        public string RuleName => SequenceRule != null ? SequenceRule.ToString() :
                                  RandomIntRule != null ? RandomIntRule.ToString() :
                                  RandomDecimalRule != null ? RandomDecimalRule.ToString() :
                                  RandomDateRule != null ? RandomDateRule.ToString() :
                                  FixedIntRule != null ? FixedIntRule.ToString() :
                                  FixedDecimalRule != null ? FixedDecimalRule.ToString() :    
                                  FixedDateRule != null ? FixedDateRule.ToString() :
                                  FixedStringRule != null ? FixedStringRule.ToString() :
                                  BogusRule?.ToString();

        public SavedState.Rule ToSaveModel() => new SavedState.Rule
        {
            Table = Table?.LogicalName,
            Field = Field?.LogicalName,
            Bogus = bogusRule == null ? null : new SavedState.Rule.BogusSettings
            {
                Locale = bogusRule.Locale?.Name,
                DataSet = bogusRule.BogusDataSet?.DataSetType?.Name,
                Method = bogusRule.BogusMethod?.Method?.Name
            },
            Sequence = sequenceRule == null ? null : new SavedState.Rule.SequenceSettings
            {
                SequenceStart = sequenceRule.SequenceStart,
                Format = sequenceRule.Format
            },
            RandomInt = randomIntRule == null ? null : new SavedState.Rule.RandomIntSettings
            {
                RangeStart = randomIntRule.RangeStart,
                RangeEnd = randomIntRule.RangeEnd
            },
            RandomDec = randomDecimalRule == null ? null : new SavedState.Rule.RandomDecSettings
            {
                RangeStart = randomDecimalRule.RangeStart,
                RangeEnd = randomDecimalRule.RangeEnd,
                DecimalPlaces = randomDecimalRule.DecimalPlaces
            },
            RandomDate = randomDateRule == null ? null : new SavedState.Rule.RandomDateSettings
            {
                RangeStart = randomDateRule.RangeStart,
                RangeEnd = randomDateRule.RangeEnd
            },
            FixedInt = fixedIntRule == null ? null : new SavedState.Rule.FixedIntSettings
            {
                Value = fixedIntRule.Value
            },
            FixedDec = fixedDecimalRule == null ? null : new SavedState.Rule.FixedDecSettings
            {
                Value = fixedDecimalRule.Value
            },
            FixedString = fixedStringRule == null ? null : new SavedState.Rule.FixedStringSettings
            {
                Value = fixedStringRule.Value
            },
            FixedDate = fixedDateRule == null ? null : new SavedState.Rule.FixedDateSettings
            {
                Value = fixedDateRule.Value
            }
        };
    }
}
