using Entity.Common;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobileEntity.Models.BaseClasses
{
	/// <summary>
	/// Базовый класс для классов с ключевым полем Наименование
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BaseClassWithTitle<T> : BaseClass<T>
	{
		/// <summary>
		/// Наименование модели класса
		/// </summary>
		public virtual string Title { get; set; } = string.Empty;

		/// <summary>
		/// Конструктор
		/// </summary>
		public BaseClassWithTitle() : base()
		{

		}

		/// <summary>
		/// Получает экземпляр модели по уникальному номеру
		/// </summary>
		/// <param name="title"></param>
		/// <returns></returns>
		public static T GetByTitle(string title)
		{
			using (var session = NHibernateHelper.OpenSession())
			{
				return session.CreateCriteria(typeof(T)).Add(Restrictions.Eq(nameof(Title), title)).UniqueResult<T>();
			}
		}
	}
}
