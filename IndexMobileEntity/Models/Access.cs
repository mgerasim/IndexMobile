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
		///  Всего номеров
		/// </summary>
		public virtual long CapacityTotal { get; set; }

		/// <summary>
		/// Свободных номеров
		/// </summary>
		public virtual long CapacityFree { get; set; }
		/// <summary>
		/// Пользовательское наименование
		/// </summary>
        public virtual string DisplayName => $@"{Name} Всего: {CapacityTotal} Свободно: {CapacityFree}";

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
                    var criteria = session.CreateCriteria(typeof(Telephone))
						.Add(Restrictions.Eq(nameof(Access), this))
						.Add(Restrictions.IsNull(nameof(Selection)))
						.AddOrder(Order.Asc("NumberOrder"))
						.SetMaxResults(100000);

                    return criteria.List<Telephone>().ToList();
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
                using (var session = NHibernateHelper.OpenSession())
                {
                    var criteria = session.CreateCriteria(typeof(Telephone))
						.Add(Restrictions.Eq(nameof(Access), this))
						.Add(Restrictions.IsNull(nameof(Selection)))
						.SetProjection(Projections.Count(nameof(ID)));
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
                using (var session = NHibernateHelper.OpenSession())
                {
                    var criteria = session.CreateCriteria(typeof(Telephone))
						.Add(Restrictions.Eq(nameof(Access), this))
						.SetProjection(Projections.Count(nameof(ID)));

                    return (int)criteria.UniqueResult();
                }
            }
        }
    }
}
