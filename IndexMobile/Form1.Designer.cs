namespace IndexMobile
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьСхемуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonParserCompany = new System.Windows.Forms.Button();
            this.buttonParserPerson = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.buttonHelpCompany = new System.Windows.Forms.Button();
            this.buttonHelpPerson = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonHelpEmail = new System.Windows.Forms.Button();
            this.buttonDiaposonGenerate = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите файл (*.xlsx):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 79);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(982, 469);
            this.textBox1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(108, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Завершить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьСхемуToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(79, 20);
            this.toolStripMenuItem1.Text = "Настройки";
            this.toolStripMenuItem1.Visible = false;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // обновитьСхемуToolStripMenuItem
            // 
            this.обновитьСхемуToolStripMenuItem.Name = "обновитьСхемуToolStripMenuItem";
            this.обновитьСхемуToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.обновитьСхемуToolStripMenuItem.Text = "Обновить схему";
            this.обновитьСхемуToolStripMenuItem.Click += new System.EventHandler(this.обновитьСхемуToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(250, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Электронные адреса";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonParserCompany
            // 
            this.buttonParserCompany.Location = new System.Drawing.Point(488, 50);
            this.buttonParserCompany.Name = "buttonParserCompany";
            this.buttonParserCompany.Size = new System.Drawing.Size(75, 23);
            this.buttonParserCompany.TabIndex = 7;
            this.buttonParserCompany.Text = "Парсер Орг";
            this.buttonParserCompany.UseVisualStyleBackColor = true;
            this.buttonParserCompany.Click += new System.EventHandler(this.buttonParserCompany_Click);
            // 
            // buttonParserPerson
            // 
            this.buttonParserPerson.Location = new System.Drawing.Point(675, 50);
            this.buttonParserPerson.Name = "buttonParserPerson";
            this.buttonParserPerson.Size = new System.Drawing.Size(81, 23);
            this.buttonParserPerson.TabIndex = 8;
            this.buttonParserPerson.Text = "Парсер Чел";
            this.buttonParserPerson.UseVisualStyleBackColor = true;
            this.buttonParserPerson.Click += new System.EventHandler(this.buttonParserPerson_Click);
            // 
            // buttonHelpCompany
            // 
            this.buttonHelpCompany.Location = new System.Drawing.Point(569, 50);
            this.buttonHelpCompany.Name = "buttonHelpCompany";
            this.buttonHelpCompany.Size = new System.Drawing.Size(30, 23);
            this.buttonHelpCompany.TabIndex = 9;
            this.buttonHelpCompany.Text = "?";
            this.buttonHelpCompany.UseVisualStyleBackColor = true;
            this.buttonHelpCompany.Click += new System.EventHandler(this.buttonHelpCompany_Click);
            // 
            // buttonHelpPerson
            // 
            this.buttonHelpPerson.Location = new System.Drawing.Point(762, 50);
            this.buttonHelpPerson.Name = "buttonHelpPerson";
            this.buttonHelpPerson.Size = new System.Drawing.Size(30, 23);
            this.buttonHelpPerson.TabIndex = 9;
            this.buttonHelpPerson.Text = "?";
            this.buttonHelpPerson.UseVisualStyleBackColor = true;
            this.buttonHelpPerson.Click += new System.EventHandler(this.buttonHelpPerson_Click);
            // 
            // buttonHelpEmail
            // 
            this.buttonHelpEmail.Location = new System.Drawing.Point(424, 50);
            this.buttonHelpEmail.Name = "buttonHelpEmail";
            this.buttonHelpEmail.Size = new System.Drawing.Size(30, 23);
            this.buttonHelpEmail.TabIndex = 10;
            this.buttonHelpEmail.Text = "?";
            this.buttonHelpEmail.UseVisualStyleBackColor = true;
            this.buttonHelpEmail.Click += new System.EventHandler(this.buttonHelpEmail_Click);
            // 
            // buttonDiaposonGenerate
            // 
            this.buttonDiaposonGenerate.Location = new System.Drawing.Point(818, 50);
            this.buttonDiaposonGenerate.Name = "buttonDiaposonGenerate";
            this.buttonDiaposonGenerate.Size = new System.Drawing.Size(166, 23);
            this.buttonDiaposonGenerate.TabIndex = 11;
            this.buttonDiaposonGenerate.Text = "Генерировать диапозон";
            this.buttonDiaposonGenerate.UseVisualStyleBackColor = true;
            this.buttonDiaposonGenerate.Click += new System.EventHandler(this.buttonDiaposonGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 552);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem обновитьСхемуToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonParserCompany;
        private System.Windows.Forms.Button buttonParserPerson;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button buttonHelpCompany;
        private System.Windows.Forms.Button buttonHelpPerson;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonHelpEmail;
        private System.Windows.Forms.Button buttonDiaposonGenerate;
    }
}

