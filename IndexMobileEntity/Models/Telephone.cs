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
        public virtual long Number { get; set; }

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
            Number = 0;
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
                ICriteria criteria = session.CreateCriteria(typeof(Telephone))
                .Add(Restrictions.Eq("Access", access))
                .Add(Restrictions.Eq("Number", number));
                criteria.AddOrder(Order.Asc("ID"));

				return (criteria.List<Telephone>().ToList<Telephone>().Count > 0);
            }
        }

		/// <summary>
		/// Список телефонных номеров в диапазоне
		/// </summary>
		/// <param name="diapason"></param>
		/// <returns></returns>
        static public List<Telephone> GetAllByDiapason(Diapason diapason)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                criteria.Add(Restrictions.Eq("Diapason", diapason));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Telephone>().ToList<Telephone>();
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
					.Add(Restrictions.Eq("Diapason", diapason))
					.Add(Restrictions.IsNull("Selection"))
					.SetProjection(Projections.Count("Number"))
					.UniqueResult();

				return (int)count;
			}
		}

        static public List<Telephone> GetAllBySelection(Selection theSelection)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                criteria.Add(Restrictions.Eq("Selection", theSelection));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Telephone>().ToList<Telephone>();
            }
        }

        static public List<Telephone> GetAllByAccess(Access theAccess)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                criteria.Add(Restrictions.Eq("Access", theAccess));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Telephone>().ToList<Telephone>();
            }
        }

       

    }
}
