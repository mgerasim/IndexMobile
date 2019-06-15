using IndexMobileEntity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IndexMobile
{
	public partial class FromDiapasonNewCodeRegionOperator : System.Windows.Forms.Form
    {
		/// <summary>
		///  Выбранные элементы из списка направления
		/// </summary>
		public List<District> DistrictCheckedList { get; set; } = new List<District>();

		/// <summary>
		/// Выбранные элементы из списка регионов
		/// </summary>
		public List<Region> RegionCheckedList { get; set; } = new List<Region>();

		/// <summary>
		/// Выбранные элементы из списка операторов сотовой связи
		/// </summary>
		public List<Operator> OperatorCheckedList { get; set; } = new List<Operator>();

		public List<Code> CodeCheckedList { get; set; } = new List<Code>();

		bool isNotUpdateCodeAll = false;
        bool isNotUpdateRegionAll = false;
        bool isNotUpdateOperatorAll = false;
		bool isNotUpdateDistrictAll = false;
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

			checkedListBoxCode.Items.AddRange(Code.GetAll().ToArray());
			checkedListBoxOperator.Items.AddRange(Operator.GetAll().ToArray());
			checkedListBoxDistrict.Items.AddRange(District.GetAll().ToArray());
			checkedListBoxRegion.Items.AddRange( IndexMobileEntity.Models.Region.GetAll().ToArray());
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
		

		private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void checkedListBoxCode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
			CodeCheckedList.Clear();

			foreach (var item in checkedListBoxCode.CheckedItems)
			{
				CodeCheckedList.Add(item as Code);
			}

			if (e.NewValue == CheckState.Unchecked)
			{
				CodeCheckedList.Remove(checkedListBoxCode.Items[e.Index] as Code);
			}
			else
			{
				CodeCheckedList.Add(checkedListBoxCode.Items[e.Index] as Code);
			}

			if (isNotUpdateCodeAll)
			{
				return;
			}

			bool isAllChecked = checkedListBoxCode.Items.Count == CodeCheckedList.Count();
			

			textBoxCode.Text = isAllChecked ? "Все" : String.Join(";", CodeCheckedList.Select(x => x.Title));

		}

		private void checkedListBoxRegion_ItemCheck(object sender, ItemCheckEventArgs e)
        {
			RegionCheckedList.Clear();

			foreach (var item in checkedListBoxRegion.CheckedItems)
			{
				RegionCheckedList.Add(item as Region);
			}

			if (e.NewValue == CheckState.Unchecked)
			{
				RegionCheckedList.Remove(checkedListBoxRegion.Items[e.Index] as Region);
			}
			else
			{
				RegionCheckedList.Add(checkedListBoxRegion.Items[e.Index] as Region);
			}

			if (isNotUpdateRegionAll)
			{
				return;
			}

			RefreshOperatorCheckedBox();



			bool isAllChecked = checkedListBoxRegion.Items.Count == RegionCheckedList.Count();
			

			textBoxRegion.Text = isAllChecked ? "Все" : String.Join(";", RegionCheckedList.Select(x => x.Title));
		}

		private void RefreshOperatorCheckedBox()
		{
			checkedListBoxOperator.Items.Clear();
			OperatorCheckedList.Clear();

			var operatorList = Operator.GetAllByRegionList(RegionCheckedList);

			checkedListBoxOperator.Items.AddRange(operatorList.ToArray());

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

			CodeCheckedList.Clear();

			if (checkBoxCodeAll.Checked)
			{
				foreach (var item in checkedListBoxCode.Items)
				{
					CodeCheckedList.Add(item as Code);
				}
			}

			SetItemChecked(this.checkedListBoxCode, this.checkBoxCodeAll.Checked, ref this.isNotUpdateCodeAll);
            this.textBoxCode.Text = "Все";
        }

        private void checkBoxRegionAll_CheckedChanged(object sender, EventArgs e)
        {
            isNotUpdateRegionAll = true;

			RegionCheckedList.Clear();

			if (checkBoxRegionAll.Checked)
			{
				foreach (var item in checkedListBoxRegion.Items)
				{
					RegionCheckedList.Add(item as Region);
				}
			}
			SetItemChecked(this.checkedListBoxRegion, this.checkBoxRegionAll.Checked, ref this.isNotUpdateRegionAll);
            this.textBoxRegion.Text = "Все";
        }

        private void checkBoxOperatorAll_CheckedChanged(object sender, EventArgs e)
        {
            isNotUpdateOperatorAll = true;

			OperatorCheckedList.Clear();

			if (checkBoxOperatorAll.Checked)
			{
				foreach (var item in checkedListBoxOperator.Items)
				{
					OperatorCheckedList.Add(item as Operator);
				}
			}

			SetItemChecked(this.checkedListBoxOperator, this.checkBoxOperatorAll.Checked, ref this.isNotUpdateOperatorAll);
            this.textBoxOperator.Text = "Все";
        }

		private void checkedListBoxDistrict_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			DistrictCheckedList.Clear();

			foreach(var item in checkedListBoxDistrict.CheckedItems)
			{
				DistrictCheckedList.Add(item as District);
			}

			if (e.NewValue == CheckState.Unchecked)
			{
				DistrictCheckedList.Remove(checkedListBoxDistrict.Items[e.Index] as District);
			}
			else
			{
				DistrictCheckedList.Add(checkedListBoxDistrict.Items[e.Index] as District);
			}
			
			if (isNotUpdateDistrictAll)
			{
				return;
			}

			bool isAllChecked = checkedListBoxDistrict.Items.Count == DistrictCheckedList.Count();

			RefreshRegionCheckedBox();
			
			textBoxDistrict.Text = isAllChecked ? "Все" : String.Join(";", DistrictCheckedList.Select(x => x.Title));


		}

		private void RefreshRegionCheckedBox()
		{
			checkedListBoxRegion.Items.Clear();
			RegionCheckedList.Clear();

			var regionList = new List<Region>();

			foreach(var district in DistrictCheckedList)
			{
				regionList.AddRange(district.Regions);
			}

			checkedListBoxRegion.Items.AddRange(regionList.Distinct().OrderBy(x => x.Title).ToArray());
		}

		private void checkedListBoxOperator_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			OperatorCheckedList.Clear();

			foreach (var item in checkedListBoxOperator.CheckedItems)
			{
				OperatorCheckedList.Add(item as Operator);
			}

			if (e.NewValue == CheckState.Unchecked)
			{
				OperatorCheckedList.Remove(checkedListBoxOperator.Items[e.Index] as Operator);
			}
			else
			{
				OperatorCheckedList.Add(checkedListBoxOperator.Items[e.Index] as Operator);
			}

			if (isNotUpdateOperatorAll)
			{
				return;
			}

			bool isAllChecked = checkedListBoxOperator.Items.Count == OperatorCheckedList.Count();

			RefreshCodeCheckedBox();
			
			textBoxOperator.Text = isAllChecked ? "Все" : String.Join(";", OperatorCheckedList.Select(x => x.Title));

		}

		private void RefreshCodeCheckedBox()
		{
			checkedListBoxCode.Items.Clear();
			CodeCheckedList.Clear();

			var codeList = Code.GetAllByOperatorsListAndRegionList(OperatorCheckedList, RegionCheckedList);

			checkedListBoxCode.Items.AddRange(codeList.Distinct().OrderBy(x => x.Title).ToArray());
		}

		private void checkBoxDistrictAll_CheckedChanged(object sender, EventArgs e)
		{
			isNotUpdateDistrictAll = true;
			SetItemChecked(this.checkedListBoxDistrict, this.checkBoxDistrictAll.Checked, ref this.isNotUpdateDistrictAll);

			DistrictCheckedList.Clear();

			if (checkBoxDistrictAll.Checked)
			{
				foreach (var item in checkedListBoxDistrict.Items)
				{
					DistrictCheckedList.Add(item as District);
				}
			}

			this.textBoxOperator.Text = "Все";
		}
	}
}
