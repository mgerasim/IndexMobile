namespace IndexMobileGenerate
{
    partial class FormSelection
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
            this.listBoxSelection = new System.Windows.Forms.ListBox();
            this.buttonSelectionNew = new System.Windows.Forms.Button();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxSelection
            // 
            this.listBoxSelection.FormattingEnabled = true;
            this.listBoxSelection.Location = new System.Drawing.Point(12, 75);
            this.listBoxSelection.Name = "listBoxSelection";
            this.listBoxSelection.Size = new System.Drawing.Size(259, 212);
            this.listBoxSelection.TabIndex = 0;
            // 
            // buttonSelectionNew
            // 
            this.buttonSelectionNew.Location = new System.Drawing.Point(118, 37);
            this.buttonSelectionNew.Name = "buttonSelectionNew";
            this.buttonSelectionNew.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectionNew.TabIndex = 1;
            this.buttonSelectionNew.Text = "Добавить";
            this.buttonSelectionNew.UseVisualStyleBackColor = true;
            this.buttonSelectionNew.Click += new System.EventHandler(this.buttonSelectionNew_Click);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(12, 39);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxCount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Укажите количество телефонных номеров:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(118, 293);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Завершить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(277, 75);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(75, 23);
            this.buttonShow.TabIndex = 5;
            this.buttonShow.Text = "Показать";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // FormSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 322);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.buttonSelectionNew);
            this.Controls.Add(this.listBoxSelection);
            this.Name = "FormSelection";
            this.Text = "Отборы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSelection;
        private System.Windows.Forms.Button buttonSelectionNew;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonShow;
    }
}