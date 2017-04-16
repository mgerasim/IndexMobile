namespace IndexMobileGenerate
{
    partial class FormAccessNew
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
            this.listBoxDiapason = new System.Windows.Forms.ListBox();
            this.buttonDiapasonAdd = new System.Windows.Forms.Button();
            this.buttonAccessOk = new System.Windows.Forms.Button();
            this.textBoxAccessName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxDiapason
            // 
            this.listBoxDiapason.FormattingEnabled = true;
            this.listBoxDiapason.Location = new System.Drawing.Point(12, 67);
            this.listBoxDiapason.Name = "listBoxDiapason";
            this.listBoxDiapason.Size = new System.Drawing.Size(326, 186);
            this.listBoxDiapason.TabIndex = 0;
            // 
            // buttonDiapasonAdd
            // 
            this.buttonDiapasonAdd.Location = new System.Drawing.Point(12, 12);
            this.buttonDiapasonAdd.Name = "buttonDiapasonAdd";
            this.buttonDiapasonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonDiapasonAdd.TabIndex = 1;
            this.buttonDiapasonAdd.Text = "Добавить";
            this.buttonDiapasonAdd.UseVisualStyleBackColor = true;
            this.buttonDiapasonAdd.Click += new System.EventHandler(this.buttonDiapasonAdd_Click);
            // 
            // buttonAccessOk
            // 
            this.buttonAccessOk.Location = new System.Drawing.Point(12, 259);
            this.buttonAccessOk.Name = "buttonAccessOk";
            this.buttonAccessOk.Size = new System.Drawing.Size(75, 23);
            this.buttonAccessOk.TabIndex = 2;
            this.buttonAccessOk.Text = "Завершить";
            this.buttonAccessOk.UseVisualStyleBackColor = true;
            this.buttonAccessOk.Click += new System.EventHandler(this.buttonAccessOk_Click);
            // 
            // textBoxAccessName
            // 
            this.textBoxAccessName.Location = new System.Drawing.Point(12, 41);
            this.textBoxAccessName.Name = "textBoxAccessName";
            this.textBoxAccessName.Size = new System.Drawing.Size(326, 20);
            this.textBoxAccessName.TabIndex = 3;
            // 
            // FormAccessNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 287);
            this.Controls.Add(this.textBoxAccessName);
            this.Controls.Add(this.buttonAccessOk);
            this.Controls.Add(this.buttonDiapasonAdd);
            this.Controls.Add(this.listBoxDiapason);
            this.Name = "FormAccessNew";
            this.Text = "Выборка телефонных номеров";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDiapason;
        private System.Windows.Forms.Button buttonDiapasonAdd;
        private System.Windows.Forms.Button buttonAccessOk;
        private System.Windows.Forms.TextBox textBoxAccessName;
    }
}