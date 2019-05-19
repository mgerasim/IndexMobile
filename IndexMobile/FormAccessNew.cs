using IndexMobile;
using IndexMobileEntity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
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
                    if (item.Name.Length == 0)
                    {
                        this.listBoxDiapason.Items.Add(item.DisplayName);
                    }
                    else
                    {
                        this.listBoxDiapason.Items.Add(item.Name);
                    }
                    
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
					var diapason = new Diapason
					{
						Access = this.theAccess,
						ValueMin = Convert.ToInt64(theFormDiapasonNew.textBoxValueMin.Text),
						ValueMax = Convert.ToInt64(theFormDiapasonNew.textBoxValueMax.Text)
					};
					diapason.Name = diapason.ValueMin.ToString("0000000000") + " ... " + diapason.ValueMax.ToString("0000000000");
                    diapason.Save();

                    int Total = 0;

                    var results = new List<int>();
                    string sqlInsertUsers = @"INSERT INTO [Telephone] ([Number], [NumberOrder], [Diapason_ID], [Access_ID]) VALUES (@Number, @NumberOrder, @Diapason_ID, @Access_ID);";
                    
                    string _connectionString = "Data Source=DEF.db";
                                       

                    using (var cn = new SQLiteConnection(_connectionString))
                    {
                        cn.Open();

                        using (var transaction = cn.BeginTransaction())
                        {
                            using (var cmd = cn.CreateCommand())
                            {
                                cmd.CommandText = sqlInsertUsers;
                                cmd.Parameters.AddWithValue("@Number", "");
                                cmd.Parameters.AddWithValue("@NumberOrder", "");
                                cmd.Parameters.AddWithValue("@Diapason_ID", "");
                                cmd.Parameters.AddWithValue("@Access_ID", "");

                                for (long i = diapason.ValueMin; i <= diapason.ValueMax; i++)
                                {   
                                        var rnd = new Random();
                                        cmd.Parameters["@Number"].Value = i.ToString();
                                        cmd.Parameters["@NumberOrder"].Value = rnd.Next(0, Int32.MaxValue);
                                        cmd.Parameters["@Diapason_ID"].Value = diapason.ID;
                                        cmd.Parameters["@Access_ID"].Value = theAccess.ID;
                                        try
                                        {
                                            results.Add(cmd.ExecuteNonQuery());
                                            Total++;                                    
                                        }
                                        catch(Exception exc)
                                        {

                                        }
                                        
                                }                                
                            }
                            transaction.Commit();
                        }
                    }
                    int Sum = results.Sum();

                    diapason.Name += " = " + Total.ToString();
                    diapason.Update();

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

        private void FormAccessNew_Load(object sender, EventArgs e)
        {

        }
        void LoadListOfString(CheckedListBox theCheckedListBox, ref List<string> theList)
        {
            if (theCheckedListBox.CheckedItems.Count == 0)
            {
                foreach(var item in theCheckedListBox.Items) 
                {
                    theList.Add(item.ToString());
                }
            }
            else 
            {
                foreach(var item in theCheckedListBox.CheckedItems) 
                {
                    theList.Add(item.ToString());
                }
            }
        }
        private void buttonAccessNewCodeRegionOperator_Click(object sender, EventArgs e)
        {
            FromDiapasonNewCodeRegionOperator theForm = new FromDiapasonNewCodeRegionOperator();
            try {
                var result = theForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.listBoxDiapason.Items.Clear();
                    this.listBoxDiapason.Items.Add("Обновление ...");
                    this.listBoxDiapason.Refresh();
                    Diapason theDiapason = new Diapason();
                    theDiapason.Access = this.theAccess;
                    theDiapason.ValueMin = 0;
                    theDiapason.ValueMax = 0;
                    theDiapason.Name = theForm.textBoxCode.Text + " " + theForm.textBoxRegion.Text + " " + theForm.textBoxOperator.Text;
                    theDiapason.Save();
                    
                    List<string > selectedCode = new List<string>();
                    List<string > selectedRegion = new List<string>();
                    List<string > selectedOperator = new List<string>();

                    LoadListOfString(theForm.checkedListBoxCode, ref selectedCode);
                    LoadListOfString(theForm.checkedListBoxRegion, ref selectedRegion);
                    LoadListOfString(theForm.checkedListBoxOperator, ref selectedOperator);

                    int Total = 0;
        
                    var DEFs = DEF.GetAll().Where(x=>
                            selectedCode.Contains(x.NumberDEF.ToString()) &&
                            selectedRegion.Contains(x.Region) &&
                            selectedOperator.Contains(x.Operator));
                    
                    var results = new List<int>();
                    string sqlInsertUsers = @"INSERT INTO [Telephone] ([Number], [NumberOrder], [Diapason_ID], [Access_ID]) VALUES (@Number, @NumberOrder, @Diapason_ID, @Access_ID);";
                    string _connectionString = "Data Source=DEF.db";
                    using (var cn = new SQLiteConnection(_connectionString))
                    {
                        cn.Open();
                        using (var transaction = cn.BeginTransaction())
                        {
                            using (var cmd = cn.CreateCommand())
                            {
                                cmd.CommandText = sqlInsertUsers;
                                cmd.Parameters.AddWithValue("@Number", "");
                                cmd.Parameters.AddWithValue("@NumberOrder", "");
                                cmd.Parameters.AddWithValue("@Diapason_ID", "");
                                cmd.Parameters.AddWithValue("@Access_ID", "");
                                                                
                                foreach (var item in DEFs)
                                {
                                    for(long i = item.NumberBgn; i<=item.NumberEnd; i++)
                                    {
                                        Random rnd = new Random();
                                        cmd.Parameters["@Number"].Value = ((item.NumberDEF * 10000000) + i).ToString();
                                        cmd.Parameters["@NumberOrder"].Value = rnd.Next(0, Int32.MaxValue);
                                        cmd.Parameters["@Diapason_ID"].Value = theDiapason.ID;
                                        cmd.Parameters["@Access_ID"].Value = theAccess.ID;
                                        try
                                        {
                                            results.Add(cmd.ExecuteNonQuery());
                                            Total++;
                                        }
                                        catch { }
                                    }
                                }
                                
                            }
                            transaction.Commit();
                        }
                    }
                    int Sum = results.Sum();

                    theDiapason.Name += " = " + Total;
                    theDiapason.Update();

                    this.LoadDiapason();
                    Application.UseWaitCursor = false;
                }

            }
            catch (Exception ex)
            {
                this.listBoxDiapason.Items.Add(ex.Message);
            }
        }

        private void listBoxDiapason_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxSelectedName.Text = this.listBoxDiapason.SelectedItem.ToString();
        }
    }
}
