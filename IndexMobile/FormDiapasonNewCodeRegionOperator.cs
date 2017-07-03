using IndexMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexMobile
{
    public partial class FromDiapasonNewCodeRegionOperator : Form
    {
        public FromDiapasonNewCodeRegionOperator()
        {
            InitializeComponent();
        }

        void LoadCheckListBox(CheckedListBox theCheckedListBox, List<string> theList)
        {
            foreach (var item in theList)
            {
                theCheckedListBox.Items.Add(item);
            }
        }
        private void AccessNewCodeRegionOperator_Load(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            LoadCheckListBox(this.checkedListBoxCode, DEF.GetAll().OrderBy(x=>x.NumberDEF).Select(x => x.NumberDEF.ToString()).Distinct().ToList());
            LoadCheckListBox(this.checkedListBoxRegion, DEF.GetAll().OrderBy(x => x.Region).Select(x => x.Region.ToString()).Distinct().ToList());
            LoadCheckListBox(this.checkedListBoxOperator, DEF.GetAll().OrderBy(x => x.Operator).Select(x => x.Operator.ToString()).Distinct().ToList());
            Application.UseWaitCursor = false;
        }

        void LoadTextEdit(CheckedListBox theCheckedListbox, TextBox theTextBox)
        {
            string ss = "";
            foreach (var item in theCheckedListbox.CheckedItems)
            {
                ss += item.ToString();
                ss += ", ";
            }
            theTextBox.Text = ss;
        }

        private void checkedListBoxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTextEdit(this.checkedListBoxCode, this.textBoxCode);
        }

        private void checkedListBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTextEdit(this.checkedListBoxRegion, this.textBoxRegion);
        }

        private void checkedListBoxOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTextEdit(this.checkedListBoxOperator, this.textBoxOperator);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
    }
}
