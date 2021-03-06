﻿using IndexMobileEntity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IndexMobileGenerate
{
	public partial class FormAccess : Form
    {
		/// <summary>
		/// Конструктор
		/// </summary>
        public FormAccess()
        {
            InitializeComponent();
            
            Entity.Common.NHibernateHelper.UpdateSchema();
            LoadAccess();
        }

        private void LoadAccess()
        {
            try
            {
				UseWaitCursor = true;

				Cursor.Current = Cursors.WaitCursor;

				listBoxAccess.DisplayMember = "DisplayName";
                listBoxAccess.ValueMember = "DisplayName";
                listBoxAccess.DataSource = Access.GetAll().OrderByDescending(x => x.ID).ToList();
            }
            catch (Exception ex)
            {
                listBoxAccess.DataSource = null;
                listBoxAccess.Items.Add(ex.Message);
            }
			finally
			{
				UseWaitCursor = false;
			}
        }

        private void buttonAccessAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var access = new Access();
                access.Save();
                access.Name = "Выборка № " + access.ID.ToString("000000");
                access.Update();

                var accessNewForm = new FormAccessNew(access);
                accessNewForm.ShowDialog();
                LoadAccess();

            }
            catch (Exception ex)
            {
                listBoxAccess.DataSource = null;
                listBoxAccess.Items.Add(ex.Message);
            }
        }

        private void buttonAccessShow_Click(object sender, EventArgs e)
        {
			if (!(listBoxAccess.SelectedItem is Access access))
			{
				return;
			}

			var accessNewForm = new FormAccessNew(access);

			accessNewForm.ShowDialog();

			LoadAccess();
		}

        private void buttonSelection_Click(object sender, EventArgs e)
        {
			if (!(listBoxAccess.SelectedItem is Access access))
			{
				return;
			}

			var selectionForm = new FormSelection(access);

            selectionForm.ShowDialog();

            LoadAccess();
        }

        private void FormAccess_Load(object sender, EventArgs e)
        {
			
		}

		/// <summary>
		/// Удаление отбора
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonDelete_Click(object sender, EventArgs e)
		{
			try
			{
				UseWaitCursor = true;

				Cursor.Current = Cursors.WaitCursor;

				if (!(listBoxAccess.SelectedItem is Access access))
				{
					return;
				}

				foreach (var diapason in access.Diapasons)
				{
					diapason.DeleteTelephones();

					diapason.Delete();
				}

				foreach (var selection in access.Selections)
				{
					selection.Delete();
				}

				access.Delete();

				LoadAccess();
			}
			catch (Exception exc)
			{
				listBoxAccess.DataSource = null;

				listBoxAccess.Items.Add(exc.Message);
			}
			finally
			{
				UseWaitCursor = false;
			}
		}
	}
}
