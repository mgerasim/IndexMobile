using Entity.Common;
using IndexMobileEntity.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IndexMobile
{
	public partial class FormMain : System.Windows.Forms.Form
    {
        bool isStop = false;
        ExcelPackage pck = null;
        Thread th;
        public FormMain()
        {
            InitializeComponent();
            this.button3.Enabled = false;

            openFileDialog1.Filter = "Excel файлы (.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
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
       
        static private void Log(FormMain theForm, string msg)
        {
            //theForm.textBox1.Text = msg + "\r\n" + theForm.textBox1.Text;
            theForm.AppendTextBox(msg);
        }

        private void ExecuteInForeground(Object obj)
        {
            FormMain theForm = (FormMain)obj;
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
                            
                            string tel = IndexMobileCore.Helper.Telephone.Normalize(worksheet.Cells[i, 1].Value.ToString());
                            if (tel.Length < 10)
                            {
                                Log(theForm, "Значение в " + i.ToString() + " строке - меньше 10 по длине - пропускаем ");
                                continue;
                            }

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
                                if (item.Length == 1)
                                {
                                    continue;
                                }
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
                
                this.button1.Enabled = false;
                this.button3.Enabled = true;
                this.isStop = false;
                Log( "Начало обработки");

                ulong ProcentTotal = 0;
                ulong ProcentCurr = 0;

                Dictionary<string, int> theTipor = new Dictionary<string, int>();

                foreach (var pathSelect in this.openFileDialog1.FileNames)
                {
                    FileInfo newFile = new FileInfo(pathSelect);

                    pck = new ExcelPackage(newFile);

                    try
                    {
                        foreach (var worksheet in this.pck.Workbook.Worksheets)
                        {
                            if (worksheet.Dimension == null)
                            {
                                continue;
                            }

                            var rowCnt = (ulong) worksheet.Dimension.End.Row;
                            ProcentTotal += rowCnt;
                        }
                    }
                    catch
                    {

                    }
                }



                foreach(var pathSelect in this.openFileDialog1.FileNames)
                {
                    Log("Выбран файл: " + Path.GetFileName(this.openFileDialog1.FileName));

                    FileInfo newFile = new FileInfo(pathSelect);

                    pck = new ExcelPackage(newFile);

                    try
                    {
                        List<Nameface> theListNameface = Nameface.GetAll();
                        foreach (var worksheet in this.pck.Workbook.Worksheets)
                        {
                            Log("Обрабатываем страницу: " + worksheet.Name);
                            if (worksheet.Dimension == null)
                            {
                                Log("Страница пуста - пропускаем");
                                continue;
                            }

                            worksheet.InsertColumn(2, 4);
                            var rowCnt = worksheet.Dimension.End.Row;
                            Log("Кол-во строк в странице: " + rowCnt.ToString());
                            for (int i = 2; i <= rowCnt; i++)
                            {
                                ProcentCurr++;

                                this.labelProcent.Text = ((decimal)ProcentCurr / (decimal)ProcentTotal * 100).ToString("0");

                                Application.DoEvents();

                                if (this.isStop == true)
                                {
                                    Log("Принудительное завершение");
                                    this.pck.Save();
                                    return;
                                }
                                if (worksheet.Cells[i, 1].Value == null)
                                {
                                    Log("Значение в " + i.ToString() + " строке - отсутствует - пропускаем ");
                                    continue;
                                }

                                string NameInCell = "";
                                if (worksheet.Cells[i, 6].Value != null)
                                {
                                    NameInCell = worksheet.Cells[i, 6].Value.ToString();
                                }

                                string tel = IndexMobileCore.Helper.Telephone.Normalize(worksheet.Cells[i, 1].Value.ToString());
                                if (tel.Length < 10)
                                {
                                    Log("Значение в " + i.ToString() + " строке - меньше 10 по длине - пропускаем ");

                                    worksheet.DeleteRow(i); i--; rowCnt--;
                                    continue;
                                }

                                if (tel[0] != '9')
                                {
                                    Log("Не пройдена проверка: не имеют сотового номера (89..,+79..,79) ");
                                    worksheet.DeleteRow(i); i--; rowCnt--;
                                    continue;
                                }

                                string _Code = tel.Substring(0, 3);
                                string _Number = tel.Substring(3, 7);
                                Log("_Code - " + _Code);
                                Log("_Number - " + _Number);

                                int Code = 0; Convert.ToInt32(_Code);
                                int Number = 0; Convert.ToInt32(_Number);

                                try
                                {
                                    Code = Convert.ToInt32(_Code);
                                    Number = Convert.ToInt32(_Number);
                                }
                                catch
                                {
                                    Log("Ошибка при определении Code и Number");
                                }
                                Log("Вызываем: IndexMobileCore.Helper.Telephone.Operator(" + Code.ToString() + ", " + Number.ToString() + ")");

                                string NumberTel = String.Format("8{0}{1}", _Code, _Number);
                                if (theTipor.ContainsKey(NumberTel))
                                {
                                    worksheet.DeleteRow(i); i--; rowCnt--;
                                    continue;
                                }
                                else
                                {
                                    theTipor.Add(NumberTel, i);
                                }

                                worksheet.Cells[i, 1].Value = NumberTel;

                                var theDEF = DEF.GetOperator(Code, Number);
                                if (theDEF != null)
                                {
                                    Log("Получено значение: tel_operator =  " + theDEF.Operator + " - " + theDEF.Region);
                                    worksheet.Cells[i, 4].Value = theDEF.Operator;
                                    worksheet.Cells[i, 5].Value = theDEF.Region;
                                }
                                else
                                {
                                    Log("Значение отсутствует");
                                }

                                string theName = "";
                                foreach (var item in NameInCell.Split(new char[] { ' ', '(' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    if (item.Length == 1)
                                    {
                                        continue;
                                    }
                                    var list = theListNameface.Where(x => x.NameOff.ToLower() == item.ToLower() || Nameface.NameOffTranslate(item).ToLower() == x.NameOff.ToLower());
                                    if (list.Count() > 0)
                                    {
                                        theName = list.ToList<Nameface>()[0].NameOn;
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
                                worksheet.Cells[i, 2].Value = theName;

                                if (theName.Length > 0)
                                {
                                    if ((IndexMobileCore.Helper.Telephone.Reverse(theName)[0] == 'а' || IndexMobileCore.Helper.Telephone.Reverse(theName)[0] == 'А' || IndexMobileCore.Helper.Telephone.Reverse(theName)[0] == 'я' || IndexMobileCore.Helper.Telephone.Reverse(theName)[0] == 'Я') && theName.ToUpper() != "ИЛЬЯ")
                                    {
                                        worksheet.Cells[i, 3].Value = "Ж";
                                    }
                                    else
                                    {
                                        worksheet.Cells[i, 3].Value = "M";
                                    }
                                }
                                else
                                {
                                    worksheet.Cells[i, 3].Value = "M";
                                }
                            }
                            worksheet.Cells[1, 1].Value = "Телефон";
                            worksheet.Cells[1, 2].Value = "Имя";
                            worksheet.Cells[1, 3].Value = "Пол";
                            worksheet.Cells[1, 4].Value = "Оператор";
                            worksheet.Cells[1, 5].Value = "Регион";
                        }

                        pck.Save();
                    }
                    catch (Exception ex)
                    {
                        string err = ex.Message;
                        err += ex.StackTrace;
                        Log(err);
                    }

                }

                this.labelProcent.Text = "100%";
                Log( "Завершено!");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                err += ex.StackTrace;
                Log( err);
            }
            finally
            {

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


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                
            if (this.th != null)
            {
                this.th.Abort();
                this.th = null;
            }
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            NHibernateHelper.UpdateSchema();

            this.textBox1.Text = "Формирование структуры БД завершено!" + this.textBox1.Text;

			throw new IndexOutOfRangeException();
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

                    string _connectionString = NHibernateHelper.ConnectionString;

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

        private void button4_Click(object sender, EventArgs e)
        {
            FormEmail theForm = new FormEmail();
            theForm.ShowDialog();
        }

        private void buttonParserCompany_Click(object sender, EventArgs e)
        {            
            try 
            {
                if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string[] files = Directory.GetFiles(this.folderBrowserDialog1.SelectedPath);
                                      
                Log( "Начало обработки");
                this.UseWaitCursor = true;

                ulong ProcentTotal = 0;
                ulong ProcentCurr = 0;
                
                foreach (var pathSelect in files)
                {
                    if (Path.GetExtension(pathSelect) != ".xlsx")
                    {
                        Log("Формат файла не поддерживается: " + Path.GetExtension(pathSelect));
                        continue;
                    }

                    FileInfo newFile = new FileInfo(pathSelect);

                    pck = new ExcelPackage(newFile);

                    try
                    {
                        foreach (var worksheet in this.pck.Workbook.Worksheets)
                        {
                            if (worksheet.Dimension == null)
                            {
                                continue;
                            }

                            var rowCnt = (ulong)worksheet.Dimension.End.Row;
                            ProcentTotal += rowCnt;
                        }
                    }
                    catch
                    {

                    }
                }

                foreach(var file in files) 
                {
                    try
                    {
                        Log( "Выбран файл: " + Path.GetFileName(file));

                        if (Path.GetExtension(file) != ".xlsx")
                        {
                            Log("Формат файла не поддерживается: " + Path.GetExtension(file));
                            continue;
                        }

                        FileInfo newFile = new FileInfo(file);

                        ExcelPackage _pck = new ExcelPackage(newFile);

                        foreach (var worksheet in _pck.Workbook.Worksheets)
                        {
                            int ColumnName = -1;
                            int ColumnSaite = -1;
                            int ColumnEmail = -1;
                            int ColumnTelephone = -1;
                            int ColumnRubrika = -1;

                            Log( "Обрабатываем страницу: " + worksheet.Name);
                            if (worksheet.Dimension == null)
                            {
                                Log( "Страница пуста - пропускаем");
                                continue;
                            }
                            var rowCnt = worksheet.Dimension.End.Row;
                            var colCnt = worksheet.Dimension.End.Column;
                            for (int i = 1; i <= colCnt; i++)
                            {
                                if (worksheet.Cells[1, i] == null)
                                {
                                    continue;
                                }
                                if (worksheet.Cells[1, i].Value == null)
                                {
                                    continue;
                                }
                                switch (worksheet.Cells[1, i].Value.ToString().Trim())
                                {
                                    case "Название":
                                        ColumnName = i;
                                        break;
                                    case "Сайт":
                                        ColumnSaite = i;
                                        break;
                                    case "Email":
                                        ColumnEmail = i;
                                        break;
                                    case "Телефоны":
                                        ColumnTelephone = i;
                                        break;
                                    case "Рубрика":
                                        ColumnRubrika = i;
                                        break;
                                }
                            }

                            string Notify = "";
                            if (ColumnName < 0)
                            {
                                Notify += "\nНазвание";
                            }
                            if (ColumnSaite < 0)
                            {
                                Notify += "\nСайт";
                            }
                            if (ColumnEmail < 0)
                            {
                                Notify += "\nEmail";
                            }
                            if (ColumnTelephone < 0)
                            {
                                Notify += "\nТелефоны";
                            }
                            if (ColumnRubrika < 0)
                            {
                                Notify += "\nРубрика";
                            }

                            if (Notify.Length > 0)
                            {
                                Notify = "Отсутствуют поля: " + Notify;
                                Log( Notify);
                                break ;
                            }

                            string DirName = "ParserCompany";
                            if (!Directory.Exists(DirName))
                            {
                                Directory.CreateDirectory(DirName);
                            }

                           // var colCnt = worksheet.Dimension.End.Column;

                            string FileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
                            FileName = Directory.GetCurrentDirectory() + @"\" + DirName + @"\" + FileName + ".xlsx";
                            var existingFile = new FileInfo(FileName);

                            using (var package = new ExcelPackage(existingFile))
                            {
                                var workbook = package.Workbook;

                                var worksheet1 = workbook.Worksheets.Add(worksheet.Name);

                                List<ParserCompany> theList = new List<ParserCompany>();

                                for (int i = 1; i <= rowCnt; i++)
                                {
                                    ProcentCurr++;
                                    this.labelProcent.Text = ((decimal)ProcentCurr / (decimal)ProcentTotal * 100).ToString("0");
                                    Application.DoEvents();

                                    ParserCompany data = new ParserCompany();
                                    data.Telephone = GetValueFromCell(worksheet.Cells[i, ColumnTelephone]);
                                    data.Name = GetValueFromCell(worksheet.Cells[i, ColumnName]);
                                    data.Email = GetValueFromCell(worksheet.Cells[i, ColumnEmail]);
                                    data.Saite = GetValueFromCell(worksheet.Cells[i, ColumnSaite]);
                                    data.Rubrika = GetValueFromCell(worksheet.Cells[i, ColumnRubrika]);
                                    /**/
                                    string tel = IndexMobileCore.Helper.Telephone.Normalize(data.Telephone);
                                    if (tel.Length < 10)
                                    {
                                        Log("Значение в " + i.ToString() + " строке - меньше 10 по длине - пропускаем ");
                                        continue;
                                    }

                                    if (tel[0] != '9')
                                    {
                                        Log("Не пройдена проверка: не имеют сотового номера (89..,+79..,79) ");                                        
                                        continue;
                                    }

                                    string _Code = tel.Substring(0, 3);
                                    string _Number = tel.Substring(3, 7);
                                    Log("_Code - " + _Code);
                                    Log("_Number - " + _Number);

                                    int Code = 0;
                                    int Number = 0; 

                                    try
                                    {
                                        Convert.ToInt32(_Code);
                                        Convert.ToInt32(_Number);
                                        Code = Convert.ToInt32(_Code);
                                        Number = Convert.ToInt32(_Number);
                                    }
                                    catch
                                    {
                                        Log("Ошибка при определении Code и Number");
                                        continue;
                                    }
                                    Log("Вызываем: IndexMobileCore.Helper.Telephone.Operator(" + Code.ToString() + ", " + Number.ToString() + ")");

                                    string NumberTel = String.Format("8{0}{1}", _Code, _Number);

                                    data.Telephone = NumberTel;

                                    var theDEF = DEF.GetOperator(Code, Number);
                                    if (theDEF != null)
                                    {
                                        Log("Получено значение: tel_operator =  " + theDEF.Operator + " - " + theDEF.Region);
                                        data.Operator = theDEF.Operator;
                                        data.Region = theDEF.Region;
                                    }
                                    else
                                    {
                                        Log("Значение отсутствует");
                                    }

                                    /**/

                                    if (theList.Count(x => x.Telephone == data.Telephone) > 0)
                                    {
                                        continue;
                                    }

                                    if (theList.Count(x => x.Email == data.Email) > 0)
                                    {
                                        continue;
                                    }

                                    theList.Add(data);
                                }

                                theList = (List<ParserCompany>)theList.OrderBy(x => x.Telephone);

                                for (int i = 1; i <= theList.Count; i++)
                                {
                                    var data = theList[i - 1];
                                    worksheet1.Cells[i, 1].Value = data.Telephone;
                                    worksheet1.Cells[i, 2].Value = data.Email;
                                    worksheet1.Cells[i, 3].Value = data.Saite;
                                    worksheet1.Cells[i, 4].Value = data.Name;
                                    worksheet1.Cells[i, 5].Value = data.Operator;
                                    worksheet1.Cells[i, 6].Value = data.Region;
                                    worksheet1.Cells[i, 7].Value = data.Rubrika;
                                }
                                package.Save();
                                Log( "Сохранено: " + FileName);
                            }

                            break;
                        }

                    }
                    catch (Exception ex)
                    {
                        Log( "Ошибка при обработке файла: " + file + " " + ex.Message);                       
                    }

                }


                this.labelProcent.Text = "100%";

                Log( "Завершено!");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                err += ex.StackTrace;
                Log( err);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private string GetValueFromCell(ExcelRange Cell)
        {
            if (Cell == null)
            {                
                return "";
            }

            if (Cell.Value == null)
            {
                return "";
            }

            return Cell.Value.ToString();
        }

        private void buttonParserPerson_Click(object sender, EventArgs e)
        {

            if (DateTime.Now > new DateTime(2017, 06, 01))
            {
                return;
            }

            try
            {
                if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string[] files = Directory.GetFiles(this.folderBrowserDialog1.SelectedPath);
                                      
                Log( "Начало обработки");
                this.UseWaitCursor = true;

                foreach (var file in files)
                {
                    try
                    {
                        Log( "Выбран файл: " + Path.GetFileName(file));

                        if (Path.GetExtension(file) != ".xlsx")
                        {
                            Log("Формат файла не поддерживается: " + Path.GetExtension(file));
                            continue;
                        }


                        Log( "Начало обработки");
                        this.UseWaitCursor = true;

                        Log( "Выбран файл: " + Path.GetFileName(file));

                        FileInfo newFile = new FileInfo(file);

                        ExcelPackage _pck = new ExcelPackage(newFile);
                        #region foreach
                        foreach (var worksheet in _pck.Workbook.Worksheets)
                        {
                            int ColumnName = -1;
                            int ColumnSex = -1;
                            int ColumnEmail = -1;
                            int ColumnTelephone = -1;
                            int ColumnBrithday = -1;

                            Log( "Обрабатываем страницу: " + worksheet.Name);
                            if (worksheet.Dimension == null)
                            {
                                Log( "Страница пуста - пропускаем");
                                continue;
                            }
                            #region for_rowCnt
                            var rowCnt = worksheet.Dimension.End.Row;
                            var colCnt = worksheet.Dimension.End.Column;
                            for (int i = 1; i <= colCnt; i++)
                            {
                                if (worksheet.Cells[1, i] == null)
                                {
                                    continue;
                                }
                                if (worksheet.Cells[1, i].Value == null)
                                {
                                    continue;
                                }
                                switch (worksheet.Cells[1, i].Value.ToString().Trim())
                                {
                                    case "Имя":
                                        ColumnName = i;
                                        break;
                                    case "Пол":
                                        ColumnSex = i;
                                        break;
                                    case "Email":
                                        ColumnEmail = i;
                                        break;
                                    case "Телефон":
                                        ColumnTelephone = i;
                                        break;
                                    case "Дата рождения":
                                        ColumnBrithday = i;
                                        break;
                                }
                            }
                            #endregion
                            string Notify = "";
                            if (ColumnName < 0)
                            {
                                Notify += "\nИмя";
                            }
                            if (ColumnSex < 0)
                            {
                                Notify += "\nПол";
                            }
                            if (ColumnEmail < 0)
                            {
                                Notify += "\nEmail";
                            }
                            if (ColumnTelephone < 0)
                            {
                                Notify += "\nТелефон";
                            }
                            if (ColumnBrithday < 0)
                            {
                                Notify += "\nДата рождения";
                            }
                            
                            if (Notify.Length > 0)
                            {
                                Notify = "Отсутствуют поля: " + Notify;
                                Log( Notify);
                                break;
                            }

                            string DirName = "ParserPerson";
                            if (!Directory.Exists(DirName))
                            {
                                Directory.CreateDirectory(DirName);
                            }
                                                        
                            string FileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
                            FileName = Directory.GetCurrentDirectory() + @"\" + DirName + @"\" + FileName + ".xlsx";
                            var existingFile = new FileInfo(FileName);
                            #region using
                            using (var package = new ExcelPackage(existingFile))
                            {
                                var workbook = package.Workbook;

                                var worksheet1 = workbook.Worksheets.Add(worksheet.Name);

                                List<ParserPerson> theList = new List<ParserPerson>();
                                #region for
                                for (int i = 1; i <= rowCnt; i++)
                                {
                                    ParserPerson data = new ParserPerson();
                                    data.Telephone = GetValueFromCell(worksheet.Cells[i, ColumnTelephone]);
                                    data.Name = GetValueFromCell(worksheet.Cells[i, ColumnName]);
                                    data.Email = GetValueFromCell(worksheet.Cells[i, ColumnEmail]);
                                    data.Sex = GetValueFromCell(worksheet.Cells[i, ColumnSex]);
                                    data.Brithday = GetValueFromCell(worksheet.Cells[i, ColumnBrithday]);

                                    data.Telephone = IndexMobileCore.Helper.Telephone.Normalize(data.Telephone);

                                    if (data.Telephone.Length < 10)
                                    {
                                        continue;
                                    }


                                    string _Code = data.Telephone.Substring(0, 3);
                                    string _Number = data.Telephone.Substring(3, 7);
                                    Log( "_Code - " + _Code);
                                    Log( "_Number - " + _Number);

                                    int Code = 0; 
                                    int Number = 0;

                                    try
                                    {
                                        Code = Convert.ToInt32(_Code);
                                        Number = Convert.ToInt32(_Number);
                                    }
                                    catch
                                    {
                                        Log( "Ошибка при определении Code и Number");
                                        continue;
                                    }
                                    Log( "Вызываем: IndexMobileCore.Helper.Telephone.Operator(" + Code.ToString() + ", " + Number.ToString() + ")");

                                    var theDEF = DEF.GetOperator(Code, Number);
                                    if (theDEF != null)
                                    {
                                        Log( "Получено значение: tel_operator =  " + theDEF.Operator + " - " + theDEF.Region);
                                        data.Operator = theDEF.Operator;
                                        data.Region = theDEF.Region;
                                    }
                                    else
                                    {
                                        Log( "Значение отсутствует");
                                    }


                                    if (theList.Count(x => x.Email == data.Email) > 0)
                                    {
                                        continue;
                                    }

                                    theList.Add(data);
                                }
                                #endregion
                                for (int i = 1; i <= theList.Count; i++)
                                {
                                    var data = theList[i - 1];
                                    worksheet1.Cells[i, 1].Value = data.Telephone;
                                    worksheet1.Cells[i, 2].Value = data.Operator;
                                    worksheet1.Cells[i, 3].Value = data.Region;
                                    worksheet1.Cells[i, 4].Value = data.Name;
                                    worksheet1.Cells[i, 5].Value = data.Email;
                                    worksheet1.Cells[i, 6].Value = data.Sex;
                                    worksheet1.Cells[i, 7].Value = data.Brithday;
                                }
                                package.Save();
                                Log( "Сохранено: " + FileName);
                            }
                            #endregion
                            break;
                        }
                        #endregion

                    }
                    catch (Exception ex)
                    {
                        Log( "Ошибка при обработке файла: " + file + " " + ex.Message);                       
                    }
                }
                Log( "Завершено!");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                err += ex.StackTrace;
                Log( err);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private void buttonHelpCompany_Click(object sender, EventArgs e)
        {
            FormHelpCompany theHelp = new FormHelpCompany();
            theHelp.ShowDialog();
        }

        private void buttonHelpPerson_Click(object sender, EventArgs e)
        {
            FormHelpPerson theHelp = new FormHelpPerson();
            theHelp.ShowDialog();
        }

        private void buttonHelpEmail_Click(object sender, EventArgs e)
        {
            FormHelpEmail theHelp = new FormHelpEmail();
            theHelp.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void buttonDiaposonGenerate_Click(object sender, EventArgs e)
        {
            IndexMobileGenerate.FormAccess theForm = new IndexMobileGenerate.FormAccess();
            theForm.ShowDialog();
        }
    }
}
