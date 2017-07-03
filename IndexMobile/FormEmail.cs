using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexMobile
{
    public partial class FormEmail : Form
    {
        public FormEmail()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                int currPathIndex = 0;
                foreach(var path in this.openFileDialog1.FileNames)
                {
                    currPathIndex++;
                    this.label1.Text = String.Format("Загружено: {0} из {1}", currPathIndex, openFileDialog1.FileNames.Count());
                    Application.DoEvents();

                    FileInfo newFile = new FileInfo(path);

                    if (Path.GetExtension(path) == ".csv")
                    {
                        string data = File.ReadAllText(path);
                        //instantiate with this pattern 
                        Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                            RegexOptions.IgnoreCase);
                        //find items that matches with our pattern
                        MatchCollection emailMatches = emailRegex.Matches(data);

                        StringBuilder sb = new StringBuilder();

                        foreach (Match emailMatch in emailMatches)
                        {
                            if (this.listBox1.Items.Contains(emailMatch.Value))
                            {
                                continue;
                            }
                            this.listBox1.Items.Add(emailMatch.Value);
                        }
                        continue;
                    }

                    ExcelPackage pck = new ExcelPackage(newFile);

                    foreach (var worksheet in pck.Workbook.Worksheets)
                    {
                        if (worksheet.Dimension == null)
                        {
                            continue;
                        }

                        var rowCnt = worksheet.Dimension.End.Row;
                        var colCnt = worksheet.Dimension.End.Column;

                        for (int i = 1; i <= rowCnt; i++)
                            for (int j = 1; j <= colCnt; j++)
                            {
                                if (worksheet.Cells[i, j].Value == null)
                                {
                                    continue;
                                }

                                string CellValue = worksheet.Cells[i, j].Value.ToString();
                                if (CellValue.Length == 0)
                                {
                                    continue;
                                }

                                string data = CellValue;
                                //instantiate with this pattern 
                                Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                                    RegexOptions.IgnoreCase);
                                //find items that matches with our pattern
                                MatchCollection emailMatches = emailRegex.Matches(data);

                                StringBuilder sb = new StringBuilder();

                                foreach (Match emailMatch in emailMatches)
                                {
                                    if (this.listBox1.Items.Contains(emailMatch.Value))
                                    {
                                        continue;
                                    }
                                    this.listBox1.Items.Add(emailMatch.Value);
                                }


                            }

                    }
                }
                

            

            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
            finally
            {

                labelCount.Text = this.listBox1.Items.Count.ToString();
            }

        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string DirName = "emails";
                if (!Directory.Exists(DirName))
                {
                    Directory.CreateDirectory(DirName);
                }

                //string FileName = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                string FileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
                FileName = Directory.GetCurrentDirectory() + @"\" + DirName + @"\" + FileName + ".csv";

                //File.Create(FileName);

                using (StreamWriter myOutputStream = new StreamWriter(FileName))
                {
                    foreach (var item in listBox1.Items)
                    {
                        if (IsValidEmail(item.ToString())) 
                        {
                            myOutputStream.WriteLine(item.ToString()); 
                        }
                        
                    }
                }
                MessageBox.Show("Сохранено в " + FileName);
            }
            catch (Exception ex)
            {
                this.listBox1.Items.Add(ex.Message);
            }
        }

        private void FormEmail_Load(object sender, EventArgs e)
        {

        }
    }
}
