using IndexMobileEntity.Models;
using System;
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
                listBoxAccess.DisplayMember = "DisplayName";
                listBoxAccess.ValueMember = "DisplayName";
                listBoxAccess.DataSource = Access.GetAll().OrderByDescending(x => x.ID).ToList();
                //foreach (var item in Access.GetAll().OrderByDescending(x=>x.ID))
                //{
                //    listBoxAccess.Items.Add(item.Name);
                //}
            }
            catch (Exception ex)
            {
                listBoxAccess.DataSource = null;
                listBoxAccess.Items.Add(ex.Message);
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
                this.LoadAccess();

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

            if (accessNewForm.ShowDialog() == DialogResult.OK)
			{
				this.LoadAccess();
			}


        }

        private void buttonSelection_Click(object sender, EventArgs e)
        {
			if (!(listBoxAccess.SelectedItem is Access access))
			{
				return;
			}

			var selectionForm = new FormSelection(access);

            selectionForm.ShowDialog();

            //this.LoadAccess();
        }

        private void FormAccess_Load(object sender, EventArgs e)
        {

        }
    }
}
