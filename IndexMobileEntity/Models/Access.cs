using Entity.Common;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Отбор по генерации номеров
	/// </summary>
	public class Access : BaseClass<Access>
    {
		/// <summary>
		/// Наименование
		/// </summary>
        public virtual string Name { get; set; }

		/// <summary>
		/// Пользовательское наименование
		/// </summary>
        public virtual string DisplayName => this.Name + " Всего: " + this.TelephonesCount.ToString() + " Свободно: " + this.TelephonesBySelectionIsNullCount.ToString();

		/// <summary>
		///  Конструктор
		/// </summary>
		public Access()
        {
            Name = string.Empty;
        }

		/// <summary>
		/// Диапозоны
		/// </summary>
        public virtual List<Diapason> Diapasons => Diapason.GetAllByAccess(this);

		/// <summary>
		/// Выборки
		/// </summary>
		public virtual List<Selection> Selections => Selection.GetAllByAccess(this);

		/// <summary>
		/// Номера
		/// </summary>
		public virtual List<Telephone> Telephones => Telephone.GetAllByAccess(this);

		/// <summary>
		/// Номера не попавшие в выборку
		/// </summary>
		public virtual List<Telephone> TelephonesBySelectionIsNull
        {
            get
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                    criteria.Add(Restrictions.Eq("Access", this));
                    criteria.Add(Restrictions.IsNull("Selection"));
                    criteria.AddOrder(Order.Asc("NumberOrder"));
                    criteria.SetMaxResults(100000);
                    return criteria.List<Telephone>().ToList<Telephone>();
                }
            }
        }

		/// <summary>
		/// Количество номеров не попавшие в выборку из отбора
		/// </summary>
        public virtual long TelephonesBySelectionIsNullCount
        {
            get
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                    criteria.Add(Restrictions.Eq("Access", this));
                    criteria.Add(Restrictions.IsNull("Selection"));
                    criteria.SetProjection(Projections.Count("Number"));
                    return (int) criteria.UniqueResult();
                }
            }
        }

		/// <summary>
		/// Количество номеров в отборе (объем отбора)
		/// </summary>
        public virtual long TelephonesCount
        {
            get
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                    criteria.Add(Restrictions.Eq("Access", this));
                    criteria.SetProjection(Projections.Count("Number"));
                    return (int)criteria.UniqueResult();
                }
            }
        }
    }
}
