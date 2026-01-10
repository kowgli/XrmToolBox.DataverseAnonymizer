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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataverseAnonymizerPluginControl));
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
            this.bTestFilter = new System.Windows.Forms.Button();
            this.bFetchXmlBuilder = new System.Windows.Forms.Button();
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
            this.bSkipProcessedRecordsPath = new System.Windows.Forms.Button();
            this.bStoreProcessedRecordsPath = new System.Windows.Forms.Button();
            this.tbSkipProcessedRecordsPath = new System.Windows.Forms.TextBox();
            this.tbStoreProcessedRecordsPath = new System.Windows.Forms.TextBox();
            this.cbSkipProcessedRecords = new System.Windows.Forms.CheckBox();
            this.cbStoreProcessedRecords = new System.Windows.Forms.CheckBox();
            this.cbBypassAsync = new System.Windows.Forms.CheckBox();
            this.nudThreads = new System.Windows.Forms.NumericUpDown();
            this.lbThreads = new System.Windows.Forms.Label();
            this.llBypassHelp = new System.Windows.Forms.LinkLabel();
            this.nudBatchSize = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.cbBypassFlows = new System.Windows.Forms.CheckBox();
            this.cbBypassSync = new System.Windows.Forms.CheckBox();
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
            this.tpRandomInt = new System.Windows.Forms.TabPage();
            this.lbRandomIntSample = new System.Windows.Forms.Label();
            this.tbRandomIntSample = new System.Windows.Forms.TextBox();
            this.bRandomIntSample = new System.Windows.Forms.Button();
            this.nudRandomIntRangeTo = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.nudRandomIntRangeFrom = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.tpRandomDec = new System.Windows.Forms.TabPage();
            this.nudRandomDecDecimals = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.lbRandomDecSample = new System.Windows.Forms.Label();
            this.tbRandomDecSample = new System.Windows.Forms.TextBox();
            this.bRandomDecSample = new System.Windows.Forms.Button();
            this.nudRandomDecRangeTo = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.nudRandomDecRangeFrom = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.tpRandomDate = new System.Windows.Forms.TabPage();
            this.dtpRandomDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpRandomDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lbRandomDateSample = new System.Windows.Forms.Label();
            this.tbRandomDateSample = new System.Windows.Forms.TextBox();
            this.bRandomDateSample = new System.Windows.Forms.Button();
            this.lbRandomDateTo = new System.Windows.Forms.Label();
            this.lbRandomDateFrom = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bStop = new System.Windows.Forms.Button();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.ttbSave = new System.Windows.Forms.ToolStripButton();
            this.ttbLoad = new System.Windows.Forms.ToolStripButton();
            this.ttbFeedback = new System.Windows.Forms.ToolStripButton();
            this.tslVersion = new System.Windows.Forms.ToolStripLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTipDelay0 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.gbField.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            this.gbRun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBatchSize)).BeginInit();
            this.gbRule.SuspendLayout();
            this.tabcRule.SuspendLayout();
            this.tpSequence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequenceStartFrom)).BeginInit();
            this.tpFakeData.SuspendLayout();
            this.tpRandomInt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomIntRangeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomIntRangeFrom)).BeginInit();
            this.tpRandomDec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomDecDecimals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomDecRangeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomDecRangeFrom)).BeginInit();
            this.tpRandomDate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBogusDataSet
            // 
            this.comboBogusDataSet.DisplayMember = "FriendlyName";
            this.comboBogusDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBogusDataSet.FormattingEnabled = true;
            this.comboBogusDataSet.Location = new System.Drawing.Point(225, 37);
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
            this.comboBogusMethod.Location = new System.Drawing.Point(433, 37);
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
            this.bBogusSample.Location = new System.Drawing.Point(589, 81);
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
            this.tbBogusSample.Size = new System.Drawing.Size(495, 27);
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
            this.comboTable.TabIndex = 2;
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
            this.comboTableFormat.TabIndex = 3;
            this.comboTableFormat.SelectedIndexChanged += new System.EventHandler(this.comboTableFormat_SelectedIndexChanged);
            // 
            // tbTableFilter
            // 
            this.tbTableFilter.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTableFilter.Location = new System.Drawing.Point(134, 27);
            this.tbTableFilter.Margin = new System.Windows.Forms.Padding(4);
            this.tbTableFilter.Name = "tbTableFilter";
            this.tbTableFilter.Size = new System.Drawing.Size(163, 21);
            this.tbTableFilter.TabIndex = 0;
            this.tbTableFilter.TextChanged += new System.EventHandler(this.tbTableFilter_TextChanged);
            // 
            // lbTable
            // 
            this.lbTable.AutoSize = true;
            this.lbTable.BackColor = System.Drawing.Color.Transparent;
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
            this.label1.BackColor = System.Drawing.Color.Transparent;
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
            this.label3.BackColor = System.Drawing.Color.Transparent;
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
            this.tbFieldFilter.TabIndex = 4;
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
            this.comboFieldFormat.TabIndex = 7;
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
            this.comboField.TabIndex = 6;
            this.comboField.SelectedIndexChanged += new System.EventHandler(this.comboField_SelectedIndexChanged);
            // 
            // gbField
            // 
            this.gbField.BackgroundImage = global::XrmToolBox.DataverseAnonymizer.Properties.Resources.Gradient;
            this.gbField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            this.gbField.Location = new System.Drawing.Point(12, 3);
            this.gbField.MinimumSize = new System.Drawing.Size(679, 131);
            this.gbField.Name = "gbField";
            this.gbField.Size = new System.Drawing.Size(679, 131);
            this.gbField.TabIndex = 22;
            this.gbField.TabStop = false;
            this.gbField.Text = "1. Select field";
            // 
            // bTestFilter
            // 
            this.bTestFilter.Location = new System.Drawing.Point(395, 22);
            this.bTestFilter.Name = "bTestFilter";
            this.bTestFilter.Size = new System.Drawing.Size(135, 30);
            this.bTestFilter.TabIndex = 32;
            this.bTestFilter.Text = "Test Filter";
            this.bTestFilter.UseVisualStyleBackColor = true;
            this.bTestFilter.Visible = false;
            this.bTestFilter.Click += new System.EventHandler(this.bTestFilter_Click);
            // 
            // bFetchXmlBuilder
            // 
            this.bFetchXmlBuilder.Location = new System.Drawing.Point(536, 22);
            this.bFetchXmlBuilder.Name = "bFetchXmlBuilder";
            this.bFetchXmlBuilder.Size = new System.Drawing.Size(135, 30);
            this.bFetchXmlBuilder.TabIndex = 31;
            this.bFetchXmlBuilder.Text = "FetchXML Builder";
            this.bFetchXmlBuilder.UseVisualStyleBackColor = true;
            this.bFetchXmlBuilder.Visible = false;
            this.bFetchXmlBuilder.Click += new System.EventHandler(this.bFetchXmlBuilder_Click);
            // 
            // tbFetchXml
            // 
            this.tbFetchXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFetchXml.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFetchXml.Location = new System.Drawing.Point(17, 58);
            this.tbFetchXml.MinimumSize = new System.Drawing.Size(4, 40);
            this.tbFetchXml.Multiline = true;
            this.tbFetchXml.Name = "tbFetchXml";
            this.tbFetchXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFetchXml.Size = new System.Drawing.Size(650, 178);
            this.tbFetchXml.TabIndex = 10;
            this.tbFetchXml.Visible = false;
            this.tbFetchXml.TextChanged += new System.EventHandler(this.tbFetchXml_TextChanged);
            // 
            // rbFilterFetchXml
            // 
            this.rbFilterFetchXml.AutoSize = true;
            this.rbFilterFetchXml.BackColor = System.Drawing.Color.Transparent;
            this.rbFilterFetchXml.Location = new System.Drawing.Point(139, 27);
            this.rbFilterFetchXml.Name = "rbFilterFetchXml";
            this.rbFilterFetchXml.Size = new System.Drawing.Size(90, 23);
            this.rbFilterFetchXml.TabIndex = 9;
            this.rbFilterFetchXml.Text = "FetchXML";
            this.toolTipDelay0.SetToolTip(this.rbFilterFetchXml, "Applies to all rules for the selected table. \r\nIn linked entities select only the" +
        "ir ID to increase performance.");
            this.rbFilterFetchXml.UseVisualStyleBackColor = false;
            this.rbFilterFetchXml.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
            // 
            // rbFilterNone
            // 
            this.rbFilterNone.AutoSize = true;
            this.rbFilterNone.BackColor = System.Drawing.Color.Transparent;
            this.rbFilterNone.Checked = true;
            this.rbFilterNone.Location = new System.Drawing.Point(79, 27);
            this.rbFilterNone.Name = "rbFilterNone";
            this.rbFilterNone.Size = new System.Drawing.Size(61, 23);
            this.rbFilterNone.TabIndex = 8;
            this.rbFilterNone.TabStop = true;
            this.rbFilterNone.Text = "None";
            this.rbFilterNone.UseVisualStyleBackColor = false;
            this.rbFilterNone.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(17, 29);
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
            this.bClearFieldFilter.TabIndex = 5;
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
            this.bClearTableFilter.TabIndex = 1;
            this.bClearTableFilter.Text = "x";
            this.bClearTableFilter.UseCompatibleTextRendering = true;
            this.bClearTableFilter.UseVisualStyleBackColor = true;
            this.bClearTableFilter.Click += new System.EventHandler(this.bClearTableFilter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
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
            this.label4.BackColor = System.Drawing.Color.Transparent;
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
            this.contentPanel.Controls.Add(this.gbFilter);
            this.contentPanel.Controls.Add(this.dgvRules);
            this.contentPanel.Controls.Add(this.gbRun);
            this.contentPanel.Controls.Add(this.gbRule);
            this.contentPanel.Controls.Add(this.gbField);
            this.contentPanel.Controls.Add(this.panel1);
            this.contentPanel.Controls.Add(this.panel2);
            this.contentPanel.Controls.Add(this.panel4);
            this.contentPanel.Location = new System.Drawing.Point(-9, 34);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1206, 906);
            this.contentPanel.TabIndex = 23;
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToAddRows = false;
            this.dgvRules.AllowUserToDeleteRows = false;
            this.dgvRules.AllowUserToResizeRows = false;
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
            this.dgvRules.Location = new System.Drawing.Point(697, 3);
            this.dgvRules.MultiSelect = false;
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowHeadersVisible = false;
            this.dgvRules.RowTemplate.Height = 30;
            this.dgvRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRules.Size = new System.Drawing.Size(498, 894);
            this.dgvRules.TabIndex = 26;
            this.dgvRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellClick);
            this.dgvRules.SelectionChanged += new System.EventHandler(this.dgvRules_SelectionChanged);
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
            this.gbRun.BackgroundImage = global::XrmToolBox.DataverseAnonymizer.Properties.Resources.Gradient;
            this.gbRun.Controls.Add(this.bSkipProcessedRecordsPath);
            this.gbRun.Controls.Add(this.bStoreProcessedRecordsPath);
            this.gbRun.Controls.Add(this.tbSkipProcessedRecordsPath);
            this.gbRun.Controls.Add(this.tbStoreProcessedRecordsPath);
            this.gbRun.Controls.Add(this.cbSkipProcessedRecords);
            this.gbRun.Controls.Add(this.cbStoreProcessedRecords);
            this.gbRun.Controls.Add(this.cbBypassAsync);
            this.gbRun.Controls.Add(this.nudThreads);
            this.gbRun.Controls.Add(this.lbThreads);
            this.gbRun.Controls.Add(this.llBypassHelp);
            this.gbRun.Controls.Add(this.nudBatchSize);
            this.gbRun.Controls.Add(this.label15);
            this.gbRun.Controls.Add(this.cbBypassFlows);
            this.gbRun.Controls.Add(this.cbBypassSync);
            this.gbRun.Controls.Add(this.bRun);
            this.gbRun.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRun.Location = new System.Drawing.Point(12, 694);
            this.gbRun.MinimumSize = new System.Drawing.Size(679, 203);
            this.gbRun.Name = "gbRun";
            this.gbRun.Size = new System.Drawing.Size(679, 203);
            this.gbRun.TabIndex = 25;
            this.gbRun.TabStop = false;
            this.gbRun.Text = "4. Run";
            // 
            // bSkipProcessedRecordsPath
            // 
            this.bSkipProcessedRecordsPath.Location = new System.Drawing.Point(633, 119);
            this.bSkipProcessedRecordsPath.Name = "bSkipProcessedRecordsPath";
            this.bSkipProcessedRecordsPath.Size = new System.Drawing.Size(37, 30);
            this.bSkipProcessedRecordsPath.TabIndex = 35;
            this.bSkipProcessedRecordsPath.Text = "...";
            this.bSkipProcessedRecordsPath.UseVisualStyleBackColor = true;
            this.bSkipProcessedRecordsPath.Click += new System.EventHandler(this.bSkipProcessedRecordsPath_Click);
            // 
            // bStoreProcessedRecordsPath
            // 
            this.bStoreProcessedRecordsPath.Location = new System.Drawing.Point(632, 87);
            this.bStoreProcessedRecordsPath.Name = "bStoreProcessedRecordsPath";
            this.bStoreProcessedRecordsPath.Size = new System.Drawing.Size(37, 30);
            this.bStoreProcessedRecordsPath.TabIndex = 34;
            this.bStoreProcessedRecordsPath.Text = "...";
            this.bStoreProcessedRecordsPath.UseVisualStyleBackColor = true;
            this.bStoreProcessedRecordsPath.Click += new System.EventHandler(this.bStoreProcessedRecordsPath_Click);
            // 
            // tbSkipProcessedRecordsPath
            // 
            this.tbSkipProcessedRecordsPath.Location = new System.Drawing.Point(197, 120);
            this.tbSkipProcessedRecordsPath.Name = "tbSkipProcessedRecordsPath";
            this.tbSkipProcessedRecordsPath.ReadOnly = true;
            this.tbSkipProcessedRecordsPath.Size = new System.Drawing.Size(438, 27);
            this.tbSkipProcessedRecordsPath.TabIndex = 33;
            // 
            // tbStoreProcessedRecordsPath
            // 
            this.tbStoreProcessedRecordsPath.Location = new System.Drawing.Point(197, 89);
            this.tbStoreProcessedRecordsPath.Name = "tbStoreProcessedRecordsPath";
            this.tbStoreProcessedRecordsPath.ReadOnly = true;
            this.tbStoreProcessedRecordsPath.Size = new System.Drawing.Size(438, 27);
            this.tbStoreProcessedRecordsPath.TabIndex = 32;
            // 
            // cbSkipProcessedRecords
            // 
            this.cbSkipProcessedRecords.AutoSize = true;
            this.cbSkipProcessedRecords.BackColor = System.Drawing.Color.Transparent;
            this.cbSkipProcessedRecords.Location = new System.Drawing.Point(16, 122);
            this.cbSkipProcessedRecords.Name = "cbSkipProcessedRecords";
            this.cbSkipProcessedRecords.Size = new System.Drawing.Size(176, 23);
            this.cbSkipProcessedRecords.TabIndex = 31;
            this.cbSkipProcessedRecords.Text = "Skip processed records";
            this.cbSkipProcessedRecords.UseVisualStyleBackColor = false;
            this.cbSkipProcessedRecords.CheckedChanged += new System.EventHandler(this.cbSkipProcessedRecords_CheckedChanged);
            // 
            // cbStoreProcessedRecords
            // 
            this.cbStoreProcessedRecords.AutoSize = true;
            this.cbStoreProcessedRecords.BackColor = System.Drawing.Color.Transparent;
            this.cbStoreProcessedRecords.Location = new System.Drawing.Point(16, 91);
            this.cbStoreProcessedRecords.Name = "cbStoreProcessedRecords";
            this.cbStoreProcessedRecords.Size = new System.Drawing.Size(183, 23);
            this.cbStoreProcessedRecords.TabIndex = 30;
            this.cbStoreProcessedRecords.Text = "Store processed records";
            this.cbStoreProcessedRecords.UseVisualStyleBackColor = false;
            this.cbStoreProcessedRecords.CheckedChanged += new System.EventHandler(this.cbStoreProcessedRecords_CheckedChanged);
            // 
            // cbBypassAsync
            // 
            this.cbBypassAsync.AutoSize = true;
            this.cbBypassAsync.BackColor = System.Drawing.Color.Transparent;
            this.cbBypassAsync.Checked = true;
            this.cbBypassAsync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBypassAsync.Location = new System.Drawing.Point(16, 60);
            this.cbBypassAsync.Name = "cbBypassAsync";
            this.cbBypassAsync.Size = new System.Drawing.Size(317, 23);
            this.cbBypassAsync.TabIndex = 29;
            this.cbBypassAsync.Text = "Bypass asynchronous Plugins and Workflows";
            this.cbBypassAsync.UseVisualStyleBackColor = false;
            // 
            // nudThreads
            // 
            this.nudThreads.Location = new System.Drawing.Point(79, 163);
            this.nudThreads.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.Name = "nudThreads";
            this.nudThreads.Size = new System.Drawing.Size(120, 27);
            this.nudThreads.TabIndex = 27;
            this.nudThreads.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // lbThreads
            // 
            this.lbThreads.AutoSize = true;
            this.lbThreads.BackColor = System.Drawing.Color.Transparent;
            this.lbThreads.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThreads.Location = new System.Drawing.Point(8, 165);
            this.lbThreads.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThreads.Name = "lbThreads";
            this.lbThreads.Size = new System.Drawing.Size(67, 19);
            this.lbThreads.TabIndex = 28;
            this.lbThreads.Text = "Threads:";
            // 
            // llBypassHelp
            // 
            this.llBypassHelp.AutoSize = true;
            this.llBypassHelp.BackColor = System.Drawing.Color.Transparent;
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
            this.nudBatchSize.Location = new System.Drawing.Point(320, 165);
            this.nudBatchSize.Maximum = new decimal(new int[] {
            1000,
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
            this.nudBatchSize.TabIndex = 2;
            this.nudBatchSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(233, 167);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 19);
            this.label15.TabIndex = 26;
            this.label15.Text = "Batch size:";
            // 
            // cbBypassFlows
            // 
            this.cbBypassFlows.AutoSize = true;
            this.cbBypassFlows.BackColor = System.Drawing.Color.Transparent;
            this.cbBypassFlows.Checked = true;
            this.cbBypassFlows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBypassFlows.Location = new System.Drawing.Point(349, 29);
            this.cbBypassFlows.Name = "cbBypassFlows";
            this.cbBypassFlows.Size = new System.Drawing.Size(115, 23);
            this.cbBypassFlows.TabIndex = 1;
            this.cbBypassFlows.Text = "Bypass Flows";
            this.cbBypassFlows.UseVisualStyleBackColor = false;
            // 
            // cbBypassSync
            // 
            this.cbBypassSync.AutoSize = true;
            this.cbBypassSync.BackColor = System.Drawing.Color.Transparent;
            this.cbBypassSync.Checked = true;
            this.cbBypassSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBypassSync.Location = new System.Drawing.Point(16, 29);
            this.cbBypassSync.Name = "cbBypassSync";
            this.cbBypassSync.Size = new System.Drawing.Size(309, 23);
            this.cbBypassSync.TabIndex = 0;
            this.cbBypassSync.Text = "Bypass synchronous Plugins and Workflows";
            this.cbBypassSync.UseVisualStyleBackColor = false;
            // 
            // bRun
            // 
            this.bRun.BackColor = System.Drawing.Color.Lime;
            this.bRun.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRun.Location = new System.Drawing.Point(537, 161);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(132, 36);
            this.bRun.TabIndex = 3;
            this.bRun.Text = "Run";
            this.bRun.UseVisualStyleBackColor = false;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // gbRule
            // 
            this.gbRule.BackgroundImage = global::XrmToolBox.DataverseAnonymizer.Properties.Resources.Gradient;
            this.gbRule.Controls.Add(this.llBogus);
            this.gbRule.Controls.Add(this.label12);
            this.gbRule.Controls.Add(this.tabcRule);
            this.gbRule.Controls.Add(this.bSave);
            this.gbRule.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRule.Location = new System.Drawing.Point(12, 154);
            this.gbRule.MinimumSize = new System.Drawing.Size(679, 253);
            this.gbRule.Name = "gbRule";
            this.gbRule.Size = new System.Drawing.Size(679, 253);
            this.gbRule.TabIndex = 23;
            this.gbRule.TabStop = false;
            this.gbRule.Text = "2. Set anonymization rule";
            // 
            // llBogus
            // 
            this.llBogus.AutoSize = true;
            this.llBogus.BackColor = System.Drawing.Color.Transparent;
            this.llBogus.Location = new System.Drawing.Point(478, 205);
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
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(154, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(251, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Creates or replaces a rule for the selected field.";
            // 
            // tabcRule
            // 
            this.tabcRule.Controls.Add(this.tpSequence);
            this.tabcRule.Controls.Add(this.tpFakeData);
            this.tabcRule.Controls.Add(this.tpRandomInt);
            this.tabcRule.Controls.Add(this.tpRandomDec);
            this.tabcRule.Controls.Add(this.tpRandomDate);
            this.tabcRule.Location = new System.Drawing.Point(16, 33);
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
            this.tbSequenceFormat.TabIndex = 1;
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
            this.nudSequenceStartFrom.TabIndex = 0;
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
            this.label10.Location = new System.Drawing.Point(429, 10);
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
            this.label9.Location = new System.Drawing.Point(221, 10);
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
            // tpRandomInt
            // 
            this.tpRandomInt.Controls.Add(this.lbRandomIntSample);
            this.tpRandomInt.Controls.Add(this.tbRandomIntSample);
            this.tpRandomInt.Controls.Add(this.bRandomIntSample);
            this.tpRandomInt.Controls.Add(this.nudRandomIntRangeTo);
            this.tpRandomInt.Controls.Add(this.label18);
            this.tpRandomInt.Controls.Add(this.nudRandomIntRangeFrom);
            this.tpRandomInt.Controls.Add(this.label17);
            this.tpRandomInt.Location = new System.Drawing.Point(4, 28);
            this.tpRandomInt.Name = "tpRandomInt";
            this.tpRandomInt.Padding = new System.Windows.Forms.Padding(3);
            this.tpRandomInt.Size = new System.Drawing.Size(646, 125);
            this.tpRandomInt.TabIndex = 2;
            this.tpRandomInt.Text = "Random number";
            this.tpRandomInt.UseVisualStyleBackColor = true;
            // 
            // lbRandomIntSample
            // 
            this.lbRandomIntSample.AutoSize = true;
            this.lbRandomIntSample.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRandomIntSample.Location = new System.Drawing.Point(13, 90);
            this.lbRandomIntSample.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRandomIntSample.Name = "lbRandomIntSample";
            this.lbRandomIntSample.Size = new System.Drawing.Size(63, 19);
            this.lbRandomIntSample.TabIndex = 32;
            this.lbRandomIntSample.Text = "Sample:";
            // 
            // tbRandomIntSample
            // 
            this.tbRandomIntSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRandomIntSample.Location = new System.Drawing.Point(86, 87);
            this.tbRandomIntSample.Margin = new System.Windows.Forms.Padding(4);
            this.tbRandomIntSample.Name = "tbRandomIntSample";
            this.tbRandomIntSample.ReadOnly = true;
            this.tbRandomIntSample.Size = new System.Drawing.Size(495, 27);
            this.tbRandomIntSample.TabIndex = 31;
            // 
            // bRandomIntSample
            // 
            this.bRandomIntSample.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRandomIntSample.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bRandomIntSample.Location = new System.Drawing.Point(589, 81);
            this.bRandomIntSample.Margin = new System.Windows.Forms.Padding(4);
            this.bRandomIntSample.Name = "bRandomIntSample";
            this.bRandomIntSample.Size = new System.Drawing.Size(35, 37);
            this.bRandomIntSample.TabIndex = 30;
            this.bRandomIntSample.Text = "🗘";
            this.bRandomIntSample.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bRandomIntSample.UseVisualStyleBackColor = true;
            this.bRandomIntSample.Click += new System.EventHandler(this.bRandomIntSample_Click);
            // 
            // nudRandomIntRangeTo
            // 
            this.nudRandomIntRangeTo.Location = new System.Drawing.Point(185, 37);
            this.nudRandomIntRangeTo.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudRandomIntRangeTo.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudRandomIntRangeTo.Name = "nudRandomIntRangeTo";
            this.nudRandomIntRangeTo.Size = new System.Drawing.Size(149, 27);
            this.nudRandomIntRangeTo.TabIndex = 28;
            this.nudRandomIntRangeTo.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRandomIntRangeTo.ValueChanged += new System.EventHandler(this.nudRandomIntRangeTo_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(180, 10);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 19);
            this.label18.TabIndex = 29;
            this.label18.Text = "Range to:";
            // 
            // nudRandomIntRangeFrom
            // 
            this.nudRandomIntRangeFrom.Location = new System.Drawing.Point(17, 37);
            this.nudRandomIntRangeFrom.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudRandomIntRangeFrom.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudRandomIntRangeFrom.Name = "nudRandomIntRangeFrom";
            this.nudRandomIntRangeFrom.Size = new System.Drawing.Size(149, 27);
            this.nudRandomIntRangeFrom.TabIndex = 26;
            this.nudRandomIntRangeFrom.Value = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudRandomIntRangeFrom.ValueChanged += new System.EventHandler(this.nudRandomIntRangeFrom_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 10);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 19);
            this.label17.TabIndex = 27;
            this.label17.Text = "Range from:";
            // 
            // tpRandomDec
            // 
            this.tpRandomDec.Controls.Add(this.nudRandomDecDecimals);
            this.tpRandomDec.Controls.Add(this.label23);
            this.tpRandomDec.Controls.Add(this.lbRandomDecSample);
            this.tpRandomDec.Controls.Add(this.tbRandomDecSample);
            this.tpRandomDec.Controls.Add(this.bRandomDecSample);
            this.tpRandomDec.Controls.Add(this.nudRandomDecRangeTo);
            this.tpRandomDec.Controls.Add(this.label21);
            this.tpRandomDec.Controls.Add(this.nudRandomDecRangeFrom);
            this.tpRandomDec.Controls.Add(this.label22);
            this.tpRandomDec.Location = new System.Drawing.Point(4, 28);
            this.tpRandomDec.Name = "tpRandomDec";
            this.tpRandomDec.Size = new System.Drawing.Size(646, 125);
            this.tpRandomDec.TabIndex = 3;
            this.tpRandomDec.Text = "Random number";
            this.tpRandomDec.UseVisualStyleBackColor = true;
            // 
            // nudRandomDecDecimals
            // 
            this.nudRandomDecDecimals.Location = new System.Drawing.Point(352, 37);
            this.nudRandomDecDecimals.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRandomDecDecimals.Name = "nudRandomDecDecimals";
            this.nudRandomDecDecimals.Size = new System.Drawing.Size(149, 27);
            this.nudRandomDecDecimals.TabIndex = 40;
            this.nudRandomDecDecimals.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRandomDecDecimals.ValueChanged += new System.EventHandler(this.nudRandomDecDecimals_ValueChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(347, 10);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 19);
            this.label23.TabIndex = 41;
            this.label23.Text = "Decimals:";
            // 
            // lbRandomDecSample
            // 
            this.lbRandomDecSample.AutoSize = true;
            this.lbRandomDecSample.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRandomDecSample.Location = new System.Drawing.Point(13, 90);
            this.lbRandomDecSample.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRandomDecSample.Name = "lbRandomDecSample";
            this.lbRandomDecSample.Size = new System.Drawing.Size(63, 19);
            this.lbRandomDecSample.TabIndex = 39;
            this.lbRandomDecSample.Text = "Sample:";
            // 
            // tbRandomDecSample
            // 
            this.tbRandomDecSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRandomDecSample.Location = new System.Drawing.Point(86, 87);
            this.tbRandomDecSample.Margin = new System.Windows.Forms.Padding(4);
            this.tbRandomDecSample.Name = "tbRandomDecSample";
            this.tbRandomDecSample.ReadOnly = true;
            this.tbRandomDecSample.Size = new System.Drawing.Size(495, 27);
            this.tbRandomDecSample.TabIndex = 38;
            // 
            // bRandomDecSample
            // 
            this.bRandomDecSample.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRandomDecSample.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bRandomDecSample.Location = new System.Drawing.Point(589, 81);
            this.bRandomDecSample.Margin = new System.Windows.Forms.Padding(4);
            this.bRandomDecSample.Name = "bRandomDecSample";
            this.bRandomDecSample.Size = new System.Drawing.Size(35, 37);
            this.bRandomDecSample.TabIndex = 37;
            this.bRandomDecSample.Text = "🗘";
            this.bRandomDecSample.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bRandomDecSample.UseVisualStyleBackColor = true;
            this.bRandomDecSample.Click += new System.EventHandler(this.bRandomDecSample_Click);
            // 
            // nudRandomDecRangeTo
            // 
            this.nudRandomDecRangeTo.Location = new System.Drawing.Point(185, 37);
            this.nudRandomDecRangeTo.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudRandomDecRangeTo.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.nudRandomDecRangeTo.Name = "nudRandomDecRangeTo";
            this.nudRandomDecRangeTo.Size = new System.Drawing.Size(149, 27);
            this.nudRandomDecRangeTo.TabIndex = 35;
            this.nudRandomDecRangeTo.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRandomDecRangeTo.ValueChanged += new System.EventHandler(this.nudRandomDecRangeTo_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(180, 10);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 19);
            this.label21.TabIndex = 36;
            this.label21.Text = "Range to:";
            // 
            // nudRandomDecRangeFrom
            // 
            this.nudRandomDecRangeFrom.Location = new System.Drawing.Point(17, 37);
            this.nudRandomDecRangeFrom.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudRandomDecRangeFrom.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.nudRandomDecRangeFrom.Name = "nudRandomDecRangeFrom";
            this.nudRandomDecRangeFrom.Size = new System.Drawing.Size(149, 27);
            this.nudRandomDecRangeFrom.TabIndex = 33;
            this.nudRandomDecRangeFrom.Value = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudRandomDecRangeFrom.ValueChanged += new System.EventHandler(this.nudRandomDecRangeFrom_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(13, 10);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(92, 19);
            this.label22.TabIndex = 34;
            this.label22.Text = "Range from:";
            // 
            // tpRandomDate
            // 
            this.tpRandomDate.Controls.Add(this.dtpRandomDateTo);
            this.tpRandomDate.Controls.Add(this.dtpRandomDateFrom);
            this.tpRandomDate.Controls.Add(this.lbRandomDateSample);
            this.tpRandomDate.Controls.Add(this.tbRandomDateSample);
            this.tpRandomDate.Controls.Add(this.bRandomDateSample);
            this.tpRandomDate.Controls.Add(this.lbRandomDateTo);
            this.tpRandomDate.Controls.Add(this.lbRandomDateFrom);
            this.tpRandomDate.Location = new System.Drawing.Point(4, 28);
            this.tpRandomDate.Name = "tpRandomDate";
            this.tpRandomDate.Size = new System.Drawing.Size(646, 125);
            this.tpRandomDate.TabIndex = 4;
            this.tpRandomDate.Text = "Random date";
            this.tpRandomDate.UseVisualStyleBackColor = true;
            // 
            // dtpRandomDateTo
            // 
            this.dtpRandomDateTo.Location = new System.Drawing.Point(325, 37);
            this.dtpRandomDateTo.Name = "dtpRandomDateTo";
            this.dtpRandomDateTo.Size = new System.Drawing.Size(298, 27);
            this.dtpRandomDateTo.TabIndex = 41;
            this.dtpRandomDateTo.ValueChanged += new System.EventHandler(this.dtpRandomDateTo_ValueChanged);
            // 
            // dtpRandomDateFrom
            // 
            this.dtpRandomDateFrom.Location = new System.Drawing.Point(17, 37);
            this.dtpRandomDateFrom.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpRandomDateFrom.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpRandomDateFrom.Name = "dtpRandomDateFrom";
            this.dtpRandomDateFrom.Size = new System.Drawing.Size(285, 27);
            this.dtpRandomDateFrom.TabIndex = 40;
            this.dtpRandomDateFrom.ValueChanged += new System.EventHandler(this.dtpRandomDateFrom_ValueChanged);
            // 
            // lbRandomDateSample
            // 
            this.lbRandomDateSample.AutoSize = true;
            this.lbRandomDateSample.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRandomDateSample.Location = new System.Drawing.Point(13, 90);
            this.lbRandomDateSample.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRandomDateSample.Name = "lbRandomDateSample";
            this.lbRandomDateSample.Size = new System.Drawing.Size(63, 19);
            this.lbRandomDateSample.TabIndex = 39;
            this.lbRandomDateSample.Text = "Sample:";
            // 
            // tbRandomDateSample
            // 
            this.tbRandomDateSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRandomDateSample.Location = new System.Drawing.Point(86, 87);
            this.tbRandomDateSample.Margin = new System.Windows.Forms.Padding(4);
            this.tbRandomDateSample.Name = "tbRandomDateSample";
            this.tbRandomDateSample.ReadOnly = true;
            this.tbRandomDateSample.Size = new System.Drawing.Size(495, 27);
            this.tbRandomDateSample.TabIndex = 38;
            // 
            // bRandomDateSample
            // 
            this.bRandomDateSample.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRandomDateSample.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bRandomDateSample.Location = new System.Drawing.Point(589, 81);
            this.bRandomDateSample.Margin = new System.Windows.Forms.Padding(4);
            this.bRandomDateSample.Name = "bRandomDateSample";
            this.bRandomDateSample.Size = new System.Drawing.Size(35, 37);
            this.bRandomDateSample.TabIndex = 37;
            this.bRandomDateSample.Text = "🗘";
            this.bRandomDateSample.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bRandomDateSample.UseVisualStyleBackColor = true;
            this.bRandomDateSample.Click += new System.EventHandler(this.bRandomDateSample_Click);
            // 
            // lbRandomDateTo
            // 
            this.lbRandomDateTo.AutoSize = true;
            this.lbRandomDateTo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRandomDateTo.Location = new System.Drawing.Point(321, 10);
            this.lbRandomDateTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRandomDateTo.Name = "lbRandomDateTo";
            this.lbRandomDateTo.Size = new System.Drawing.Size(74, 19);
            this.lbRandomDateTo.TabIndex = 36;
            this.lbRandomDateTo.Text = "Range to:";
            // 
            // lbRandomDateFrom
            // 
            this.lbRandomDateFrom.AutoSize = true;
            this.lbRandomDateFrom.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRandomDateFrom.Location = new System.Drawing.Point(13, 10);
            this.lbRandomDateFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRandomDateFrom.Name = "lbRandomDateFrom";
            this.lbRandomDateFrom.Size = new System.Drawing.Size(92, 19);
            this.lbRandomDateFrom.TabIndex = 34;
            this.lbRandomDateFrom.Text = "Range from:";
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.Location = new System.Drawing.Point(16, 205);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(132, 36);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(-11, 673);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 18);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(-13, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 18);
            this.panel2.TabIndex = 28;
            // 
            // bStop
            // 
            this.bStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bStop.BackColor = System.Drawing.Color.Yellow;
            this.bStop.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bStop.ForeColor = System.Drawing.Color.Red;
            this.bStop.Location = new System.Drawing.Point(-20, 32);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(1240, 53);
            this.bStop.TabIndex = 24;
            this.bStop.Text = "STOP";
            this.bStop.UseVisualStyleBackColor = false;
            this.bStop.Visible = false;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttbSave,
            this.ttbLoad,
            this.ttbFeedback,
            this.tslVersion});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1200, 25);
            this.toolStrip.TabIndex = 25;
            this.toolStrip.Text = "toolStrip1";
            // 
            // ttbSave
            // 
            this.ttbSave.Image = global::XrmToolBox.DataverseAnonymizer.Properties.Resources.Save_02;
            this.ttbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttbSave.Name = "ttbSave";
            this.ttbSave.Size = new System.Drawing.Size(51, 22);
            this.ttbSave.Text = "Save";
            this.ttbSave.Click += new System.EventHandler(this.ttbSave_Click);
            // 
            // ttbLoad
            // 
            this.ttbLoad.Image = global::XrmToolBox.DataverseAnonymizer.Properties.Resources.Upload;
            this.ttbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttbLoad.Name = "ttbLoad";
            this.ttbLoad.Size = new System.Drawing.Size(53, 22);
            this.ttbLoad.Text = "Load";
            this.ttbLoad.Click += new System.EventHandler(this.ttbLoad_Click);
            // 
            // ttbFeedback
            // 
            this.ttbFeedback.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ttbFeedback.Image = global::XrmToolBox.DataverseAnonymizer.Properties.Resources.GitHub;
            this.ttbFeedback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttbFeedback.Name = "ttbFeedback";
            this.ttbFeedback.Size = new System.Drawing.Size(77, 22);
            this.ttbFeedback.Text = "Feedback";
            this.ttbFeedback.Click += new System.EventHandler(this.ttbFeedback_Click);
            // 
            // tslVersion
            // 
            this.tslVersion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tslVersion.Name = "tslVersion";
            this.tslVersion.Size = new System.Drawing.Size(152, 22);
            this.tslVersion.Text = "Dataverse Anonymizer {0}";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.Filter = "JSON files|*.json|All files|*.*";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "json";
            this.openFileDialog.Filter = "JSON files|*.json|All files|*.*";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // toolTipDelay0
            // 
            this.toolTipDelay0.AutoPopDelay = 5000;
            this.toolTipDelay0.InitialDelay = 0;
            this.toolTipDelay0.ReshowDelay = 100;
            this.toolTipDelay0.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(-2, -157);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(739, 18);
            this.panel3.TabIndex = 28;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(-18, 407);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(739, 18);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Location = new System.Drawing.Point(-2, -157);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(739, 18);
            this.panel5.TabIndex = 28;
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.gbFilter.BackgroundImage = global::XrmToolBox.DataverseAnonymizer.Properties.Resources.Gradient;
            this.gbFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbFilter.Controls.Add(this.tbFetchXml);
            this.gbFilter.Controls.Add(this.bTestFilter);
            this.gbFilter.Controls.Add(this.bFetchXmlBuilder);
            this.gbFilter.Controls.Add(this.label16);
            this.gbFilter.Controls.Add(this.rbFilterNone);
            this.gbFilter.Controls.Add(this.rbFilterFetchXml);
            this.gbFilter.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(12, 427);
            this.gbFilter.MinimumSize = new System.Drawing.Size(679, 136);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(679, 246);
            this.gbFilter.TabIndex = 36;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "3. Optional filter";
            // 
            // DataverseAnonymizerPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.bStop);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(1200, 834);
            this.Name = "DataverseAnonymizerPluginControl";
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(1200, 943);
            this.Load += new System.EventHandler(this.DataverseAnonymizerPluginControl_Load);
            this.gbField.ResumeLayout(false);
            this.gbField.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            this.gbRun.ResumeLayout(false);
            this.gbRun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBatchSize)).EndInit();
            this.gbRule.ResumeLayout(false);
            this.gbRule.PerformLayout();
            this.tabcRule.ResumeLayout(false);
            this.tpSequence.ResumeLayout(false);
            this.tpSequence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSequenceStartFrom)).EndInit();
            this.tpFakeData.ResumeLayout(false);
            this.tpFakeData.PerformLayout();
            this.tpRandomInt.ResumeLayout(false);
            this.tpRandomInt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomIntRangeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomIntRangeFrom)).EndInit();
            this.tpRandomDec.ResumeLayout(false);
            this.tpRandomDec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomDecDecimals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomDecRangeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandomDecRangeFrom)).EndInit();
            this.tpRandomDate.ResumeLayout(false);
            this.tpRandomDate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.CheckBox cbBypassSync;
        private System.Windows.Forms.CheckBox cbBypassFlows;
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
        private System.Windows.Forms.Button bFetchXmlBuilder;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton ttbSave;
        private System.Windows.Forms.ToolStripButton ttbLoad;
        private System.Windows.Forms.ToolStripButton ttbFeedback;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.NumericUpDown nudThreads;
        private System.Windows.Forms.Label lbThreads;
        private System.Windows.Forms.TabPage tpRandomInt;
        private System.Windows.Forms.NumericUpDown nudRandomIntRangeTo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudRandomIntRangeFrom;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbRandomIntSample;
        private System.Windows.Forms.TextBox tbRandomIntSample;
        private System.Windows.Forms.Button bRandomIntSample;
        private System.Windows.Forms.TabPage tpRandomDec;
        private System.Windows.Forms.Label lbRandomDecSample;
        private System.Windows.Forms.TextBox tbRandomDecSample;
        private System.Windows.Forms.Button bRandomDecSample;
        private System.Windows.Forms.NumericUpDown nudRandomDecRangeTo;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown nudRandomDecRangeFrom;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nudRandomDecDecimals;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabPage tpRandomDate;
        private System.Windows.Forms.DateTimePicker dtpRandomDateTo;
        private System.Windows.Forms.DateTimePicker dtpRandomDateFrom;
        private System.Windows.Forms.Label lbRandomDateSample;
        private System.Windows.Forms.TextBox tbRandomDateSample;
        private System.Windows.Forms.Button bRandomDateSample;
        private System.Windows.Forms.Label lbRandomDateTo;
        private System.Windows.Forms.Label lbRandomDateFrom;
        private System.Windows.Forms.ToolTip toolTipDelay0;
        private System.Windows.Forms.Button bTestFilter;
        private System.Windows.Forms.ToolStripLabel tslVersion;
        private System.Windows.Forms.CheckBox cbBypassAsync;
        private System.Windows.Forms.CheckBox cbStoreProcessedRecords;
        private System.Windows.Forms.CheckBox cbSkipProcessedRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbSkipProcessedRecordsPath;
        private System.Windows.Forms.TextBox tbStoreProcessedRecordsPath;
        private System.Windows.Forms.Button bSkipProcessedRecordsPath;
        private System.Windows.Forms.Button bStoreProcessedRecordsPath;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
    }
}
