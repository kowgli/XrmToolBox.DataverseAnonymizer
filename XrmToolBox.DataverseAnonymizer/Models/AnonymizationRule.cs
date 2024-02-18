using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XrmToolBox.DataverseAnonymizer.Models
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


        public string TableName => Table.ToString();

        public string FieldName => Field.ToString();

        public string RuleName => SequenceRule != null ? SequenceRule.ToString() : BogusRule?.ToString(); 
    }
}
