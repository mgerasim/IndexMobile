using IndexMobileEntity.Helper;
using IndexMobileEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexMobileGenerate
{
    public partial class FormAccessNew : Form
    {
        Access theAccess;
        public FormAccessNew(Access theAccess)
        {
            InitializeComponent();
            this.theAccess = theAccess;
            this.textBoxAccessName.Text = theAccess.Name;
            this.LoadDiapason();
        }

        private void LoadDiapason()
        {
            this.listBoxDiapason.Items.Clear();
            try
            {
                foreach (var item in theAccess.Diapasons)
                {
                    this.listBoxDiapason.Items.Add(item.DisplayName);
                }

            }
            catch (Exception ex)
            {
                this.listBoxDiapason.Items.Add(ex.Message);
            }
        }

        private void buttonDiapasonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FormDiapasonNew theFormDiapasonNew = new FormDiapasonNew(this.theAccess);
                var result = theFormDiapasonNew.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.listBoxDiapason.Items.Clear();
                    this.listBoxDiapason.Items.Add("Обновление ...");
                    this.listBoxDiapason.Refresh();
                    Diapason theDiapason = new Diapason();
                    theDiapason.Access = this.theAccess;
                    theDiapason.ValueMin = Convert.ToInt64(theFormDiapasonNew.textBoxValueMin.Text);
                    theDiapason.ValueMax = Convert.ToInt64(theFormDiapasonNew.textBoxValueMax.Text);
                    theDiapason.Save();

                    var results = new List<int>();
                    string sqlInsertUsers = @"INSERT INTO [Telephone] ([Number], [Diapason_ID], [Access_ID]) VALUES (@Number, @Diapason_ID, @Access_ID);";
                    string _connectionString = "Data Source=IndexMobile.db";
                    using (var cn = new SQLiteConnection(_connectionString))
                    {
                        cn.Open();
                        using (var transaction = cn.BeginTransaction())
                        {
                            using (var cmd = cn.CreateCommand())
                            {
                                cmd.CommandText = sqlInsertUsers;
                                cmd.Parameters.AddWithValue("@Number", "");
                                cmd.Parameters.AddWithValue("@Diapason_ID", "");
                                cmd.Parameters.AddWithValue("@Access_ID", "");

                                for (long i = theDiapason.ValueMin; i <= theDiapason.ValueMax; i++)
                                {
                                    cmd.Parameters["@Number"].Value = i.ToString();
                                    cmd.Parameters["@Diapason_ID"].Value = theDiapason.ID;
                                    cmd.Parameters["@Access_ID"].Value = theAccess.ID;
                                    results.Add(cmd.ExecuteNonQuery());

                                }
                                
                            }
                            transaction.Commit();
                        }
                    }
                    int Sum = results.Sum();

                    //string sqlQuery = "";
                    //for (long i = theDiapason.ValueMin; i <= theDiapason.ValueMax; i++)
                    //{
                    //    if (Telephone.CheckInAccess(i, theDiapason.Access))
                    //    {
                    //        continue;
                    //    }
                    //    sqlQuery += "INSERT INTO TELEPHONE(NUMBER, DIAPASON_ID, ACCESS_ID) VALUES(" + i.ToString() + ", " + theDiapason.ID + ", " + theAccess.ID + "); \n\r";

                    //    //Telephone theTelephone = new Telephone();
                    //    //theTelephone.Diapason = theDiapason;
                    //    //theTelephone.Access = theDiapason.Access;
                    //    //theTelephone.Number = i;
                    //    //theTelephone.Save();
                    //}
                    //DataClass theDataClass = new DataClass();
                    //theDataClass.selectQuery(sqlQuery);
                    this.LoadDiapason();
                    Application.UseWaitCursor = false;
                }

            }
            catch (Exception ex)
            {
                this.listBoxDiapason.Items.Add(ex.Message);
            }
        }

        private void buttonAccessOk_Click(object sender, EventArgs e)
        {
            theAccess.Name = this.textBoxAccessName.Text;
            try
            {
                theAccess.Update();
            }
            catch (Exception ex)
            {
                this.listBoxDiapason.DataSource = null;
                this.listBoxDiapason.Items.Add(ex.Message);
            }
            this.Close();
        }
    }
}
