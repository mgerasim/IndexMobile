using Entity.Common;
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
	public partial class FormAccessNew : System.Windows.Forms.Form
    {
        Access _access;
        public FormAccessNew(Access theAccess)
        {
            InitializeComponent();
            this._access = theAccess;
            this.textBoxAccessName.Text = theAccess.Name;
            this.LoadDiapason();
        }

        private void LoadDiapason()
        {
            this.listBoxDiapason.Items.Clear();
            try
            {
                foreach (var item in _access.Diapasons)
                {
					var itemValue = item.Name.Length == 0 ? item.DisplayName : item.Name;

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
                FormDiapasonNew theFormDiapasonNew = new FormDiapasonNew(this._access);
                var result = theFormDiapasonNew.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.listBoxDiapason.Items.Clear();
                    this.listBoxDiapason.Items.Add("Обновление ...");
                    this.listBoxDiapason.Refresh();
					var diapason = new Diapason
					{
						Access = this._access,
						ValueMin = Convert.ToInt64(theFormDiapasonNew.textBoxValueMin.Text),
						ValueMax = Convert.ToInt64(theFormDiapasonNew.textBoxValueMax.Text)
					};
					diapason.Name = diapason.ValueMin.ToString("0000000000") + " ... " + diapason.ValueMax.ToString("0000000000");
                    diapason.Save();

                    int Total = 0;

                    var results = new List<int>();
                    string sqlInsertUsers = @"INSERT INTO [Telephone] ([Number], [NumberOrder], [Diapason_ID], [Access_ID]) VALUES (@Number, @NumberOrder, @Diapason_ID, @Access_ID);";

					string _connectionString = NHibernateHelper.ConnectionString;
					
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
                                        cmd.Parameters["@Access_ID"].Value = _access.ID;
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
            _access.Name = this.textBoxAccessName.Text;
            try
            {
                _access.Update();
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
            var formDiapasonNewCodeRegionOperator = new FromDiapasonNewCodeRegionOperator();

            try {
                var result = formDiapasonNewCodeRegionOperator.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.listBoxDiapason.Items.Clear();
                    this.listBoxDiapason.Items.Add("Обновление ...");
                    this.listBoxDiapason.Refresh();
					var diapason = new Diapason
					{
						Access = _access,
						ValueMin = 0,
						ValueMax = 0,
						Name = formDiapasonNewCodeRegionOperator.textBoxCode.Text + " " + formDiapasonNewCodeRegionOperator.textBoxRegion.Text + " " + formDiapasonNewCodeRegionOperator.textBoxOperator.Text
					};
					diapason.Save();
					
					var capacities = Capacity.GetAllByOperatorsListAndRegionListAndCodeList(
						formDiapasonNewCodeRegionOperator.OperatorCheckedList,
						formDiapasonNewCodeRegionOperator.RegionCheckedList,
						formDiapasonNewCodeRegionOperator.CodeCheckedList);
					
                    int Total = 0;
                    
                    var results = new List<int>();
                    string sqlInsertUsers = @"INSERT INTO [Telephone] ([Number], [NumberOrder], [Diapason_ID], [Access_ID]) VALUES (@Number, @NumberOrder, @Diapason_ID, @Access_ID);";
                    string _connectionString = NHibernateHelper.ConnectionString;

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
                                                                
                                foreach (var item in capacities)
                                {
                                    for(long i = item.MinValue; i<=item.MaxValue; i++)
                                    {
                                        Random rnd = new Random();
										var code = formDiapasonNewCodeRegionOperator.CodeCheckedList.Where(x => x.ID == item.Code.ID).FirstOrDefault() ;

                                        cmd.Parameters["@Number"].Value = ((Convert.ToInt64(code.Title) * 10000000) + i).ToString();
                                        cmd.Parameters["@NumberOrder"].Value = rnd.Next(0, Int32.MaxValue);
                                        cmd.Parameters["@Diapason_ID"].Value = diapason.ID;
                                        cmd.Parameters["@Access_ID"].Value = _access.ID;
                                        try
                                        {
                                            results.Add(cmd.ExecuteNonQuery());
                                            Total++;
                                        }
                                        catch (Exception exc)
										{ }
                                    }
                                }
                                
                            }
                            transaction.Commit();
                        }
                    }
                    int Sum = results.Sum();

                    diapason.Name += " = " + Total;
                    diapason.Update();

					_access.CapacityTotal += Total;
					_access.CapacityFree += Total;
					_access.Update();

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
