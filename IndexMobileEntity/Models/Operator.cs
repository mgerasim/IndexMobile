using Entity.Common;
using IndexMobileEntity.Models.BaseClasses;
using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Модель сотового оператора 
	/// </summary>
	public class Operator : BaseClassWithTitle<Operator>
	{
		/// <summary>
		/// Конструктор
		/// </summary>
		public Operator()
		{

		}


		static public IList<Operator> GetAllByRegionList(List<Region> regions)
		{
			List<Capacity> capacities = null;

			using (var session = NHibernateHelper.OpenSession())
			{
				var criteria = session.CreateCriteria(typeof(Capacity));
				criteria.Add(Restrictions.In(nameof(Region), regions.Select(x => x.ID).ToArray()));
				criteria.AddOrder(Order.Asc(nameof(Capacity.ID)));

				capacities = criteria.List<Capacity>().ToList();
			}

			using (var session = NHibernateHelper.OpenSession())
			{
				var criteria = session.CreateCriteria(typeof(Operator));

				criteria.Add(Restrictions.In(nameof(Operator.ID), capacities.Select(x => x.Operator.ID).Distinct().ToArray()));

				criteria.AddOrder(Order.Asc(nameof(Operator.Title)));

				return criteria.List<Operator>().Distinct().ToList();
			}
		}
	}
}
