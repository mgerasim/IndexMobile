using IndexMobileEntity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IndexMobile
{
	public partial class FromDiapasonNewCodeRegionOperator : Form
    {
        bool isNotUpdateCodeAll = false;
        bool isNotUpdateRegionAll = false;
        bool isNotUpdateOperatorAll = false;
        public FromDiapasonNewCodeRegionOperator()
        {
            InitializeComponent();
        }

        void LoadCheckListBox(CheckedListBox theCheckedListBox, List<string> theList)
        {
            theCheckedListBox.Items.Clear();

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
            if (this.isNotUpdateCodeAll)
            {
                return;
            }
            
            LoadTextEdit(this.checkedListBoxCode, this.textBoxCode);            
            
        }

        private void checkedListBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isNotUpdateRegionAll)
            {
                return;
            }
            LoadTextEdit(this.checkedListBoxRegion, this.textBoxRegion);
        }

        private void checkedListBoxOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isNotUpdateOperatorAll)
            {
                return;
            }

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

        private void checkedListBoxCode_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (this.isNotUpdateCodeAll)
            {
                return;
            }

            if (this.checkedListBoxCode.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
            {
                LoadCheckListBox(this.checkedListBoxRegion, DEF.GetAll().OrderBy(x => x.Region).Select(x => x.Region.ToString()).Distinct().ToList());
            }
            else
            {
                List<string> checkedItems = new List<string>();
                foreach (var item in this.checkedListBoxCode.CheckedItems)
                    checkedItems.Add(item.ToString());

                if (e.NewValue == CheckState.Checked)
                    checkedItems.Add(this.checkedListBoxCode.Items[e.Index].ToString());
                else
                    checkedItems.Remove(this.checkedListBoxCode.Items[e.Index].ToString());

                LoadCheckListBox(this.checkedListBoxRegion, DEF.GetAll().Where(x => checkedItems.Contains(x.NumberDEF.ToString())).OrderBy(x => x.Region).Select(x => x.Region.ToString()).Distinct().ToList());
            }
        }

        private void checkedListBoxRegion_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.isNotUpdateRegionAll)
            {
                return;
            }

            if (this.checkedListBoxRegion.CheckedItems.Count == 1 && e.NewValue == CheckState.Unchecked)
            {
                LoadCheckListBox(this.checkedListBoxOperator, DEF.GetAll().OrderBy(x => x.Operator).Select(x => x.Operator.ToString()).Distinct().ToList());
            }
            else
            {
                List<string> checkedItems = new List<string>();
                foreach (var item in this.checkedListBoxRegion.CheckedItems)
                    checkedItems.Add(item.ToString());

                if (e.NewValue == CheckState.Checked)
                    checkedItems.Add(this.checkedListBoxRegion.Items[e.Index].ToString());
                else
                    checkedItems.Remove(this.checkedListBoxRegion.Items[e.Index].ToString());

                if (this.checkedListBoxCode.CheckedItems.Count == 0)
                {
                    LoadCheckListBox(this.checkedListBoxOperator, DEF.GetAll().Where(x => checkedItems.Contains(x.Region.ToString())).OrderBy(x => x.Operator).Select(x => x.Operator.ToString()).Distinct().ToList());
                }
                else
                {
                    LoadCheckListBox(this.checkedListBoxOperator, DEF.GetAll().Where(x => checkedItems.Contains(x.Region.ToString()) && this.checkedListBoxCode.CheckedItems.Contains(x.NumberDEF.ToString())).OrderBy(x => x.Operator).Select(x => x.Operator.ToString()).Distinct().ToList());

                }
            }
        }

        void SetItemChecked(CheckedListBox theCheckedListBox, bool status, ref bool isNotUpdate)
        {

            for (int i = 0; i < theCheckedListBox.Items.Count; i++)
            {
                if (i == theCheckedListBox.Items.Count - 1)
                {
                    isNotUpdate = false;
                }
                theCheckedListBox.SetItemChecked(i, status);
            }
        }

        private void checkBoxCodeAll_CheckedChanged(object sender, EventArgs e)
        {
            isNotUpdateCodeAll = true;
            SetItemChecked(this.checkedListBoxCode, this.checkBoxCodeAll.Checked, ref this.isNotUpdateCodeAll);
            this.textBoxCode.Text = "Все";
        }

        private void checkBoxRegionAll_CheckedChanged(object sender, EventArgs e)
        {
            isNotUpdateRegionAll = true;
            SetItemChecked(this.checkedListBoxRegion, this.checkBoxRegionAll.Checked, ref this.isNotUpdateRegionAll);
            this.textBoxRegion.Text = "Все";
        }

        private void checkBoxOperatorAll_CheckedChanged(object sender, EventArgs e)
        {
            isNotUpdateOperatorAll = true;
            SetItemChecked(this.checkedListBoxOperator, this.checkBoxOperatorAll.Checked, ref this.isNotUpdateOperatorAll);
            this.textBoxOperator.Text = "Все";
        }
        
    }
}
