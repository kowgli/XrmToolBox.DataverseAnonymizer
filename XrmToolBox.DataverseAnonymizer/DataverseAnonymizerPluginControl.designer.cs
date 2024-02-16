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
            this.bGenerate = new System.Windows.Forms.Button();
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
            this.gbFind = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbFind.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbBogusDataSet
            // 
            this.cbBogusDataSet.DisplayMember = "Name";
            this.cbBogusDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBogusDataSet.FormattingEnabled = true;
            this.cbBogusDataSet.Location = new System.Drawing.Point(66, 589);
            this.cbBogusDataSet.Margin = new System.Windows.Forms.Padding(4);
            this.cbBogusDataSet.Name = "cbBogusDataSet";
            this.cbBogusDataSet.Size = new System.Drawing.Size(341, 27);
            this.cbBogusDataSet.TabIndex = 5;
            this.cbBogusDataSet.SelectedIndexChanged += new System.EventHandler(this.cbBogusDataSet_SelectedIndexChanged);
            // 
            // cbBogusMethod
            // 
            this.cbBogusMethod.DisplayMember = "Name";
            this.cbBogusMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBogusMethod.FormattingEnabled = true;
            this.cbBogusMethod.Location = new System.Drawing.Point(440, 589);
            this.cbBogusMethod.Margin = new System.Windows.Forms.Padding(4);
            this.cbBogusMethod.Name = "cbBogusMethod";
            this.cbBogusMethod.Size = new System.Drawing.Size(293, 27);
            this.cbBogusMethod.TabIndex = 6;
            // 
            // bGenerate
            // 
            this.bGenerate.Location = new System.Drawing.Point(756, 589);
            this.bGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(100, 34);
            this.bGenerate.TabIndex = 7;
            this.bGenerate.Text = "Generate";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
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
            // gbFind
            // 
            this.gbFind.Controls.Add(this.label5);
            this.gbFind.Controls.Add(this.label4);
            this.gbFind.Controls.Add(this.button1);
            this.gbFind.Controls.Add(this.cbEntity);
            this.gbFind.Controls.Add(this.label2);
            this.gbFind.Controls.Add(this.cbEntityFormat);
            this.gbFind.Controls.Add(this.label3);
            this.gbFind.Controls.Add(this.tbEntityFilter);
            this.gbFind.Controls.Add(this.tbAttributeFilter);
            this.gbFind.Controls.Add(this.lbTable);
            this.gbFind.Controls.Add(this.cbAttributeFormat);
            this.gbFind.Controls.Add(this.label1);
            this.gbFind.Controls.Add(this.cbAttribute);
            this.gbFind.Location = new System.Drawing.Point(23, 23);
            this.gbFind.Name = "gbFind";
            this.gbFind.Size = new System.Drawing.Size(824, 129);
            this.gbFind.TabIndex = 22;
            this.gbFind.TabStop = false;
            this.gbFind.Text = "Find field";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(704, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 85);
            this.button1.TabIndex = 22;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
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
            // DataverseAnonymizerPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFind);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bGenerate);
            this.Controls.Add(this.cbBogusMethod);
            this.Controls.Add(this.cbBogusDataSet);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataverseAnonymizerPluginControl";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(1037, 728);
            this.Load += new System.EventHandler(this.DataverseAnonymizerPluginControl_Load);
            this.gbFind.ResumeLayout(false);
            this.gbFind.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbBogusDataSet;
        private System.Windows.Forms.ComboBox cbBogusMethod;
        private System.Windows.Forms.Button bGenerate;
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
        private System.Windows.Forms.GroupBox gbFind;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
