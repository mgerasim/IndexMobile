using Entity.Common;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Выборка номеров в отборе
	/// </summary>
	public class Selection : BaseClass<Selection>
    {
		/// <summary>
		/// Количество
		/// </summary>
        public virtual int Count { get; set; }

		/// <summary>
		/// Наименование
		/// </summary>
        public virtual string Name { get; set; }

		/// <summary>
		/// Отбор
		/// </summary>
        public virtual Access Access { get; set; }

		/// <summary>
		///  Конструктор
		/// </summary>
        public Selection()
        {
            Name = string.Empty;

            Count = 0;
        }

		/// <summary>
		/// Список номеров
		/// </summary>
        public virtual List<Telephone> Telephones => Telephone.GetAllBySelection(this);

		/// <summary>
		/// Пользовательское наименование 
		/// </summary>
		public virtual string DisplayName => "Отбор " + Count.ToString() + " шт. от " + this.created_at.ToString();

		/// <summary>
		/// Получает список выборок по отбору
		/// </summary>
		/// <param name="access">Отбор</param>
		/// <returns></returns>
        static public List<Selection> GetAllByAccess(Access access)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Selection));
                criteria.Add(Restrictions.Eq("Access", access));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Selection>().ToList<Selection>();
            }
        }
    }
}
