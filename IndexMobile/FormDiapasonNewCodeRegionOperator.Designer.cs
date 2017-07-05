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
            this.SuspendLayout();
            // 
            // checkedListBoxCode
            // 
            this.checkedListBoxCode.CheckOnClick = true;
            this.checkedListBoxCode.FormattingEnabled = true;
            this.checkedListBoxCode.Location = new System.Drawing.Point(12, 57);
            this.checkedListBoxCode.Name = "checkedListBoxCode";
            this.checkedListBoxCode.Size = new System.Drawing.Size(281, 304);
            this.checkedListBoxCode.TabIndex = 0;
            this.checkedListBoxCode.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxCode_ItemCheck);
            this.checkedListBoxCode.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxCode_SelectedIndexChanged);
            // 
            // checkedListBoxRegion
            // 
            this.checkedListBoxRegion.CheckOnClick = true;
            this.checkedListBoxRegion.FormattingEnabled = true;
            this.checkedListBoxRegion.Location = new System.Drawing.Point(311, 57);
            this.checkedListBoxRegion.Name = "checkedListBoxRegion";
            this.checkedListBoxRegion.Size = new System.Drawing.Size(281, 304);
            this.checkedListBoxRegion.TabIndex = 0;
            this.checkedListBoxRegion.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRegion_ItemCheck);
            this.checkedListBoxRegion.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxRegion_SelectedIndexChanged);
            // 
            // checkedListBoxOperator
            // 
            this.checkedListBoxOperator.CheckOnClick = true;
            this.checkedListBoxOperator.FormattingEnabled = true;
            this.checkedListBoxOperator.Location = new System.Drawing.Point(610, 57);
            this.checkedListBoxOperator.Name = "checkedListBoxOperator";
            this.checkedListBoxOperator.Size = new System.Drawing.Size(320, 304);
            this.checkedListBoxOperator.TabIndex = 0;
            this.checkedListBoxOperator.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxOperator_SelectedIndexChanged);
            // 
            // labelOperator
            // 
            this.labelOperator.AutoSize = true;
            this.labelOperator.Location = new System.Drawing.Point(607, 9);
            this.labelOperator.Name = "labelOperator";
            this.labelOperator.Size = new System.Drawing.Size(64, 13);
            this.labelOperator.TabIndex = 1;
            this.labelOperator.Text = "Операторы";
            // 
            // labelRegion
            // 
            this.labelRegion.AutoSize = true;
            this.labelRegion.Location = new System.Drawing.Point(308, 9);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(54, 13);
            this.labelRegion.TabIndex = 1;
            this.labelRegion.Text = "Регионы:";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(12, 9);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(37, 13);
            this.labelCode.TabIndex = 1;
            this.labelCode.Text = "Коды:";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(12, 367);
            this.textBoxCode.Multiline = true;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.ReadOnly = true;
            this.textBoxCode.Size = new System.Drawing.Size(281, 211);
            this.textBoxCode.TabIndex = 2;
            // 
            // textBoxRegion
            // 
            this.textBoxRegion.Location = new System.Drawing.Point(311, 367);
            this.textBoxRegion.Multiline = true;
            this.textBoxRegion.Name = "textBoxRegion";
            this.textBoxRegion.ReadOnly = true;
            this.textBoxRegion.Size = new System.Drawing.Size(281, 211);
            this.textBoxRegion.TabIndex = 2;
            // 
            // textBoxOperator
            // 
            this.textBoxOperator.Location = new System.Drawing.Point(610, 367);
            this.textBoxOperator.Multiline = true;
            this.textBoxOperator.Name = "textBoxOperator";
            this.textBoxOperator.ReadOnly = true;
            this.textBoxOperator.Size = new System.Drawing.Size(320, 211);
            this.textBoxOperator.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(332, 584);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(506, 584);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxCodeAll
            // 
            this.checkBoxCodeAll.AutoSize = true;
            this.checkBoxCodeAll.Location = new System.Drawing.Point(15, 34);
            this.checkBoxCodeAll.Name = "checkBoxCodeAll";
            this.checkBoxCodeAll.Size = new System.Drawing.Size(45, 17);
            this.checkBoxCodeAll.TabIndex = 5;
            this.checkBoxCodeAll.Text = "Все";
            this.checkBoxCodeAll.UseVisualStyleBackColor = true;
            this.checkBoxCodeAll.CheckedChanged += new System.EventHandler(this.checkBoxCodeAll_CheckedChanged);
            // 
            // checkBoxRegionAll
            // 
            this.checkBoxRegionAll.AutoSize = true;
            this.checkBoxRegionAll.Location = new System.Drawing.Point(311, 34);
            this.checkBoxRegionAll.Name = "checkBoxRegionAll";
            this.checkBoxRegionAll.Size = new System.Drawing.Size(45, 17);
            this.checkBoxRegionAll.TabIndex = 5;
            this.checkBoxRegionAll.Text = "Все";
            this.checkBoxRegionAll.UseVisualStyleBackColor = true;
            this.checkBoxRegionAll.CheckedChanged += new System.EventHandler(this.checkBoxRegionAll_CheckedChanged);
            // 
            // checkBoxOperatorAll
            // 
            this.checkBoxOperatorAll.AutoSize = true;
            this.checkBoxOperatorAll.Location = new System.Drawing.Point(610, 34);
            this.checkBoxOperatorAll.Name = "checkBoxOperatorAll";
            this.checkBoxOperatorAll.Size = new System.Drawing.Size(45, 17);
            this.checkBoxOperatorAll.TabIndex = 5;
            this.checkBoxOperatorAll.Text = "Все";
            this.checkBoxOperatorAll.UseVisualStyleBackColor = true;
            this.checkBoxOperatorAll.CheckedChanged += new System.EventHandler(this.checkBoxOperatorAll_CheckedChanged);
            // 
            // FromDiapasonNewCodeRegionOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 633);
            this.Controls.Add(this.checkBoxOperatorAll);
            this.Controls.Add(this.checkBoxRegionAll);
            this.Controls.Add(this.checkBoxCodeAll);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxOperator);
            this.Controls.Add(this.textBoxRegion);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.labelOperator);
            this.Controls.Add(this.labelRegion);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.checkedListBoxOperator);
            this.Controls.Add(this.checkedListBoxRegion);
            this.Controls.Add(this.checkedListBoxCode);
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
    }
}