namespace IndexMobile
{
    partial class Form
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
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.обновитьСхемуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button4 = new System.Windows.Forms.Button();
			this.buttonParserCompany = new System.Windows.Forms.Button();
			this.buttonParserPerson = new System.Windows.Forms.Button();
			this.buttonHelpCompany = new System.Windows.Forms.Button();
			this.buttonHelpPerson = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.buttonHelpEmail = new System.Windows.Forms.Button();
			this.buttonDiaposonGenerate = new System.Windows.Forms.Button();
			this.labelProcent = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 65);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Выберите файл (*.xlsx):";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Multiselect = true;
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(30, 96);
			this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(150, 44);
			this.button1.TabIndex = 1;
			this.button1.Text = "Типор";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(30, 152);
			this.textBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(1960, 898);
			this.textBox1.TabIndex = 2;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(192, 96);
			this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(150, 44);
			this.button3.TabIndex = 4;
			this.button3.Text = "Завершить";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
			this.menuStrip1.Size = new System.Drawing.Size(1992, 46);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьСхемуToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 38);
			this.toolStripMenuItem1.Text = "Настройки";
			this.toolStripMenuItem1.Visible = false;
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// обновитьСхемуToolStripMenuItem
			// 
			this.обновитьСхемуToolStripMenuItem.Name = "обновитьСхемуToolStripMenuItem";
			this.обновитьСхемуToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
			this.обновитьСхемуToolStripMenuItem.Text = "Обновить схему";
			this.обновитьСхемуToolStripMenuItem.Click += new System.EventHandler(this.обновитьСхемуToolStripMenuItem_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(500, 96);
			this.button4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(336, 44);
			this.button4.TabIndex = 6;
			this.button4.Text = "Электронные адреса";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// buttonParserCompany
			// 
			this.buttonParserCompany.Location = new System.Drawing.Point(976, 96);
			this.buttonParserCompany.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonParserCompany.Name = "buttonParserCompany";
			this.buttonParserCompany.Size = new System.Drawing.Size(150, 44);
			this.buttonParserCompany.TabIndex = 7;
			this.buttonParserCompany.Text = "Парсер Орг";
			this.buttonParserCompany.UseVisualStyleBackColor = true;
			this.buttonParserCompany.Click += new System.EventHandler(this.buttonParserCompany_Click);
			// 
			// buttonParserPerson
			// 
			this.buttonParserPerson.Location = new System.Drawing.Point(1350, 96);
			this.buttonParserPerson.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonParserPerson.Name = "buttonParserPerson";
			this.buttonParserPerson.Size = new System.Drawing.Size(162, 44);
			this.buttonParserPerson.TabIndex = 8;
			this.buttonParserPerson.Text = "Парсер Чел";
			this.buttonParserPerson.UseVisualStyleBackColor = true;
			this.buttonParserPerson.Click += new System.EventHandler(this.buttonParserPerson_Click);
			// 
			// buttonHelpCompany
			// 
			this.buttonHelpCompany.Location = new System.Drawing.Point(1138, 96);
			this.buttonHelpCompany.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonHelpCompany.Name = "buttonHelpCompany";
			this.buttonHelpCompany.Size = new System.Drawing.Size(60, 44);
			this.buttonHelpCompany.TabIndex = 9;
			this.buttonHelpCompany.Text = "?";
			this.buttonHelpCompany.UseVisualStyleBackColor = true;
			this.buttonHelpCompany.Click += new System.EventHandler(this.buttonHelpCompany_Click);
			// 
			// buttonHelpPerson
			// 
			this.buttonHelpPerson.Location = new System.Drawing.Point(1524, 96);
			this.buttonHelpPerson.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonHelpPerson.Name = "buttonHelpPerson";
			this.buttonHelpPerson.Size = new System.Drawing.Size(60, 44);
			this.buttonHelpPerson.TabIndex = 9;
			this.buttonHelpPerson.Text = "?";
			this.buttonHelpPerson.UseVisualStyleBackColor = true;
			this.buttonHelpPerson.Click += new System.EventHandler(this.buttonHelpPerson_Click);
			// 
			// buttonHelpEmail
			// 
			this.buttonHelpEmail.Location = new System.Drawing.Point(848, 96);
			this.buttonHelpEmail.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonHelpEmail.Name = "buttonHelpEmail";
			this.buttonHelpEmail.Size = new System.Drawing.Size(60, 44);
			this.buttonHelpEmail.TabIndex = 10;
			this.buttonHelpEmail.Text = "?";
			this.buttonHelpEmail.UseVisualStyleBackColor = true;
			this.buttonHelpEmail.Click += new System.EventHandler(this.buttonHelpEmail_Click);
			// 
			// buttonDiaposonGenerate
			// 
			this.buttonDiaposonGenerate.Location = new System.Drawing.Point(1636, 96);
			this.buttonDiaposonGenerate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.buttonDiaposonGenerate.Name = "buttonDiaposonGenerate";
			this.buttonDiaposonGenerate.Size = new System.Drawing.Size(332, 44);
			this.buttonDiaposonGenerate.TabIndex = 11;
			this.buttonDiaposonGenerate.Text = "Генерировать диапазон";
			this.buttonDiaposonGenerate.UseVisualStyleBackColor = true;
			this.buttonDiaposonGenerate.Click += new System.EventHandler(this.buttonDiaposonGenerate_Click);
			// 
			// labelProcent
			// 
			this.labelProcent.AutoSize = true;
			this.labelProcent.Location = new System.Drawing.Point(378, 106);
			this.labelProcent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.labelProcent.Name = "labelProcent";
			this.labelProcent.Size = new System.Drawing.Size(0, 25);
			this.labelProcent.TabIndex = 12;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1992, 1062);
			this.Controls.Add(this.labelProcent);
			this.Controls.Add(this.buttonDiaposonGenerate);
			this.Controls.Add(this.buttonHelpEmail);
			this.Controls.Add(this.buttonHelpPerson);
			this.Controls.Add(this.buttonHelpCompany);
			this.Controls.Add(this.buttonParserPerson);
			this.Controls.Add(this.buttonParserCompany);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.Name = "Form1";
			this.Text = "Определение сотового оператора";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem обновитьСхемуToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonParserCompany;
        private System.Windows.Forms.Button buttonParserPerson;
        private System.Windows.Forms.Button buttonHelpCompany;
        private System.Windows.Forms.Button buttonHelpPerson;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonHelpEmail;
        private System.Windows.Forms.Button buttonDiaposonGenerate;
        private System.Windows.Forms.Label labelProcent;
    }
}

