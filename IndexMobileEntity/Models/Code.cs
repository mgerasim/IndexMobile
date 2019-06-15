using Entity.Common;
using IndexMobileEntity.Models.BaseClasses;
using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Модель телефонного кода
	/// </summary>
	public class Code  : BaseClassWithTitle<Code>
	{
		/// <summary>
		/// Телефонный код
		/// </summary>
		public Code()
		{

		}

		static public IList<Code> GetAllByOperatorsListAndRegionList(List<Operator> operators, List<Region> regions)
		{
			List<Capacity> capacities = null;
				
			using (var session = NHibernateHelper.OpenSession())
			{
				var criteria = session.CreateCriteria(typeof(Capacity));
				criteria.Add(Restrictions.In(nameof(Operator), operators.Select(x => x.ID).ToArray()));
				criteria.Add(Restrictions.In(nameof(Region), regions.Select(x => x.ID).ToArray()));
				criteria.AddOrder(Order.Asc(nameof(Capacity.ID)));

				capacities = criteria.List<Capacity>().ToList();
			}

			using (var session = NHibernateHelper.OpenSession())
			{
				var criteria = session.CreateCriteria(typeof(Code));

				criteria.Add(Restrictions.In(nameof(Capacity.ID), capacities.Select(x => x.Code.ID).Distinct().ToArray()));

				return criteria.List<Code>().ToList();
			}
		}
	}
}
