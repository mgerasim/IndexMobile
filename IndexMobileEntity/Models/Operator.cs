using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Модель сотового оператора 
	/// </summary>
	public class Operator : BaseClass<Operator>
	{
		/// <summary>
		/// Наименование оператора
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
		public Operator()
		{

		}
	}
}
