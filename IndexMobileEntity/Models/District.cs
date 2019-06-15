using IndexMobileEntity.Models.BaseClasses;
using System.Collections.Generic;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Модель округа
	/// </summary>
	public class District : BaseClassWithTitle<District>
	{
		/// <summary>
		/// Регионы
		/// </summary>
		public virtual IList<Region> Regions => Region.GetAllByDistrict(this);

		/// <summary>
		/// Конструктор
		/// </summary>
		public District()
		{

		}
	}
}
