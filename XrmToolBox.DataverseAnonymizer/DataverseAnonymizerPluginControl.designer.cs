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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBogusDataSet = new System.Windows.Forms.ComboBox();
            this.comboBogusMethod = new System.Windows.Forms.ComboBox();
            this.bBogusSample = new System.Windows.Forms.Button();
            this.tbBogusSample = new System.Windows.Forms.TextBox();
            this.comboTable = new System.Windows.Forms.ComboBox();
            this.comboTableFormat = new System.Windows.Forms.ComboBox();
            this.tbTableFilter = new System.Windows.Forms.TextBox();
            this.lbTable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFieldFilter = new System.Windows.Forms.TextBox();
            this.comboFieldFormat = new System.Windows.Forms.ComboBox();
            this.comboField = new System.Windows.Forms.ComboBox();
            this.gbField = new System.Windows.Forms.GroupBox();
            this.labelFilterInfo = new System.Windows.Forms.Label();
            this.bExpandFetchXml = new System.Windows.Forms.Button();
            this.tbFetchXml = new System.Windows.Forms.TextBox();
            this.rbFilterFetchXml = new System.Windows.Forms.RadioButton();
            this.rbFilterNone = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.bClearFieldFilter = new System.Windows.Forms.Button();
            this.bClearTableFilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbRun = new System.Windows.Forms.GroupBox();
            this.llBypassHelp = new System.Windows.Forms.LinkLabel();
            this.nudBatchSize = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbBypassFlows = new System.Windows.Forms.CheckBox();
            this.cbBypassPlugins = new System.Windows.Forms.CheckBox();
            this.bRun = new System.Windows.Forms.Button();
            this.gbRule = new System.Windows.Forms.GroupBox();
            this.llBogus = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.tabcRule = new System.Windows.Forms.TabControl();
            this.tpSequence = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSequenceFormat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSequenceStartFrom = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tpFakeData = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBogusLocale = new System.Windows.Forms.ComboBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.gbField.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            this.gbRun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBatchSize)).BeginInit();
            this.gbRule.SuspendLayout();
            this.tabcRule.SuspendLayout();
            this.tpSequence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequenceStartFrom)).BeginInit();
            this.tpFakeData.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBogusDataSet
            // 
            this.comboBogusDataSet.DisplayMember = "FriendlyName";
            this.comboBogusDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBogusDataSet.FormattingEnabled = true;
            this.comboBogusDataSet.Location = new System.Drawing.Point(234, 37);
            this.comboBogusDataSet.Margin = new System.Windows.Forms.Padding(4);
            this.comboBogusDataSet.Name = "comboBogusDataSet";
            this.comboBogusDataSet.Size = new System.Drawing.Size(190, 27);
            this.comboBogusDataSet.TabIndex = 5;
            this.comboBogusDataSet.SelectedIndexChanged += new System.EventHandler(this.comboBogusDataSet_SelectedIndexChanged);
            // 
            // comboBogusMethod
            // 
            this.comboBogusMethod.DisplayMember = "FriendlyName";
            this.comboBogusMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBogusMethod.FormattingEnabled = true;
            this.comboBogusMethod.Location = new System.Drawing.Point(449, 37);
            this.comboBogusMethod.Margin = new System.Windows.Forms.Padding(4);
            this.comboBogusMethod.Name = "comboBogusMethod";
            this.comboBogusMethod.Size = new System.Drawing.Size(190, 27);
            this.comboBogusMethod.TabIndex = 6;
            this.comboBogusMethod.SelectedIndexChanged += new System.EventHandler(this.comboBogusMethod_SelectedIndexChanged);
            // 
            // bBogusSample
            // 
            this.bBogusSample.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBogusSample.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bBogusSample.Location = new System.Drawing.Point(607, 81);
            this.bBogusSample.Margin = new System.Windows.Forms.Padding(4);
            this.bBogusSample.Name = "bBogusSample";
            this.bBogusSample.Size = new System.Drawing.Size(35, 37);
            this.bBogusSample.TabIndex = 7;
            this.bBogusSample.Text = "🗘";
            this.bBogusSample.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bBogusSample.UseVisualStyleBackColor = true;
            this.bBogusSample.Click += new System.EventHandler(this.bBogusSample_Click);
            // 
            // tbBogusSample
            // 
            this.tbBogusSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBogusSample.Location = new System.Drawing.Point(86, 87);
            this.tbBogusSample.Margin = new System.Windows.Forms.Padding(4);
            this.tbBogusSample.Name = "tbBogusSample";
            this.tbBogusSample.ReadOnly = true;
            this.tbBogusSample.Size = new System.Drawing.Size(513, 27);
            this.tbBogusSample.TabIndex = 8;
            // 
            // comboTable
            // 
            this.comboTable.DisplayMember = "Name";
            this.comboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTable.FormattingEnabled = true;
            this.comboTable.Location = new System.Drawing.Point(16, 56);
            this.comboTable.Margin = new System.Windows.Forms.Padding(4);
            this.comboTable.Name = "comboTable";
            this.comboTable.Size = new System.Drawing.Size(306, 27);
            this.comboTable.TabIndex = 9;
            this.comboTable.SelectedIndexChanged += new System.EventHandler(this.comboTable_SelectedIndexChanged);
            // 
            // comboTableFormat
            // 
            this.comboTableFormat.DisplayMember = "Name";
            this.comboTableFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTableFormat.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTableFormat.FormattingEnabled = true;
            this.comboTableFormat.Items.AddRange(new object[] {
            "Logical Name Only",
            "Display Name Only",
            "Logical + Display Name",
            "Display + Logical Name"});
            this.comboTableFormat.Location = new System.Drawing.Point(16, 91);
            this.comboTableFormat.Margin = new System.Windows.Forms.Padding(4);
            this.comboTableFormat.Name = "comboTableFormat";
            this.comboTableFormat.Size = new System.Drawing.Size(306, 21);
            this.comboTableFormat.TabIndex = 10;
            this.comboTableFormat.SelectedIndexChanged += new System.EventHandler(this.comboTableFormat_SelectedIndexChanged);
            // 
            // tbTableFilter
            // 
            this.tbTableFilter.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTableFilter.Location = new System.Drawing.Point(134, 27);
            this.tbTableFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tbTableFilter.Name = "tbTableFilter";
            this.tbTableFilter.Size = new System.Drawing.Size(163, 21);
            this.tbTableFilter.TabIndex = 11;
            this.tbTableFilter.TextChanged += new System.EventHandler(this.tbTableFilter_TextChanged);
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
            // tbFieldFilter
            // 
            this.tbFieldFilter.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFieldFilter.Location = new System.Drawing.Point(482, 27);
            this.tbFieldFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tbFieldFilter.Name = "tbFieldFilter";
            this.tbFieldFilter.Size = new System.Drawing.Size(166, 21);
            this.tbFieldFilter.TabIndex = 19;
            this.tbFieldFilter.TextChanged += new System.EventHandler(this.tbFieldFilter_TextChanged);
            // 
            // comboFieldFormat
            // 
            this.comboFieldFormat.DisplayMember = "Name";
            this.comboFieldFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFieldFormat.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFieldFormat.FormattingEnabled = true;
            this.comboFieldFormat.Items.AddRange(new object[] {
            "Logical Name Only",
            "Display Name Only",
            "Logical + Display Name",
            "Display + Logical Name"});
            this.comboFieldFormat.Location = new System.Drawing.Point(364, 91);
            this.comboFieldFormat.Margin = new System.Windows.Forms.Padding(4);
            this.comboFieldFormat.Name = "comboFieldFormat";
            this.comboFieldFormat.Size = new System.Drawing.Size(306, 21);
            this.comboFieldFormat.TabIndex = 18;
            this.comboFieldFormat.SelectedIndexChanged += new System.EventHandler(this.comboFieldFormat_SelectedIndexChanged);
            // 
            // comboField
            // 
            this.comboField.DisplayMember = "Name";
            this.comboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboField.FormattingEnabled = true;
            this.comboField.Location = new System.Drawing.Point(364, 56);
            this.comboField.Margin = new System.Windows.Forms.Padding(4);
            this.comboField.Name = "comboField";
            this.comboField.Size = new System.Drawing.Size(306, 27);
            this.comboField.TabIndex = 17;
            // 
            // gbField
            // 
            this.gbField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbField.Controls.Add(this.labelFilterInfo);
            this.gbField.Controls.Add(this.bExpandFetchXml);
            this.gbField.Controls.Add(this.tbFetchXml);
            this.gbField.Controls.Add(this.rbFilterFetchXml);
            this.gbField.Controls.Add(this.rbFilterNone);
            this.gbField.Controls.Add(this.label16);
            this.gbField.Controls.Add(this.bClearFieldFilter);
            this.gbField.Controls.Add(this.bClearTableFilter);
            this.gbField.Controls.Add(this.label5);
            this.gbField.Controls.Add(this.label4);
            this.gbField.Controls.Add(this.comboTable);
            this.gbField.Controls.Add(this.label2);
            this.gbField.Controls.Add(this.comboTableFormat);
            this.gbField.Controls.Add(this.label3);
            this.gbField.Controls.Add(this.tbTableFilter);
            this.gbField.Controls.Add(this.tbFieldFilter);
            this.gbField.Controls.Add(this.lbTable);
            this.gbField.Controls.Add(this.comboFieldFormat);
            this.gbField.Controls.Add(this.label1);
            this.gbField.Controls.Add(this.comboField);
            this.gbField.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbField.Location = new System.Drawing.Point(3, 3);
            this.gbField.MinimumSize = new System.Drawing.Size(679, 224);
            this.gbField.Name = "gbField";
            this.gbField.Size = new System.Drawing.Size(679, 224);
            this.gbField.TabIndex = 22;
            this.gbField.TabStop = false;
            this.gbField.Text = "1. Select field";
            // 
            // labelFilterInfo
            // 
            this.labelFilterInfo.AutoSize = true;
            this.labelFilterInfo.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilterInfo.ForeColor = System.Drawing.Color.Red;
            this.labelFilterInfo.Location = new System.Drawing.Point(361, 140);
            this.labelFilterInfo.Name = "labelFilterInfo";
            this.labelFilterInfo.Size = new System.Drawing.Size(232, 17);
            this.labelFilterInfo.TabIndex = 30;
            this.labelFilterInfo.Text = "Applies to all rules for the selected table";
            this.labelFilterInfo.Visible = false;
            // 
            // bExpandFetchXml
            // 
            this.bExpandFetchXml.Location = new System.Drawing.Point(642, 138);
            this.bExpandFetchXml.Name = "bExpandFetchXml";
            this.bExpandFetchXml.Size = new System.Drawing.Size(24, 23);
            this.bExpandFetchXml.TabIndex = 31;
            this.bExpandFetchXml.Text = "⛶";
            this.bExpandFetchXml.UseCompatibleTextRendering = true;
            this.bExpandFetchXml.UseVisualStyleBackColor = true;
            this.bExpandFetchXml.Visible = false;
            // 
            // tbFetchXml
            // 
            this.tbFetchXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFetchXml.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFetchXml.Location = new System.Drawing.Point(16, 165);
            this.tbFetchXml.Multiline = true;
            this.tbFetchXml.Name = "tbFetchXml";
            this.tbFetchXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFetchXml.Size = new System.Drawing.Size(650, 48);
            this.tbFetchXml.TabIndex = 30;
            this.tbFetchXml.Text = resources.GetString("tbFetchXml.Text");
            this.tbFetchXml.Visible = false;
            // 
            // rbFilterFetchXml
            // 
            this.rbFilterFetchXml.AutoSize = true;
            this.rbFilterFetchXml.Location = new System.Drawing.Point(203, 136);
            this.rbFilterFetchXml.Name = "rbFilterFetchXml";
            this.rbFilterFetchXml.Size = new System.Drawing.Size(94, 23);
            this.rbFilterFetchXml.TabIndex = 29;
            this.rbFilterFetchXml.Text = "Fetch XML";
            this.rbFilterFetchXml.UseVisualStyleBackColor = true;
            this.rbFilterFetchXml.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
            // 
            // rbFilterNone
            // 
            this.rbFilterNone.AutoSize = true;
            this.rbFilterNone.Checked = true;
            this.rbFilterNone.Location = new System.Drawing.Point(116, 136);
            this.rbFilterNone.Name = "rbFilterNone";
            this.rbFilterNone.Size = new System.Drawing.Size(61, 23);
            this.rbFilterNone.TabIndex = 28;
            this.rbFilterNone.TabStop = true;
            this.rbFilterNone.Text = "None";
            this.rbFilterNone.UseVisualStyleBackColor = true;
            this.rbFilterNone.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 138);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 19);
            this.label16.TabIndex = 27;
            this.label16.Text = "Filter:";
            // 
            // bClearFieldFilter
            // 
            this.bClearFieldFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClearFieldFilter.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClearFieldFilter.Location = new System.Drawing.Point(642, 27);
            this.bClearFieldFilter.Name = "bClearFieldFilter";
            this.bClearFieldFilter.Size = new System.Drawing.Size(27, 21);
            this.bClearFieldFilter.TabIndex = 26;
            this.bClearFieldFilter.Text = "x";
            this.bClearFieldFilter.UseCompatibleTextRendering = true;
            this.bClearFieldFilter.UseVisualStyleBackColor = true;
            this.bClearFieldFilter.Click += new System.EventHandler(this.bClearFieldFilter_Click);
            // 
            // bClearTableFilter
            // 
            this.bClearTableFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClearTableFilter.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClearTableFilter.Location = new System.Drawing.Point(295, 27);
            this.bClearTableFilter.Name = "bClearTableFilter";
            this.bClearTableFilter.Size = new System.Drawing.Size(27, 21);
            this.bClearTableFilter.TabIndex = 25;
            this.bClearTableFilter.Text = "x";
            this.bClearTableFilter.UseCompatibleTextRendering = true;
            this.bClearTableFilter.UseVisualStyleBackColor = true;
            this.bClearTableFilter.Click += new System.EventHandler(this.bClearTableFilter_Click);
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
            this.contentPanel.Controls.Add(this.dgvRules);
            this.contentPanel.Controls.Add(this.gbRun);
            this.contentPanel.Controls.Add(this.gbRule);
            this.contentPanel.Controls.Add(this.gbField);
            this.contentPanel.Location = new System.Drawing.Point(11, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1128, 626);
            this.contentPanel.TabIndex = 23;
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToAddRows = false;
            this.dgvRules.AllowUserToDeleteRows = false;
            this.dgvRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRules.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTableName,
            this.colFieldName,
            this.colRuleName,
            this.colEdit,
            this.colDelete});
            this.dgvRules.Location = new System.Drawing.Point(688, 13);
            this.dgvRules.MultiSelect = false;
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowHeadersVisible = false;
            this.dgvRules.RowTemplate.Height = 30;
            this.dgvRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRules.Size = new System.Drawing.Size(429, 603);
            this.dgvRules.TabIndex = 26;
            this.dgvRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellClick);
            // 
            // colTableName
            // 
            this.colTableName.DataPropertyName = "TableName";
            this.colTableName.HeaderText = "Table";
            this.colTableName.Name = "colTableName";
            this.colTableName.ReadOnly = true;
            this.colTableName.Width = 69;
            // 
            // colFieldName
            // 
            this.colFieldName.DataPropertyName = "FieldName";
            this.colFieldName.HeaderText = "Field";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.ReadOnly = true;
            this.colFieldName.Width = 65;
            // 
            // colRuleName
            // 
            this.colRuleName.DataPropertyName = "RuleName";
            this.colRuleName.HeaderText = "Rule";
            this.colRuleName.Name = "colRuleName";
            this.colRuleName.ReadOnly = true;
            this.colRuleName.Width = 63;
            // 
            // colEdit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Edit";
            this.colEdit.DefaultCellStyle = dataGridViewCellStyle1;
            this.colEdit.HeaderText = "Edit";
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 40;
            // 
            // colDelete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Delete";
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDelete.HeaderText = "Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.Width = 58;
            // 
            // gbRun
            // 
            this.gbRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbRun.Controls.Add(this.llBypassHelp);
            this.gbRun.Controls.Add(this.nudBatchSize);
            this.gbRun.Controls.Add(this.label15);
            this.gbRun.Controls.Add(this.label14);
            this.gbRun.Controls.Add(this.cbBypassFlows);
            this.gbRun.Controls.Add(this.cbBypassPlugins);
            this.gbRun.Controls.Add(this.bRun);
            this.gbRun.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRun.Location = new System.Drawing.Point(3, 482);
            this.gbRun.MinimumSize = new System.Drawing.Size(679, 135);
            this.gbRun.Name = "gbRun";
            this.gbRun.Size = new System.Drawing.Size(679, 135);
            this.gbRun.TabIndex = 25;
            this.gbRun.TabStop = false;
            this.gbRun.Text = "3. Run";
            // 
            // llBypassHelp
            // 
            this.llBypassHelp.AutoSize = true;
            this.llBypassHelp.Location = new System.Drawing.Point(555, 30);
            this.llBypassHelp.Name = "llBypassHelp";
            this.llBypassHelp.Size = new System.Drawing.Size(115, 19);
            this.llBypassHelp.TabIndex = 3;
            this.llBypassHelp.TabStop = true;
            this.llBypassHelp.Text = "MS Learn Article";
            this.llBypassHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llBypassHelp_LinkClicked);
            // 
            // nudBatchSize
            // 
            this.nudBatchSize.Location = new System.Drawing.Point(99, 93);
            this.nudBatchSize.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudBatchSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBatchSize.Name = "nudBatchSize";
            this.nudBatchSize.Size = new System.Drawing.Size(120, 27);
            this.nudBatchSize.TabIndex = 29;
            this.nudBatchSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 95);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 19);
            this.label15.TabIndex = 26;
            this.label15.Text = "Batch size:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(13, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(508, 17);
            this.label14.TabIndex = 3;
            this.label14.Text = "Warning! Asynchronous Plugins and Workflows can\'t be bypassed. Disable them manua" +
    "lly.";
            // 
            // cbBypassFlows
            // 
            this.cbBypassFlows.AutoSize = true;
            this.cbBypassFlows.Checked = true;
            this.cbBypassFlows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBypassFlows.Location = new System.Drawing.Point(356, 29);
            this.cbBypassFlows.Name = "cbBypassFlows";
            this.cbBypassFlows.Size = new System.Drawing.Size(115, 23);
            this.cbBypassFlows.TabIndex = 2;
            this.cbBypassFlows.Text = "Bypass Flows";
            this.cbBypassFlows.UseVisualStyleBackColor = true;
            // 
            // cbBypassPlugins
            // 
            this.cbBypassPlugins.AutoSize = true;
            this.cbBypassPlugins.Checked = true;
            this.cbBypassPlugins.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBypassPlugins.Location = new System.Drawing.Point(16, 29);
            this.cbBypassPlugins.Name = "cbBypassPlugins";
            this.cbBypassPlugins.Size = new System.Drawing.Size(309, 23);
            this.cbBypassPlugins.TabIndex = 1;
            this.cbBypassPlugins.Text = "Bypass synchronous Plugins and Workflows";
            this.cbBypassPlugins.UseVisualStyleBackColor = true;
            // 
            // bRun
            // 
            this.bRun.BackColor = System.Drawing.Color.Chartreuse;
            this.bRun.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRun.Location = new System.Drawing.Point(389, 85);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(132, 36);
            this.bRun.TabIndex = 0;
            this.bRun.Text = "Run";
            this.bRun.UseVisualStyleBackColor = false;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // gbRule
            // 
            this.gbRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbRule.Controls.Add(this.llBogus);
            this.gbRule.Controls.Add(this.label12);
            this.gbRule.Controls.Add(this.tabcRule);
            this.gbRule.Controls.Add(this.bSave);
            this.gbRule.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRule.Location = new System.Drawing.Point(3, 233);
            this.gbRule.MinimumSize = new System.Drawing.Size(679, 243);
            this.gbRule.Name = "gbRule";
            this.gbRule.Size = new System.Drawing.Size(679, 243);
            this.gbRule.TabIndex = 23;
            this.gbRule.TabStop = false;
            this.gbRule.Text = "2. Set anonymization rule";
            // 
            // llBogus
            // 
            this.llBogus.AutoSize = true;
            this.llBogus.Location = new System.Drawing.Point(478, 208);
            this.llBogus.Name = "llBogus";
            this.llBogus.Size = new System.Drawing.Size(194, 19);
            this.llBogus.TabIndex = 2;
            this.llBogus.TabStop = true;
            this.llBogus.Text = "Fake data provided by Bogus";
            this.llBogus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llBogus_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(154, 211);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(251, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Creates or replaces a rule for the selected field.";
            // 
            // tabcRule
            // 
            this.tabcRule.Controls.Add(this.tpSequence);
            this.tabcRule.Controls.Add(this.tpFakeData);
            this.tabcRule.Location = new System.Drawing.Point(16, 26);
            this.tabcRule.Name = "tabcRule";
            this.tabcRule.SelectedIndex = 0;
            this.tabcRule.Size = new System.Drawing.Size(654, 157);
            this.tabcRule.TabIndex = 0;
            // 
            // tpSequence
            // 
            this.tpSequence.Controls.Add(this.label13);
            this.tpSequence.Controls.Add(this.tbSequenceFormat);
            this.tpSequence.Controls.Add(this.label7);
            this.tpSequence.Controls.Add(this.nudSequenceStartFrom);
            this.tpSequence.Controls.Add(this.label6);
            this.tpSequence.Location = new System.Drawing.Point(4, 28);
            this.tpSequence.Name = "tpSequence";
            this.tpSequence.Padding = new System.Windows.Forms.Padding(3);
            this.tpSequence.Size = new System.Drawing.Size(646, 125);
            this.tpSequence.TabIndex = 0;
            this.tpSequence.Text = "Sequence";
            this.tpSequence.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(183, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(265, 45);
            this.label13.TabIndex = 2;
            this.label13.Text = "{SEQ} will be replaced with the sequence number.\r\nFor example \"My {SEQ} test\" wil" +
    "l become:\r\n\"My 1 test\", \"My 2 test\", (...) ";
            // 
            // tbSequenceFormat
            // 
            this.tbSequenceFormat.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSequenceFormat.Location = new System.Drawing.Point(186, 36);
            this.tbSequenceFormat.Name = "tbSequenceFormat";
            this.tbSequenceFormat.Size = new System.Drawing.Size(443, 26);
            this.tbSequenceFormat.TabIndex = 28;
            this.tbSequenceFormat.Text = "Account {SEQ}";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(182, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 27;
            this.label7.Text = "Format:";
            // 
            // nudSequenceStartFrom
            // 
            this.nudSequenceStartFrom.Location = new System.Drawing.Point(17, 37);
            this.nudSequenceStartFrom.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
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
            this.label6.Location = new System.Drawing.Point(13, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 25;
            this.label6.Text = "Start from:";
            // 
            // tpFakeData
            // 
            this.tpFakeData.Controls.Add(this.label11);
            this.tpFakeData.Controls.Add(this.tbBogusSample);
            this.tpFakeData.Controls.Add(this.label10);
            this.tpFakeData.Controls.Add(this.label9);
            this.tpFakeData.Controls.Add(this.label8);
            this.tpFakeData.Controls.Add(this.comboBogusLocale);
            this.tpFakeData.Controls.Add(this.comboBogusDataSet);
            this.tpFakeData.Controls.Add(this.comboBogusMethod);
            this.tpFakeData.Controls.Add(this.bBogusSample);
            this.tpFakeData.Location = new System.Drawing.Point(4, 28);
            this.tpFakeData.Name = "tpFakeData";
            this.tpFakeData.Padding = new System.Windows.Forms.Padding(3);
            this.tpFakeData.Size = new System.Drawing.Size(646, 125);
            this.tpFakeData.TabIndex = 1;
            this.tpFakeData.Text = "Fake data";
            this.tpFakeData.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 90);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 19);
            this.label11.TabIndex = 28;
            this.label11.Text = "Sample:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(445, 10);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 19);
            this.label10.TabIndex = 27;
            this.label10.Text = "Data type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(230, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 19);
            this.label9.TabIndex = 26;
            this.label9.Text = "Data set:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 19);
            this.label8.TabIndex = 25;
            this.label8.Text = "Language:";
            // 
            // comboBogusLocale
            // 
            this.comboBogusLocale.DisplayMember = "FriendlyName";
            this.comboBogusLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBogusLocale.FormattingEnabled = true;
            this.comboBogusLocale.Location = new System.Drawing.Point(17, 37);
            this.comboBogusLocale.Margin = new System.Windows.Forms.Padding(4);
            this.comboBogusLocale.Name = "comboBogusLocale";
            this.comboBogusLocale.Size = new System.Drawing.Size(190, 27);
            this.comboBogusLocale.TabIndex = 8;
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.Location = new System.Drawing.Point(16, 198);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(132, 36);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bStop
            // 
            this.bStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bStop.BackColor = System.Drawing.Color.Yellow;
            this.bStop.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStop.ForeColor = System.Drawing.Color.Red;
            this.bStop.Location = new System.Drawing.Point(0, 0);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(1151, 53);
            this.bStop.TabIndex = 24;
            this.bStop.Text = "STOP";
            this.bStop.UseVisualStyleBackColor = false;
            this.bStop.Visible = false;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // DataverseAnonymizerPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.bStop);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataverseAnonymizerPluginControl";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(1151, 631);
            this.Load += new System.EventHandler(this.DataverseAnonymizerPluginControl_Load);
            this.gbField.ResumeLayout(false);
            this.gbField.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            this.gbRun.ResumeLayout(false);
            this.gbRun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBatchSize)).EndInit();
            this.gbRule.ResumeLayout(false);
            this.gbRule.PerformLayout();
            this.tabcRule.ResumeLayout(false);
            this.tpSequence.ResumeLayout(false);
            this.tpSequence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequenceStartFrom)).EndInit();
            this.tpFakeData.ResumeLayout(false);
            this.tpFakeData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBogusDataSet;
        private System.Windows.Forms.ComboBox comboBogusMethod;
        private System.Windows.Forms.Button bBogusSample;
        private System.Windows.Forms.TextBox tbBogusSample;
        private System.Windows.Forms.ComboBox comboTable;
        private System.Windows.Forms.ComboBox comboTableFormat;
        private System.Windows.Forms.TextBox tbTableFilter;
        private System.Windows.Forms.Label lbTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFieldFilter;
        private System.Windows.Forms.ComboBox comboFieldFormat;
        private System.Windows.Forms.ComboBox comboField;
        private System.Windows.Forms.GroupBox gbField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.GroupBox gbRule;
        private System.Windows.Forms.TabControl tabcRule;
        private System.Windows.Forms.TabPage tpSequence;
        private System.Windows.Forms.TextBox tbSequenceFormat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSequenceStartFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tpFakeData;
        private System.Windows.Forms.ComboBox comboBogusLocale;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbRun;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.DataGridView dgvRules;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbBypassPlugins;
        private System.Windows.Forms.CheckBox cbBypassFlows;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudBatchSize;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuleName;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.LinkLabel llBogus;
        private System.Windows.Forms.LinkLabel llBypassHelp;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bClearTableFilter;
        private System.Windows.Forms.Button bClearFieldFilter;
        private System.Windows.Forms.TextBox tbFetchXml;
        private System.Windows.Forms.RadioButton rbFilterFetchXml;
        private System.Windows.Forms.RadioButton rbFilterNone;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button bExpandFetchXml;
        private System.Windows.Forms.Label labelFilterInfo;
    }
}
