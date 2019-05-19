using IndexMobileEntity.Models;
using System;
using System.Windows.Forms;

namespace IndexMobileGenerate
{
	public partial class FormDiapasonNew : Form
    {
        private Access _access;

        public FormDiapasonNew(Access access)
        {
            InitializeComponent();

            this._access = access ?? throw new ArgumentNullException(nameof(access));
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
