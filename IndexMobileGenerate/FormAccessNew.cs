using IndexMobileEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                    for (long i = theDiapason.ValueMin; i <= theDiapason.ValueMax; i++)
                    {
                        if (Telephone.CheckInAccess(i, theDiapason.Access))
                        {
                            continue;
                        }
                        Telephone theTelephone = new Telephone();
                        theTelephone.Diapason = theDiapason;
                        theTelephone.Access = theDiapason.Access;
                        theTelephone.Number = i;
                        theTelephone.Save();
                    }
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
            this.Close();
        }
    }
}
