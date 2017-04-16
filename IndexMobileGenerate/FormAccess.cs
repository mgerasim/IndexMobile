using IndexMobileEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexMobileGenerate
{
    public partial class FormAccess : Form
    {
        public FormAccess()
        {
            InitializeComponent();
            if (File.Exists("IndexMobile.db"))
            {
                Entity.Common.NHibernateHelper.UpdateSchema();
            }
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
            if (DateTime.Now > new DateTime(2017, 05, 01))
            {
                return;
            }
            try
            {
                Access theAccess = new Access();
                theAccess.Save();
                theAccess.Name = "Выборка № " + theAccess.ID.ToString("000000");
                theAccess.Update();
                FormAccessNew theFormAccessNew = new FormAccessNew(theAccess);
                theFormAccessNew.ShowDialog();
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
            Access theAccess = listBoxAccess.SelectedItem as Access;
            if (theAccess == null)
            {
                return;
            }
            FormAccessNew theFormAccessNew = new FormAccessNew(theAccess);
            theFormAccessNew.ShowDialog();
            this.LoadAccess();
        }

        private void buttonSelection_Click(object sender, EventArgs e)
        {
            Access theAccess = listBoxAccess.SelectedItem as Access;
            if (theAccess == null)
            {
                return;
            }
            FormSelection theFormSelection = new FormSelection(theAccess);
            theFormSelection.ShowDialog();
            this.LoadAccess();
        }
    }
}
