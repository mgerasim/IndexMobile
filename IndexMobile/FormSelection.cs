﻿using Entity.Common;
using IndexMobile;
using IndexMobileEntity.Models;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IndexMobileGenerate
{
	public partial class FormSelection : System.Windows.Forms.Form
    {
        private Access _access;

        public FormSelection(Access access)
        {
            InitializeComponent();
            this._access = access;
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
            listBoxSelection.DataSource = _access.Selections.OrderByDescending(x => x.ID).ToList();
        }

        private void buttonSelectionNew_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int telephoneSelectionCount = Convert.ToInt32(this.textBoxCount.Text);

				if (telephoneSelectionCount > _access.TelephonesBySelectionIsNullCount)
				{
					telephoneSelectionCount = (int)_access.TelephonesBySelectionIsNullCount;
				}

				var selection = new Selection
				{
					Count = telephoneSelectionCount,
					Access = _access
				};
				selection.Save();

				int Count = Convert.ToInt32(this.textBoxCount.Text);

				/*
				int indexCount = 0;
				while(indexCount < telephoneSelectionCount)
				{
					foreach(var diaposon in _access.Diapasons)
					{
						if (Telephone.GetCountFreeByDiapason(diaposon) == 0)
						{
							continue;
						}

						var telephones = Telephone.GetFreeByDiapason(diaposon);

						telephones.Shuffle();

						string sqlInsertUsers = @"UPDATE [Telephone] SET [Selection_ID] = @Selection_ID WHERE [ID] = @ID";

						string _connectionString = NHibernateHelper.ConnectionString;

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

									var telephoneShuffle = telephones.FirstOrDefault();

									if (telephoneShuffle is null)
									{
										continue;
									}

									cmd.Parameters["@ID"].Value = telephoneShuffle.ID;
									cmd.Parameters["@Selection_ID"].Value = selection.ID;
									cmd.ExecuteNonQuery();

									indexCount++;
								}
								transaction.Commit();
							}
						}
					}
				}
				*/

				int i = 0;

                var Telephones = _access.TelephonesBySelectionIsNull;

                Telephones.Shuffle();

                string sqlInsertUsers = @"UPDATE [Telephone] SET [Selection_ID] = @Selection_ID WHERE [ID] = @ID";

                string _connectionString = NHibernateHelper.ConnectionString;

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
									i--;
                                    break;
                                }
                                 cmd.Parameters["@ID"].Value = item.ID;
                                cmd.Parameters["@Selection_ID"].Value = selection.ID;
                                cmd.ExecuteNonQuery();
                            }

                        }
                        transaction.Commit();
                    }
                }

				_access.CapacityFree -= i;
				_access.Update();

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
                var selection = listBoxSelection.SelectedItem as Selection;

                if (selection == null)
                {
                    return;
                }
                string path = selection.ID.ToString("000000") + "-" + Guid.NewGuid() + ".xlsx";
                
                FileInfo newFile = new FileInfo(path);
                using (ExcelPackage pck = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Telephone");
                    int i = 0;
                    var Telephones = selection.Telephones;
                    Telephones.Shuffle();
                    foreach (var item in Telephones.OrderBy(a => Guid.NewGuid()).ToList())
                    {
                        i++;
                        ws.Cells[i, 1].Value = "8" + item.Number.ToString("0000000000");
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

        private void FormSelection_Load(object sender, EventArgs e)
        {

        }
    }
}
