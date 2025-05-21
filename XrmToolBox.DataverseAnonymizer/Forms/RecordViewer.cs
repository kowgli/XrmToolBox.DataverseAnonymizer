using System;
using System.Windows.Forms;
using XrmToolBox.DataverseAnonymizer.Models;

namespace XrmToolBox.DataverseAnonymizer.Forms
{
    public partial class RecordViewer : Form
    {
        public CrmRecord[] Records { get; private set; }

        public RecordViewer(CrmRecord[] records)
        {
            InitializeComponent();
            this.Records = records;
        }

        private void RecordViewer_Load(object sender, EventArgs e)
        {
            dgvRecords.AutoGenerateColumns = false;

            if (Records != null)
            {
                lbResults.Text = string.Format(lbResults.Text, Records.Length);
                dgvRecords.DataSource = Records;
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
