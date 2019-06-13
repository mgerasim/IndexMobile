using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Модель округа
	/// </summary>
	public class District : BaseClass<District>
	{
		/// <summary>
		/// Наименование округа
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
		public District()
		{

		}
	}
}
