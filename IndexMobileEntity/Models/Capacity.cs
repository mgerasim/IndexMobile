using Entity.Common;
using NHibernate.Criterion;
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
		public virtual int MinValue { get; set; }

		/// <summary>
		/// Верхняя граница диапазона
		/// </summary>
		public virtual int MaxValue { get; set; }

		/// <summary>
		/// Телефонный код для номеров в емкости
		/// </summary>
		public virtual Code Code { get; set; }

		/// <summary>
		/// Оператор сотовой связи
		/// </summary>
		public virtual Operator Operator { get; set; }

		/// <summary>
		///  Регион
		/// </summary>
		public virtual Region Region { get; set; }

		/// <summary>
		/// Получает операторов сотовой связи по региону
		/// </summary>
		/// <param name="region">Регион</param>
		/// <returns></returns>
		static public IList<Operator> GetOperatorListByRegion(Region region)
		{
			using (var session = NHibernateHelper.OpenSession())
			{
				var criteria = session.CreateCriteria(typeof(Capacity));
				criteria.Add(Restrictions.Eq(nameof(Models.Region), region));
				criteria.AddOrder(Order.Asc(nameof(Capacity.ID)));
				return criteria.List<Capacity>().Select(c => c.Operator).ToList();
			}
		}

		static public IList<Capacity> GetAllByOperatorsListAndRegionListAndCodeList(List<Operator> operators, List<Region> regions, List<Code> codes)
		{
			using (var session = NHibernateHelper.OpenSession())
			{
				var criteria = session.CreateCriteria(typeof(Capacity));
				criteria.Add(Restrictions.In(nameof(Operator), operators.Select(x => x.ID).Distinct().ToArray()));
				criteria.Add(Restrictions.In(nameof(Region), regions.Select(x => x.ID).Distinct().ToArray()));
				criteria.Add(Restrictions.In(nameof(Code), codes.Select(x => x.ID).Distinct().ToArray()));
				criteria.AddOrder(Order.Asc(nameof(Capacity.ID)));

				return criteria.List<Capacity>();
			}
		}
	}
}