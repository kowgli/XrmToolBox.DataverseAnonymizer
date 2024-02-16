namespace XrmToolBox.DataverseAnonymizer
{
    partial class DataverseAnonymizerPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataverseAnonymizerPluginControl));
            this.cbBogusDataSet = new System.Windows.Forms.ComboBox();
            this.cbBogusMethod = new System.Windows.Forms.ComboBox();
            this.bBogusSample = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbEntity = new System.Windows.Forms.ComboBox();
            this.cbEntityFormat = new System.Windows.Forms.ComboBox();
            this.tbEntityFilter = new System.Windows.Forms.TextBox();
            this.lbTable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAttributeFilter = new System.Windows.Forms.TextBox();
            this.cbAttributeFormat = new System.Windows.Forms.ComboBox();
            this.cbAttribute = new System.Windows.Forms.ComboBox();
            this.gbField = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.gbRule = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSequence = new System.Windows.Forms.TabPage();
            this.tbSequenceFormat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSequenceStartFrom = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tpFakeData = new System.Windows.Forms.TabPage();
            this.cbBogusLocale = new System.Windows.Forms.ComboBox();
            this.gbField.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.gbRule.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpSequence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequenceStartFrom)).BeginInit();
            this.tpFakeData.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbBogusDataSet
            // 
            this.cbBogusDataSet.DisplayMember = "FriendlyName";
            this.cbBogusDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBogusDataSet.FormattingEnabled = true;
            this.cbBogusDataSet.Location = new System.Drawing.Point(261, 37);
            this.cbBogusDataSet.Margin = new System.Windows.Forms.Padding(4);
            this.cbBogusDataSet.Name = "cbBogusDataSet";
            this.cbBogusDataSet.Size = new System.Drawing.Size(124, 27);
            this.cbBogusDataSet.TabIndex = 5;
            this.cbBogusDataSet.SelectedIndexChanged += new System.EventHandler(this.cbBogusDataSet_SelectedIndexChanged);
            // 
            // cbBogusMethod
            // 
            this.cbBogusMethod.DisplayMember = "FriendlyName";
            this.cbBogusMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBogusMethod.FormattingEnabled = true;
            this.cbBogusMethod.Location = new System.Drawing.Point(395, 37);
            this.cbBogusMethod.Margin = new System.Windows.Forms.Padding(4);
            this.cbBogusMethod.Name = "cbBogusMethod";
            this.cbBogusMethod.Size = new System.Drawing.Size(161, 27);
            this.cbBogusMethod.TabIndex = 6;
            // 
            // bBogusSample
            // 
            this.bBogusSample.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBogusSample.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bBogusSample.Location = new System.Drawing.Point(604, 31);
            this.bBogusSample.Margin = new System.Windows.Forms.Padding(4);
            this.bBogusSample.Name = "bBogusSample";
            this.bBogusSample.Size = new System.Drawing.Size(35, 37);
            this.bBogusSample.TabIndex = 7;
            this.bBogusSample.Text = "🗘";
            this.bBogusSample.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bBogusSample.UseVisualStyleBackColor = true;
            this.bBogusSample.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(62, 614);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(693, 87);
            this.textBox1.TabIndex = 8;
            // 
            // cbEntity
            // 
            this.cbEntity.DisplayMember = "Name";
            this.cbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntity.FormattingEnabled = true;
            this.cbEntity.Location = new System.Drawing.Point(16, 56);
            this.cbEntity.Margin = new System.Windows.Forms.Padding(4);
            this.cbEntity.Name = "cbEntity";
            this.cbEntity.Size = new System.Drawing.Size(306, 27);
            this.cbEntity.TabIndex = 9;
            this.cbEntity.SelectedIndexChanged += new System.EventHandler(this.cbEntity_SelectedIndexChanged);
            // 
            // cbEntityFormat
            // 
            this.cbEntityFormat.DisplayMember = "Name";
            this.cbEntityFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntityFormat.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntityFormat.FormattingEnabled = true;
            this.cbEntityFormat.Items.AddRange(new object[] {
            "Logical Name Only",
            "Display Name Only",
            "Logical + Display Name",
            "Display + Logical Name"});
            this.cbEntityFormat.Location = new System.Drawing.Point(16, 91);
            this.cbEntityFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cbEntityFormat.Name = "cbEntityFormat";
            this.cbEntityFormat.Size = new System.Drawing.Size(306, 21);
            this.cbEntityFormat.TabIndex = 10;
            this.cbEntityFormat.SelectedIndexChanged += new System.EventHandler(this.cbEntityFormat_SelectedIndexChanged);
            // 
            // tbEntityFilter
            // 
            this.tbEntityFilter.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEntityFilter.Location = new System.Drawing.Point(134, 27);
            this.tbEntityFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tbEntityFilter.Name = "tbEntityFilter";
            this.tbEntityFilter.Size = new System.Drawing.Size(188, 21);
            this.tbEntityFilter.TabIndex = 11;
            this.tbEntityFilter.TextChanged += new System.EventHandler(this.tbEntityFilter_TextChanged);
            // 
            // lbTable
            // 
            this.lbTable.AutoSize = true;
            this.lbTable.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTable.Location = new System.Drawing.Point(12, 27);
            this.lbTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTable.Name = "lbTable";
            this.lbTable.Size = new System.Drawing.Size(49, 19);
            this.lbTable.TabIndex = 12;
            this.lbTable.Text = "Table:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "🔎";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(450, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "🔎";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(360, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Field:";
            // 
            // tbAttributeFilter
            // 
            this.tbAttributeFilter.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAttributeFilter.Location = new System.Drawing.Point(482, 27);
            this.tbAttributeFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tbAttributeFilter.Name = "tbAttributeFilter";
            this.tbAttributeFilter.Size = new System.Drawing.Size(188, 21);
            this.tbAttributeFilter.TabIndex = 19;
            this.tbAttributeFilter.TextChanged += new System.EventHandler(this.tbAttributeFilter_TextChanged);
            // 
            // cbAttributeFormat
            // 
            this.cbAttributeFormat.DisplayMember = "Name";
            this.cbAttributeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttributeFormat.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAttributeFormat.FormattingEnabled = true;
            this.cbAttributeFormat.Items.AddRange(new object[] {
            "Logical Name Only",
            "Display Name Only",
            "Logical + Display Name",
            "Display + Logical Name"});
            this.cbAttributeFormat.Location = new System.Drawing.Point(364, 91);
            this.cbAttributeFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttributeFormat.Name = "cbAttributeFormat";
            this.cbAttributeFormat.Size = new System.Drawing.Size(306, 21);
            this.cbAttributeFormat.TabIndex = 18;
            this.cbAttributeFormat.SelectedIndexChanged += new System.EventHandler(this.cbAttributeFormat_SelectedIndexChanged);
            // 
            // cbAttribute
            // 
            this.cbAttribute.DisplayMember = "Name";
            this.cbAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAttribute.FormattingEnabled = true;
            this.cbAttribute.Location = new System.Drawing.Point(364, 56);
            this.cbAttribute.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttribute.Name = "cbAttribute";
            this.cbAttribute.Size = new System.Drawing.Size(306, 27);
            this.cbAttribute.TabIndex = 17;
            // 
            // gbField
            // 
            this.gbField.Controls.Add(this.label5);
            this.gbField.Controls.Add(this.label4);
            this.gbField.Controls.Add(this.cbEntity);
            this.gbField.Controls.Add(this.label2);
            this.gbField.Controls.Add(this.cbEntityFormat);
            this.gbField.Controls.Add(this.label3);
            this.gbField.Controls.Add(this.tbEntityFilter);
            this.gbField.Controls.Add(this.tbAttributeFilter);
            this.gbField.Controls.Add(this.lbTable);
            this.gbField.Controls.Add(this.cbAttributeFormat);
            this.gbField.Controls.Add(this.label1);
            this.gbField.Controls.Add(this.cbAttribute);
            this.gbField.Location = new System.Drawing.Point(3, 3);
            this.gbField.Name = "gbField";
            this.gbField.Size = new System.Drawing.Size(679, 129);
            this.gbField.TabIndex = 22;
            this.gbField.TabStop = false;
            this.gbField.Text = "1. Select field";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(482, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Start with star * to use \"contains\" filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(134, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Start with star * to use \"contains\" filter";
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.Controls.Add(this.gbRule);
            this.contentPanel.Controls.Add(this.gbField);
            this.contentPanel.Location = new System.Drawing.Point(11, 14);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1014, 531);
            this.contentPanel.TabIndex = 23;
            // 
            // gbRule
            // 
            this.gbRule.Controls.Add(this.tabControl1);
            this.gbRule.Location = new System.Drawing.Point(3, 147);
            this.gbRule.Name = "gbRule";
            this.gbRule.Size = new System.Drawing.Size(679, 156);
            this.gbRule.TabIndex = 23;
            this.gbRule.TabStop = false;
            this.gbRule.Text = "2. Set anonymization rule";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSequence);
            this.tabControl1.Controls.Add(this.tpFakeData);
            this.tabControl1.Location = new System.Drawing.Point(16, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 115);
            this.tabControl1.TabIndex = 0;
            // 
            // tpSequence
            // 
            this.tpSequence.Controls.Add(this.tbSequenceFormat);
            this.tpSequence.Controls.Add(this.label7);
            this.tpSequence.Controls.Add(this.nudSequenceStartFrom);
            this.tpSequence.Controls.Add(this.label6);
            this.tpSequence.Location = new System.Drawing.Point(4, 28);
            this.tpSequence.Name = "tpSequence";
            this.tpSequence.Padding = new System.Windows.Forms.Padding(3);
            this.tpSequence.Size = new System.Drawing.Size(646, 83);
            this.tpSequence.TabIndex = 0;
            this.tpSequence.Text = "Sequence";
            this.tpSequence.UseVisualStyleBackColor = true;
            // 
            // tbSequenceFormat
            // 
            this.tbSequenceFormat.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSequenceFormat.Location = new System.Drawing.Point(186, 39);
            this.tbSequenceFormat.Name = "tbSequenceFormat";
            this.tbSequenceFormat.Size = new System.Drawing.Size(443, 26);
            this.tbSequenceFormat.TabIndex = 28;
            this.tbSequenceFormat.Text = "Account {SEQ}";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(182, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 27;
            this.label7.Text = "Format:";
            // 
            // nudSequenceStartFrom
            // 
            this.nudSequenceStartFrom.Location = new System.Drawing.Point(11, 40);
            this.nudSequenceStartFrom.Name = "nudSequenceStartFrom";
            this.nudSequenceStartFrom.Size = new System.Drawing.Size(120, 27);
            this.nudSequenceStartFrom.TabIndex = 26;
            this.nudSequenceStartFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 25;
            this.label6.Text = "Start from:";
            // 
            // tpFakeData
            // 
            this.tpFakeData.Controls.Add(this.cbBogusLocale);
            this.tpFakeData.Controls.Add(this.cbBogusDataSet);
            this.tpFakeData.Controls.Add(this.cbBogusMethod);
            this.tpFakeData.Controls.Add(this.bBogusSample);
            this.tpFakeData.Location = new System.Drawing.Point(4, 28);
            this.tpFakeData.Name = "tpFakeData";
            this.tpFakeData.Padding = new System.Windows.Forms.Padding(3);
            this.tpFakeData.Size = new System.Drawing.Size(646, 83);
            this.tpFakeData.TabIndex = 1;
            this.tpFakeData.Text = "Fake data";
            this.tpFakeData.UseVisualStyleBackColor = true;
            // 
            // cbBogusLocale
            // 
            this.cbBogusLocale.DisplayMember = "FriendlyName";
            this.cbBogusLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBogusLocale.FormattingEnabled = true;
            this.cbBogusLocale.Location = new System.Drawing.Point(17, 37);
            this.cbBogusLocale.Margin = new System.Windows.Forms.Padding(4);
            this.cbBogusLocale.Name = "cbBogusLocale";
            this.cbBogusLocale.Size = new System.Drawing.Size(189, 27);
            this.cbBogusLocale.TabIndex = 8;
            // 
            // DataverseAnonymizerPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataverseAnonymizerPluginControl";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(1037, 728);
            this.Load += new System.EventHandler(this.DataverseAnonymizerPluginControl_Load);
            this.gbField.ResumeLayout(false);
            this.gbField.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.gbRule.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpSequence.ResumeLayout(false);
            this.tpSequence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequenceStartFrom)).EndInit();
            this.tpFakeData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbBogusDataSet;
        private System.Windows.Forms.ComboBox cbBogusMethod;
        private System.Windows.Forms.Button bBogusSample;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbEntity;
        private System.Windows.Forms.ComboBox cbEntityFormat;
        private System.Windows.Forms.TextBox tbEntityFilter;
        private System.Windows.Forms.Label lbTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAttributeFilter;
        private System.Windows.Forms.ComboBox cbAttributeFormat;
        private System.Windows.Forms.ComboBox cbAttribute;
        private System.Windows.Forms.GroupBox gbField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.GroupBox gbRule;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSequence;
        private System.Windows.Forms.TextBox tbSequenceFormat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSequenceStartFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tpFakeData;
        private System.Windows.Forms.ComboBox cbBogusLocale;
    }
}
