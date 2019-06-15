using Entity.Common;
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
		public virtual string DisplayName => "Отбор " + Count.ToString() + " шт. от " + this.CreatedAt.ToString();

		/// <summary>
		/// Получает список выборок по отбору
		/// </summary>
		/// <param name="access">Отбор</param>
		/// <returns></returns>
        static public List<Selection> GetAllByAccess(Access access)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(Selection))
					.Add(Restrictions.Eq(nameof(Access), access))
					.AddOrder(Order.Asc(nameof(access.ID)));

                return criteria.List<Selection>().ToList();
            }
        }
    }
}
