using Entity.Common;
using IndexMobileEntity.Models.BaseClasses;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Модель региона присутствия сотового оператора
	/// </summary>
	public class Region : BaseClassWithTitle<Region>
	{
		/// <summary>
		/// Территориальное направление 
		/// </summary>
		public virtual District District { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
		public Region()
		{

		}

		/// <summary>
		/// Получает регионы по территориальному направлению
		/// </summary>
		/// <param name="district">территориальное направление</param>
		/// <returns></returns>
		static public IList<Region> GetAllByDistrict(District district)
		{
			using (var session = NHibernateHelper.OpenSession())
			{
				var criteria = session.CreateCriteria(typeof(Region));
				criteria.Add(Restrictions.Eq(nameof(District), district));
				criteria.AddOrder(Order.Asc(nameof(Region.ID)));
				return criteria.List<Region>();
			}
		}
	}
}
