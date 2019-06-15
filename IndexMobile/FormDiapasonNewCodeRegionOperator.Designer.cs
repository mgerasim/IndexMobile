namespace IndexMobile
{
    partial class FromDiapasonNewCodeRegionOperator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.checkedListBoxCode = new System.Windows.Forms.CheckedListBox();
			this.checkedListBoxRegion = new System.Windows.Forms.CheckedListBox();
			this.checkedListBoxOperator = new System.Windows.Forms.CheckedListBox();
			this.labelOperator = new System.Windows.Forms.Label();
			this.labelRegion = new System.Windows.Forms.Label();
			this.labelCode = new System.Windows.Forms.Label();
			this.textBoxCode = new System.Windows.Forms.TextBox();
			this.textBoxRegion = new System.Windows.Forms.TextBox();
			this.textBoxOperator = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.checkBoxCodeAll = new System.Windows.Forms.CheckBox();
			this.checkBoxRegionAll = new System.Windows.Forms.CheckBox();
			this.checkBoxOperatorAll = new System.Windows.Forms.CheckBox();
			this.checkedListBoxDistrict = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxDistrict = new System.Windows.Forms.TextBox();
			this.checkBoxDistrictAll = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkedListBoxCode
			// 
			this.checkedListBoxCode.CheckOnClick = true;
			this.checkedListBoxCode.FormattingEnabled = true;
			this.checkedListBoxCode.Location = new System.Drawing.Point(1392, 108);
			this.checkedListBoxCode.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.checkedListBoxCode.Name = "checkedListBoxCode";
			this.checkedListBoxCode.Size = new System.Drawing.Size(294, 576);
			this.checkedListBoxCode.TabIndex = 0;
			this.checkedListBoxCode.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxCode_ItemCheck);
			// 
			// checkedListBoxRegion
			// 
			this.checkedListBoxRegion.CheckOnClick = true;
			this.checkedListBoxRegion.FormattingEnabled = true;
			this.checkedListBoxRegion.Location = new System.Drawing.Point(378, 108);
			this.checkedListBoxRegion.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.checkedListBoxRegion.Name = "checkedListBoxRegion";
			this.checkedListBoxRegion.Size = new System.Drawing.Size(416, 576);
			this.checkedListBoxRegion.TabIndex = 0;
			this.checkedListBoxRegion.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRegion_ItemCheck);
			// 
			// checkedListBoxOperator
			// 
			this.checkedListBoxOperator.CheckOnClick = true;
			this.checkedListBoxOperator.FormattingEnabled = true;
			this.checkedListBoxOperator.Location = new System.Drawing.Point(842, 108);
			this.checkedListBoxOperator.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.checkedListBoxOperator.Name = "checkedListBoxOperator";
			this.checkedListBoxOperator.Size = new System.Drawing.Size(508, 576);
			this.checkedListBoxOperator.TabIndex = 0;
			this.checkedListBoxOperator.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxOperator_ItemCheck);
			// 
			// labelOperator
			// 
			this.labelOperator.AutoSize = true;
			this.labelOperator.Location = new System.Drawing.Point(836, 15);
			this.labelOperator.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.labelOperator.Name = "labelOperator";
			this.labelOperator.Size = new System.Drawing.Size(125, 25);
			this.labelOperator.TabIndex = 1;
			this.labelOperator.Text = "Операторы";
			// 
			// labelRegion
			// 
			this.labelRegion.AutoSize = true;
			this.labelRegion.Location = new System.Drawing.Point(372, 15);
			this.labelRegion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.labelRegion.Name = "labelRegion";
			this.labelRegion.Size = new System.Drawing.Size(103, 25);
			this.labelRegion.TabIndex = 1;
			this.labelRegion.Text = "Регионы:";
			// 
			// labelCode
			// 
			this.labelCode.AutoSize = true;
			this.labelCode.Location = new System.Drawing.Point(1392, 15);
			this.labelCode.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.labelCode.Name = "labelCode";
			this.labelCode.Size = new System.Drawing.Size(71, 25);
			this.labelCode.TabIndex = 1;
			this.labelCode.Text = "Коды:";
			// 
			// textBoxCode
			// 
			this.textBoxCode.Location = new System.Drawing.Point(1392, 704);
			this.textBoxCode.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.textBoxCode.Multiline = true;
			this.textBoxCode.Name = "textBoxCode";
			this.textBoxCode.ReadOnly = true;
			this.textBoxCode.Size = new System.Drawing.Size(294, 402);
			this.textBoxCode.TabIndex = 2;
			// 
			// textBoxRegion
			// 
			this.textBoxRegion.Location = new System.Drawing.Point(378, 704);
			this.textBoxRegion.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.textBoxRegion.Multiline = true;
			this.textBoxRegion.Name = "textBoxRegion";
			this.textBoxRegion.ReadOnly = true;
			this.textBoxRegion.Size = new System.Drawing.Size(416, 402);
			this.textBoxRegion.TabIndex = 2;
			// 
			// textBoxOperator
			// 
			this.textBoxOperator.Location = new System.Drawing.Point(842, 704);
			this.textBoxOperator.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.textBoxOperator.Multiline = true;
			this.textBoxOperator.Name = "textBoxOperator";
			this.textBoxOperator.ReadOnly = true;
			this.textBoxOperator.Size = new System.Drawing.Size(508, 402);
			this.textBoxOperator.TabIndex = 2;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(724, 1121);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(150, 44);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(1072, 1121);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(150, 44);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// checkBoxCodeAll
			// 
			this.checkBoxCodeAll.AutoSize = true;
			this.checkBoxCodeAll.Location = new System.Drawing.Point(1398, 63);
			this.checkBoxCodeAll.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.checkBoxCodeAll.Name = "checkBoxCodeAll";
			this.checkBoxCodeAll.Size = new System.Drawing.Size(81, 29);
			this.checkBoxCodeAll.TabIndex = 5;
			this.checkBoxCodeAll.Text = "Все";
			this.checkBoxCodeAll.UseVisualStyleBackColor = true;
			this.checkBoxCodeAll.CheckedChanged += new System.EventHandler(this.checkBoxCodeAll_CheckedChanged);
			// 
			// checkBoxRegionAll
			// 
			this.checkBoxRegionAll.AutoSize = true;
			this.checkBoxRegionAll.Location = new System.Drawing.Point(378, 63);
			this.checkBoxRegionAll.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.checkBoxRegionAll.Name = "checkBoxRegionAll";
			this.checkBoxRegionAll.Size = new System.Drawing.Size(81, 29);
			this.checkBoxRegionAll.TabIndex = 5;
			this.checkBoxRegionAll.Text = "Все";
			this.checkBoxRegionAll.UseVisualStyleBackColor = true;
			this.checkBoxRegionAll.CheckedChanged += new System.EventHandler(this.checkBoxRegionAll_CheckedChanged);
			// 
			// checkBoxOperatorAll
			// 
			this.checkBoxOperatorAll.AutoSize = true;
			this.checkBoxOperatorAll.Location = new System.Drawing.Point(842, 63);
			this.checkBoxOperatorAll.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.checkBoxOperatorAll.Name = "checkBoxOperatorAll";
			this.checkBoxOperatorAll.Size = new System.Drawing.Size(81, 29);
			this.checkBoxOperatorAll.TabIndex = 5;
			this.checkBoxOperatorAll.Text = "Все";
			this.checkBoxOperatorAll.UseVisualStyleBackColor = true;
			this.checkBoxOperatorAll.CheckedChanged += new System.EventHandler(this.checkBoxOperatorAll_CheckedChanged);
			// 
			// checkedListBoxDistrict
			// 
			this.checkedListBoxDistrict.CheckOnClick = true;
			this.checkedListBoxDistrict.FormattingEnabled = true;
			this.checkedListBoxDistrict.Location = new System.Drawing.Point(69, 108);
			this.checkedListBoxDistrict.Margin = new System.Windows.Forms.Padding(6);
			this.checkedListBoxDistrict.Name = "checkedListBoxDistrict";
			this.checkedListBoxDistrict.Size = new System.Drawing.Size(256, 576);
			this.checkedListBoxDistrict.TabIndex = 0;
			this.checkedListBoxDistrict.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxDistrict_ItemCheck);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(63, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Направление";
			// 
			// textBoxDistrict
			// 
			this.textBoxDistrict.Location = new System.Drawing.Point(69, 704);
			this.textBoxDistrict.Margin = new System.Windows.Forms.Padding(6);
			this.textBoxDistrict.Multiline = true;
			this.textBoxDistrict.Name = "textBoxDistrict";
			this.textBoxDistrict.ReadOnly = true;
			this.textBoxDistrict.Size = new System.Drawing.Size(256, 402);
			this.textBoxDistrict.TabIndex = 2;
			// 
			// checkBoxDistrictAll
			// 
			this.checkBoxDistrictAll.AutoSize = true;
			this.checkBoxDistrictAll.Location = new System.Drawing.Point(69, 63);
			this.checkBoxDistrictAll.Margin = new System.Windows.Forms.Padding(6);
			this.checkBoxDistrictAll.Name = "checkBoxDistrictAll";
			this.checkBoxDistrictAll.Size = new System.Drawing.Size(81, 29);
			this.checkBoxDistrictAll.TabIndex = 5;
			this.checkBoxDistrictAll.Text = "Все";
			this.checkBoxDistrictAll.UseVisualStyleBackColor = true;
			this.checkBoxDistrictAll.CheckedChanged += new System.EventHandler(this.checkBoxDistrictAll_CheckedChanged);
			// 
			// FromDiapasonNewCodeRegionOperator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1736, 1217);
			this.Controls.Add(this.checkBoxDistrictAll);
			this.Controls.Add(this.checkBoxOperatorAll);
			this.Controls.Add(this.checkBoxRegionAll);
			this.Controls.Add(this.checkBoxCodeAll);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxDistrict);
			this.Controls.Add(this.textBoxOperator);
			this.Controls.Add(this.textBoxRegion);
			this.Controls.Add(this.textBoxCode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelOperator);
			this.Controls.Add(this.labelRegion);
			this.Controls.Add(this.labelCode);
			this.Controls.Add(this.checkedListBoxDistrict);
			this.Controls.Add(this.checkedListBoxOperator);
			this.Controls.Add(this.checkedListBoxRegion);
			this.Controls.Add(this.checkedListBoxCode);
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.Name = "FromDiapasonNewCodeRegionOperator";
			this.Text = "Добавить диапозон по коду, региону и оператору";
			this.Load += new System.EventHandler(this.AccessNewCodeRegionOperator_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOperator;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.Label labelCode;
        public System.Windows.Forms.CheckedListBox checkedListBoxCode;
        public System.Windows.Forms.CheckedListBox checkedListBoxRegion;
        public System.Windows.Forms.CheckedListBox checkedListBoxOperator;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.TextBox textBoxCode;
        public System.Windows.Forms.TextBox textBoxRegion;
        public System.Windows.Forms.TextBox textBoxOperator;
        private System.Windows.Forms.CheckBox checkBoxCodeAll;
        private System.Windows.Forms.CheckBox checkBoxRegionAll;
        private System.Windows.Forms.CheckBox checkBoxOperatorAll;
		public System.Windows.Forms.CheckedListBox checkedListBoxDistrict;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox textBoxDistrict;
		private System.Windows.Forms.CheckBox checkBoxDistrictAll;
	}
}