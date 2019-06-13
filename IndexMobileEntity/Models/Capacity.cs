using Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobileEntity.Models
{
	public class Capacity : BaseClass<Capacity>
	{
		/// <summary>
		/// Нижняя граница диапозона
		/// </summary>
		public int MinValue { get; set; }

		/// <summary>
		/// Верхняя граница диапазона
		/// </summary>
		public int MaxValue { get; set; }

		/// <summary>
		/// Телефонный код для номеров в емкости
		/// </summary>
		public Code Code { get; set; }
	}
}
