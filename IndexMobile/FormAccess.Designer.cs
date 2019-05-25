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
			this.buttonDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxAccess
			// 
			this.listBoxAccess.FormattingEnabled = true;
			this.listBoxAccess.ItemHeight = 25;
			this.listBoxAccess.Location = new System.Drawing.Point(26, 79);
			this.listBoxAccess.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.listBoxAccess.Name = "listBoxAccess";
			this.listBoxAccess.Size = new System.Drawing.Size(898, 554);
			this.listBoxAccess.TabIndex = 0;
			// 
			// buttonAccessAdd
			// 
			this.buttonAccessAdd.Location = new System.Drawing.Point(24, 23);
			this.buttonAccessAdd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonAccessAdd.Name = "buttonAccessAdd";
			this.buttonAccessAdd.Size = new System.Drawing.Size(150, 44);
			this.buttonAccessAdd.TabIndex = 1;
			this.buttonAccessAdd.Text = "Добавить";
			this.buttonAccessAdd.UseVisualStyleBackColor = true;
			this.buttonAccessAdd.Click += new System.EventHandler(this.buttonAccessAdd_Click);
			// 
			// buttonAccessShow
			// 
			this.buttonAccessShow.Location = new System.Drawing.Point(940, 79);
			this.buttonAccessShow.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonAccessShow.Name = "buttonAccessShow";
			this.buttonAccessShow.Size = new System.Drawing.Size(150, 44);
			this.buttonAccessShow.TabIndex = 2;
			this.buttonAccessShow.Text = "Показать";
			this.buttonAccessShow.UseVisualStyleBackColor = true;
			this.buttonAccessShow.Click += new System.EventHandler(this.buttonAccessShow_Click);
			// 
			// buttonSelection
			// 
			this.buttonSelection.Location = new System.Drawing.Point(942, 137);
			this.buttonSelection.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonSelection.Name = "buttonSelection";
			this.buttonSelection.Size = new System.Drawing.Size(150, 44);
			this.buttonSelection.TabIndex = 3;
			this.buttonSelection.Text = "Отобрать";
			this.buttonSelection.UseVisualStyleBackColor = true;
			this.buttonSelection.Click += new System.EventHandler(this.buttonSelection_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(940, 298);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(148, 50);
			this.buttonDelete.TabIndex = 4;
			this.buttonDelete.Text = "Удалить";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// FormAccess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1514, 637);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonSelection);
			this.Controls.Add(this.buttonAccessShow);
			this.Controls.Add(this.buttonAccessAdd);
			this.Controls.Add(this.listBoxAccess);
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.Name = "FormAccess";
			this.Text = "Мои выборки телефонных номеров";
			this.Load += new System.EventHandler(this.FormAccess_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAccess;
        private System.Windows.Forms.Button buttonAccessAdd;
        private System.Windows.Forms.Button buttonAccessShow;
        private System.Windows.Forms.Button buttonSelection;
		private System.Windows.Forms.Button buttonDelete;
	}
}

