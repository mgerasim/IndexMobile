using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Модель региона присутствия сотового оператора
	/// </summary>
	public class Region : BaseClass<Region>
	{
		/// <summary>
		/// Наименование региона
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
		public Region()
		{

		}
	}
}
