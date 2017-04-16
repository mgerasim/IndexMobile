namespace IndexMobileGenerate
{
    partial class FormAccess
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
            this.listBoxAccess = new System.Windows.Forms.ListBox();
            this.buttonAccessAdd = new System.Windows.Forms.Button();
            this.buttonAccessShow = new System.Windows.Forms.Button();
            this.buttonSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxAccess
            // 
            this.listBoxAccess.FormattingEnabled = true;
            this.listBoxAccess.Location = new System.Drawing.Point(13, 41);
            this.listBoxAccess.Name = "listBoxAccess";
            this.listBoxAccess.Size = new System.Drawing.Size(451, 290);
            this.listBoxAccess.TabIndex = 0;
            // 
            // buttonAccessAdd
            // 
            this.buttonAccessAdd.Location = new System.Drawing.Point(12, 12);
            this.buttonAccessAdd.Name = "buttonAccessAdd";
            this.buttonAccessAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAccessAdd.TabIndex = 1;
            this.buttonAccessAdd.Text = "Добавить";
            this.buttonAccessAdd.UseVisualStyleBackColor = true;
            this.buttonAccessAdd.Click += new System.EventHandler(this.buttonAccessAdd_Click);
            // 
            // buttonAccessShow
            // 
            this.buttonAccessShow.Location = new System.Drawing.Point(470, 41);
            this.buttonAccessShow.Name = "buttonAccessShow";
            this.buttonAccessShow.Size = new System.Drawing.Size(75, 23);
            this.buttonAccessShow.TabIndex = 2;
            this.buttonAccessShow.Text = "Показать";
            this.buttonAccessShow.UseVisualStyleBackColor = true;
            this.buttonAccessShow.Click += new System.EventHandler(this.buttonAccessShow_Click);
            // 
            // buttonSelection
            // 
            this.buttonSelection.Location = new System.Drawing.Point(471, 71);
            this.buttonSelection.Name = "buttonSelection";
            this.buttonSelection.Size = new System.Drawing.Size(75, 23);
            this.buttonSelection.TabIndex = 3;
            this.buttonSelection.Text = "Отобрать";
            this.buttonSelection.UseVisualStyleBackColor = true;
            this.buttonSelection.Click += new System.EventHandler(this.buttonSelection_Click);
            // 
            // FormAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 331);
            this.Controls.Add(this.buttonSelection);
            this.Controls.Add(this.buttonAccessShow);
            this.Controls.Add(this.buttonAccessAdd);
            this.Controls.Add(this.listBoxAccess);
            this.Name = "FormAccess";
            this.Text = "Мои выборки телефонных номеров";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAccess;
        private System.Windows.Forms.Button buttonAccessAdd;
        private System.Windows.Forms.Button buttonAccessShow;
        private System.Windows.Forms.Button buttonSelection;

    }
}

