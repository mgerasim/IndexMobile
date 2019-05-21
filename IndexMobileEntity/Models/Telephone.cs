using Entity.Common;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Телефонный номер
	/// </summary>
	public class Telephone : BaseClass<Telephone>
    {
		/// <summary>
		/// Телефонный номер
		/// </summary>
		public virtual long Number { get; set; } = 0;

		/// <summary>
		/// Принадлежность в выборке
		/// </summary>
        public virtual Selection Selection { get; set; }

		/// <summary>
		/// Принадлежность к диапазону
		/// </summary>
        public virtual Diapason Diapason { get; set; }

		/// <summary>
		/// Принадлежность к отбору
		/// </summary>
        public virtual Access Access { get; set; }

		/// <summary>
		/// Случайный порядковый номер в выборке
		/// </summary>
        public virtual int NumberOrder { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
        public Telephone()
		{ 

		}

		/// <summary>
		/// Проверка принадлежности в отборе
		/// </summary>
		/// <param name="number">Телефонный номер</param>
		/// <param name="access">Экземпляр отбора</param>
		/// <returns></returns>
        static public bool CheckInAccess(long number, Access access)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(Telephone))
                .Add(Restrictions.Eq(nameof(Access), access))
                .Add(Restrictions.Eq(nameof(number), number));

                criteria.AddOrder(Order.Asc(nameof(access.ID)));

				criteria.SetProjection(Projections.Count(nameof(access.ID)));

				var count = (int)criteria.UniqueResult();

				return count > 0;
            }
        }

		/// <summary>
		/// Список телефонных номеров в диапазоне
		/// </summary>
		/// <param name="diapason">Диапазон</param>
		/// <returns></returns>
        static public List<Telephone> GetAllByDiapason(Diapason diapason)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Telephone));
				criteria.Add(Restrictions.Eq(nameof(Access), diapason.Access));
                criteria.Add(Restrictions.Eq(nameof(Diapason), diapason));
                criteria.AddOrder(Order.Asc(nameof(diapason.ID)));

                return criteria.List<Telephone>().ToList();
            }
        }

		/// <summary>
		/// Получает количество свободных номеров в диапазоне
		/// </summary>
		/// <param name="diapason"></param>
		/// <returns></returns>
		static public int GetCountFreeByDiapason(Diapason diapason)
		{
			using (var session = NHibernateHelper.OpenSession())
			{
				var count = session.CreateCriteria(typeof(Telephone))
					.Add(Restrictions.Eq(nameof(Access), diapason.Access))
					.Add(Restrictions.Eq(nameof(Diapason), diapason))
					.Add(Restrictions.IsNull(nameof(Selection)))
					.SetProjection(Projections.Count(nameof(diapason.ID)))
					.UniqueResult();

				return (int)count;
			}
		}

		/// <summary>
		/// Получаем количество номеров в диапазоне
		/// </summary>
		/// <param name="diapason"></param>
		/// <returns></returns>
		static public int GetCountAllByDiapason(Diapason diapason)
		{
			using (var session = NHibernateHelper.OpenSession())
			{
				var count = session.CreateCriteria(typeof(Telephone))
					.Add(Restrictions.Eq(nameof(Access), diapason.Access))
					.Add(Restrictions.Eq(nameof(Diapason), diapason))
					.SetProjection(Projections.Count(nameof(diapason.ID)))
					.UniqueResult();

				return (int)count;
			}
		}

		/// <summary>
		/// Получает список телефонов в выборке
		/// </summary>
		/// <param name="selection">Выборка</param>
		/// <returns></returns>
        static public List<Telephone> GetAllBySelection(Selection selection)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                criteria.Add(Restrictions.Eq(nameof(Selection), selection));
                criteria.AddOrder(Order.Asc(nameof(selection.ID)));
                return criteria.List<Telephone>().ToList();
            }
        }

		/// <summary>
		///  Получает список телефонов по отбору
		/// </summary>
		/// <param name="access">Отбор</param>
		/// <returns></returns>
        static public List<Telephone> GetAllByAccess(Access access)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                criteria.Add(Restrictions.Eq(nameof(Access), access));
                criteria.AddOrder(Order.Asc(nameof(access.ID)));
                return criteria.List<Telephone>().ToList();
            }
        }
    }
}
