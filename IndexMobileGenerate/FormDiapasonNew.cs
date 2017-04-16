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
    public partial class FormDiapasonNew : Form
    {
        Access theAccess;
        public FormDiapasonNew(Access theAccess)
        {
            InitializeComponent();
            this.theAccess = theAccess;
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
