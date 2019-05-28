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
	/// <summary>
	/// Форма отображения исключений
	/// </summary>
	public partial class FormException : Form
	{
		/// <summary>
		/// Исключение
		/// </summary>
		private Exception _exception = null;

		/// <summary>
		/// Конструктор
		/// </summary>
		public FormException(Exception exc)
		{
			InitializeComponent();

			_exception = exc;
		}

		private void FormException_Load(object sender, EventArgs e)
		{
			textBoxException.Text = $@"{_exception.Message}{Environment.NewLine}{Environment.NewLine}{_exception.StackTrace}";
		}
	}
}
