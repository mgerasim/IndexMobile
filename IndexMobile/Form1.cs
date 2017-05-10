using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexMobile
{
    public partial class Form1 : Form
    {
        bool isStop = false;
        ExcelPackage pck = null;
        Thread th;
        public Form1()
        {
            InitializeComponent();
            this.button3.Enabled = false;
            timer1.Start();

            openFileDialog1.Filter = "Excel файлы (.xlsx, .xls)|*.xlsx;*.xls|Все файлы (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            textBox1.Text = value + "\r\n" + textBox1.Text; 
        }
       
        static private void Log(Form1 theForm, string msg)
        {
            //theForm.textBox1.Text = msg + "\r\n" + theForm.textBox1.Text;
            theForm.AppendTextBox(msg);
        }

        private void ExecuteInForeground(Object obj)
        {
            Form1 theForm = (Form1)obj;
            try
            {
                    foreach (var worksheet in theForm.pck.Workbook.Worksheets)
                    {
                        Log(theForm, "Обрабатываем страницу: " + worksheet.Name);
                        if (worksheet.Dimension == null)
                        {
                            Log(theForm, "Страница пуста - пропускаем");
                            continue;
                        }
                        worksheet.InsertColumn(2, 1);
                        var rowCnt = worksheet.Dimension.End.Row;
                        Log(theForm, "Кол-во строк в странице: " + rowCnt.ToString());
                        for (int i = 2; i <= rowCnt; i++)
                        {
                            Application.DoEvents();

                            if (theForm.isStop == true)
                            {
                                Log(theForm, "Принудительное завершение");
                                theForm.pck.Save();
                                return;
                            }
                            if (worksheet.Cells[i, 1].Value == null)
                            {
                                Log(theForm, "Значение в " + i.ToString() + " строке - отсутствует - пропускаем ");
                                continue;
                            }
                            string tel = worksheet.Cells[i, 1].Value.ToString();
                            Log(theForm, "Значение в " + i.ToString() + " строке: " + tel);
                            tel = tel.Replace(" ", "");
                            tel = tel.Replace("+", "");
                            tel = tel.Replace("-", "");
                            Log(theForm, "Значение в " + i.ToString() + " строке - после обработки: " + tel);
                            if (tel.Length < 10)
                            {
                                Log(theForm, "Значение в " + i.ToString() + " строке - меньше 10 по длине - пропускаем ");
                                continue;
                            }
                            tel = IndexMobileCore.Helper.Telephone.Reverse(tel);
                            tel = tel.Substring(0, 10);
                            tel = IndexMobileCore.Helper.Telephone.Reverse(tel);
                            string _Code = tel.Substring(0, 3);
                            string _Number = tel.Substring(3, 7);
                            Log(theForm, "_Code - " + _Code);
                            Log(theForm, "_Number - " + _Number);

                            int Code = 0; Convert.ToInt32(_Code);
                            int Number = 0; Convert.ToInt32(_Number);

                            try
                            {
                                Code = Convert.ToInt32(_Code);
                                Number = Convert.ToInt32(_Number);
                            }
                            catch
                            {
                                Log(theForm, "Ошибка при определении Code и Number");
                            }
                            Log(theForm, "Вызываем: IndexMobileCore.Helper.Telephone.Operator(" + Code.ToString() + ", " + Number.ToString() + ")");
                            string tel_operator = IndexMobileCore.Helper.Telephone.Operator(Code, Number);
                            Log(theForm, "Получено значение: tel_operator =  " + tel_operator);
                            worksheet.Cells[i, 2].Value = tel_operator;
                            Log(theForm, "Завершено!");
                        }
                    }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                err += ex.StackTrace;
                Log(theForm, err);
            }
            finally
            {
                Log(theForm, "Выход");
                theForm.pck.Save();
                th.Abort();
                th = null;


                theForm.button1.Enabled = true;
                theForm.button3.Enabled = false;
                theForm.button3_Click(null, null);
                theForm.Update();

                this.button1.Enabled = true;
                this.button3.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                th = new Thread(ExecuteInForeground);

                this.button1.Enabled = false;
                this.button3.Enabled = true;
                this.isStop = false;
                Log(this, "Начало обработки");
                this.UseWaitCursor = true;

                Log(this, "Выбран файл: " + Path.GetFileName(this.openFileDialog1.FileName));

                FileInfo newFile = new FileInfo(this.openFileDialog1.FileName);

                pck = new ExcelPackage(newFile);

                
                th.Start(this);

                
                Log(this, "Завершено!");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                err += ex.StackTrace;
                Log(this, err);
            }
            finally
            {
                this.UseWaitCursor = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.isStop = true;

            this.button1.Enabled = true;
            this.button3.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (th != null) {
                if (th.IsAlive == false)
                {
                    this.button1.Enabled = true;
                    this.button3.Enabled = false;
                }
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            
                
            if (this.th != null)
            {
                this.th.Abort();
                this.th = null;
            }
            
           
        }
    }
}
