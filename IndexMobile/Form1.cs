using Entity.Common;
using IndexMobile.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
                List<Nameface> theListNameface = Nameface.GetAll();
                    foreach (var worksheet in theForm.pck.Workbook.Worksheets)
                    {
                        Log(theForm, "Обрабатываем страницу: " + worksheet.Name);
                        if (worksheet.Dimension == null)
                        {
                            Log(theForm, "Страница пуста - пропускаем");
                            continue;
                        }

                        worksheet.InsertColumn(2, 3);
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


                            string NameInCell = "";
                            if (worksheet.Cells[i, 5].Value != null)
                            {
                                NameInCell = worksheet.Cells[i, 5].Value.ToString();
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
                            //string tel_operator = IndexMobileCore.Helper.Telephone.Operator(Code, Number);
                            var theDEF = DEF.GetOperator(Code, Number);
                            if (theDEF != null)
                            {
                                Log(theForm, "Получено значение: tel_operator =  " + theDEF.Operator + " - " + theDEF.Region);
                                worksheet.Cells[i, 2].Value = theDEF.Operator;
                                worksheet.Cells[i, 3].Value = theDEF.Region;
                            }
                            else
                            {
                                Log(theForm, "Значение отсутствует");
                            }

                            string theName = "";
                            foreach (var item in NameInCell.Split(new char[] { ' ', '(' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                var list = theListNameface.Where(x => x.NameOff.ToLower() == item.ToLower());
                                if (list.Count() > 0)
                                {
                                    theName = list.ToList<Nameface>()[0].NameOn ;
                                    break;
                                }
                                else
                                {
                                    var check = theListNameface.Where(x => x.NameOn.ToLower() == item.ToLower());
                                    if (check.Count() > 0)
                                    {
                                        theName = check.ToList<Nameface>()[0].NameOn; 
                                        break;
                                    }
                                }
                                
                            }
                            worksheet.Cells[i, 4].Value = theName;


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
            if (textBox1.Text != "")
            {
                Clipboard.SetText(textBox1.Text);
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DateTime.Now > new DateTime(2017, 6, 1))
            {
                this.Close();
            }
            NHibernateHelper.UpdateSchema();
            this.textBox1.Text = "Формирование структуры БД завершено!" + this.textBox1.Text;
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Log(string msg)
        {
            this.textBox1.Text = msg + "\r\n" + this.textBox1.Text;
            Application.DoEvents();
        }

        private void обновитьСхемуToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                Application.UseWaitCursor = true;

                NHibernateHelper.UpdateSchema();
                string urlAddress = "https://www.rossvyaz.ru/docs/articles/DEF-9x.html";
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(urlAddress);

                Log("Выполняем запрос: " + urlAddress);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Log("Запрос выполнен");


                    StreamReader readStream = new StreamReader(req.GetResponse().GetResponseStream(), Encoding.GetEncoding(1251)); 

                    
                    string data = readStream.ReadToEnd();

                    Log("Данные прочитаны");

                    response.Close();
                    readStream.Close();

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;

                    data = data.Replace("<tr valign=\"top\">", "");
                    data = data.Replace("<td style=\"width:10%;text-align:center; vertical-align:top; font-weight: bold;\">АВС/ DEF</td>", "");
                    data = data.Replace("<td style=\"width:10%;text-align:center; vertical-align:top; font-weight: bold;\">От</td>", "");
                    data = data.Replace("<td style=\"width:10%;text-align:center; vertical-align:top; font-weight: bold;\">До</td>", "");
                    data = data.Replace("<td style=\"width:25%;text-align:center; vertical-align:top; font-weight: bold;\">Емкость</td>", "");
                    data = data.Replace("<td style=\"width:25%;text-align:center; vertical-align:top; font-weight: bold;\">Оператор</td>", "");
                    data = data.Replace("<td style=\"width:25%;text-align:center; vertical-align:top; font-weight: bold;\">Регион</td>", "");

                    doc.LoadHtml(data);

                    string xpathDivSelector = "//table";
                    var tagTBody = doc.DocumentNode.SelectSingleNode(xpathDivSelector);
                    if (tagTBody == null)
                    {
                        throw new Exception("Не обнаружен тег table");
                    }


                    

                    
                    
                    var tagTr = tagTBody.SelectNodes("//tr");
                    int CountTotal = tagTr.Count();
                    Log("Количество объектов: " + CountTotal.ToString());

                    Log("Удаление предыдущих записей");

                    string _connectionString = "Data Source=DEF.db";
                    using (var cn = new SQLiteConnection(_connectionString))
                    {
                        cn.Open();
                        using (var transaction = cn.BeginTransaction())
                        {
                            using (var cmd = cn.CreateCommand())
                            {
                                cmd.CommandText = "DELETE FROM DEF";
                            }

                            var results = new List<int>();
                            using(var cmdIns = cn.CreateCommand())
                            {
                                cmdIns.CommandText = @"INSERT INTO [DEF] ([NumberDEF], [NumberBgn], [NumberEnd], [Operator], [Region]) VALUES (@NumberDEF, @NumberBgn, @NumberEnd, @Operator, @Region)";                                
                                cmdIns.Parameters.AddWithValue("@NumberDEF", "0");
                                cmdIns.Parameters.AddWithValue("@NumberBgn", "0");
                                cmdIns.Parameters.AddWithValue("@NumberEnd", "0");
                                cmdIns.Parameters.AddWithValue("@Operator", "");
                                cmdIns.Parameters.AddWithValue("@Region", "");
                                
                                Log("Выполняем парсер");
                                foreach (var item in tagTr)
                                {
                                    cmdIns.Parameters["@NumberDEF"].Value = Convert.ToInt32(item.ChildNodes[1].InnerText.Trim(new char[] { '\t' }));
                                    cmdIns.Parameters["@NumberBgn"].Value = Convert.ToInt32(item.ChildNodes[2].InnerText.Trim(new char[] { '\t' }));
                                    cmdIns.Parameters["@NumberEnd"].Value = Convert.ToInt32(item.ChildNodes[3].InnerText.Trim(new char[] { '\t' }));
                                    cmdIns.Parameters["@Operator"].Value = item.ChildNodes[5].InnerText.Trim(new char[] { '\t' });
                                    cmdIns.Parameters["@Region"].Value = item.ChildNodes[6].InnerText.Trim(new char[] { '\t' });
                                    results.Add(cmdIns.ExecuteNonQuery());

                                }

                            }

                            int Sum = results.Sum();

                            Log("Завершено: " + Sum.ToString());

                            transaction.Commit();
                        }
                        cn.Close();
                    }


                    //var DelList = DEF.GetAll();
                    //int j = 0;
                    //foreach (var item in DelList)
                    //{
                    //    j++;
                    //    Log("Удаление: " + j.ToString() + "/" + DelList.Count());
                    //    item.Delete();
                    //}

                    //Log("Выполняем парсер");
                    //int i = 0;
                    //foreach (var item in tagTr)
                    //{
                    //    i++;
                    //    //Log("Объект: " + i.ToString() + "/" + CountTotal.ToString());

                    //    try
                    //    {
                    //        DEF theDEF = new DEF();
                    //        theDEF.NumberDEF = Convert.ToInt32(item.ChildNodes[1].InnerText.Trim(new char[] { '\t' }));
                    //        theDEF.NumberBgn = Convert.ToInt32(item.ChildNodes[2].InnerText.Trim(new char[] { '\t' }));
                    //        theDEF.NumberEnd = Convert.ToInt32(item.ChildNodes[3].InnerText.Trim(new char[] { '\t' }));
                    //        theDEF.Operator = item.ChildNodes[5].InnerText.Trim(new char[] { '\t' });
                    //        theDEF.Region = item.ChildNodes[6].InnerText.Trim(new char[] { '\t' });

                    //    //    theDEF.Save();

                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Log(ex.Message);
                    //    }
                        

                    //}

                    //int CountTotal = tagTBody.ChildNodes[1].ChildNodes.Count;
                    //Log("Количество объектов: " + CountTotal.ToString());
                    //int i = 0;
                    //foreach(var item in tagTBody.ChildNodes)
                    //{
                    //    i++;
                    //    Log("Объект: " + i.ToString() + "/" + CountTotal.ToString());

                        

                    //}
                }
                MessageBox.Show("Обновление завершено!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            
        }
    }
}
