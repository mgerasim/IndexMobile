using Entity.Common;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Диапозон номеров в отборе
	/// </summary>
	public class Diapason : BaseClass<Diapason>
    {
		/// <summary>
		/// Максимальное значение
		/// </summary>
        public virtual long ValueMax { get; set; }

		/// <summary>
		/// Минимальное значение
		/// </summary>
        public virtual long ValueMin { get; set; }

		/// <summary>
		/// Наименование диапозона
		/// </summary>
        public virtual string Name { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
        public Diapason()
        {
            ValueMax = 0;
            ValueMin = 0;
        }

		/// <summary>
		/// Отбор к которому принадлежит отбор
		/// </summary>
        public virtual Access Access { get; set; }

		/// <summary>
		/// Список номеров в диапозоне
		/// </summary>
        public virtual List<Telephone> Telephones => Telephone.GetAllByDiapason(this);

		/// <summary>
		/// Пользовательское наименование
		/// </summary>
		public virtual string DisplayName => this.ValueMin.ToString("0000000000") + " ... " + this.ValueMax.ToString("0000000000") + " =" + this.Telephones.Count + " - " + Telephone.GetCountFreeByDiapason(this).ToString();

		/// <summary>
		/// Получает диапозоны в рамках отбора
		/// </summary>
		/// <param name="access">Отбор</param>
		/// <returns></returns>
		static public List<Diapason> GetAllByAccess(Access access)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Diapason));
                criteria.Add(Restrictions.Eq("Access", access));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Diapason>().ToList<Diapason>();
            }
        }
    }
}
