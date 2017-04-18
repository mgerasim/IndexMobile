using IndexMobileEntity.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexMobileGenerate
{
    public partial class FormSelection : Form
    {
        Access theAccess;
        public FormSelection(Access theAccess)
        {
            InitializeComponent();
            this.theAccess = theAccess;
            LoadSelection();
        }

        private void LoadSelection()
        {
            //this.listBoxSelection.Items.Clear();
            //try
            //{
            //    foreach (var item in theAccess.Selections)
            //    {
            //        this.listBoxSelection.Items.Add(item.DisplayName);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    this.listBoxSelection.Items.Add(ex.Message);
            //}
            listBoxSelection.DisplayMember = "DisplayName";
            listBoxSelection.ValueMember = "DisplayName";
            listBoxSelection.DataSource = theAccess.Selections.OrderByDescending(x => x.ID).ToList();
        }

        private void buttonSelectionNew_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int Count = Convert.ToInt32(this.textBoxCount.Text);
                Selection theSelection = new Selection();
                theSelection.Count = Count;
                theSelection.Access = theAccess;
                theSelection.Save();
                int i = 0;
                var Telephones = theAccess.TelephonesBySelectionIsNull;
                Telephones.Shuffle();


                string sqlInsertUsers = @"UPDATE [Telephone] SET [Selection_ID] = @Selection_ID WHERE [ID] = @ID";
                string _connectionString = "Data Source=IndexMobile.db";
                using (var cn = new SQLiteConnection(_connectionString))
                {
                    cn.Open();
                    using (var transaction = cn.BeginTransaction())
                    {
                        using (var cmd = cn.CreateCommand())
                        {
                            cmd.CommandText = sqlInsertUsers;
                            cmd.Parameters.AddWithValue("@ID", "");
                            cmd.Parameters.AddWithValue("@Selection_ID", "");

                            foreach (var item in Telephones.OrderBy(a => Guid.NewGuid()).ToList())
                            {
                                i++;
                                if (i > Count)
                                {
                                    break;
                                }
                                 cmd.Parameters["@ID"].Value = item.ID;
                                cmd.Parameters["@Selection_ID"].Value = theSelection.ID;
                                cmd.ExecuteNonQuery();
                            }
                                //cmd.Parameters["@Number"].Value = i.ToString();
                                //cmd.Parameters["@Diapason_ID"].Value = theDiapason.ID;
                                //cmd.Parameters["@Access_ID"].Value = theAccess.ID;
                                //results.Add(cmd.ExecuteNonQuery());

                            //}

                        }
                        transaction.Commit();
                    }
                }

                //foreach (var item in Telephones.OrderBy(a => Guid.NewGuid()).ToList())
                //{
                //    i++;
                //    if (i > Count)
                //    {
                //        break;
                //    }
                //    item.Selection = theSelection;
                //    item.Update();
                //}
                LoadSelection();
                Application.UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                this.listBoxSelection.DataSource = null;
                this.listBoxSelection.Items.Add(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void buttonShow_Click(object sender, EventArgs e)
        {
            try
            {
                Selection theSelection = listBoxSelection.SelectedItem as Selection;
                if (theSelection == null)
                {
                    return;
                }
                string path = theSelection.ID.ToString("000000") + "-" + Guid.NewGuid() + ".xlsx";
                
                FileInfo newFile = new FileInfo(path);
                using (ExcelPackage pck = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Telephone");
                    int i = 0;
                    var Telephones = theSelection.Telephones;
                    Telephones.Shuffle();
                    foreach (var item in Telephones.OrderBy(a => Guid.NewGuid()).ToList())
                    {
                        i++;
                        ws.Cells[i, 1].Value = item.Number.ToString("0000000000");
                    }
                    pck.Save();
                    System.Diagnostics.Process.Start(path);
                }

            }
            catch (Exception ex)
            {
                listBoxSelection.DataSource = null;
                listBoxSelection.Items.Add(ex.Message);
            }
            
        }
    }
}
