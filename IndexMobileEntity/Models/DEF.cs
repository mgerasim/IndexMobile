using Entity.Common;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace IndexMobileEntity.Models
{
	/// <summary>
	/// Распределение сотовых номеров по операторам и регионам
	/// </summary>
	public class DEF : BaseClass<DEF>
    {
        public virtual long   NumberDEF  { get; set; }
        public virtual long   NumberBgn  { get; set; }
        public virtual long   NumberEnd  { get; set; }
        public virtual string Operator { get; set; }
        public virtual string Region   { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
        public DEF()
        {
            NumberDEF = 0;
            NumberBgn = 0;
            NumberEnd = 0;
            Operator = "";
            Region  =  "";
        }

        /// <summary>
		/// Получает сотового оператора
		/// </summary>
		/// <param name="DEF"></param>
		/// <param name="Number"></param>
		/// <returns></returns>
        public static DEF GetOperator(long DEF, long Number)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var result = session.CreateCriteria(typeof(DEF))
                        .Add(Restrictions.Eq("NumberDEF", DEF))
                        .Add(Restrictions.Le("NumberBgn", Number))
                        .Add(Restrictions.Ge("NumberEnd", Number))
                        .List<DEF>().ToList<DEF>();

                    if (result == null)
                    {
                        return null;
                    }

                    DEF def = result[0];

                    return def;

                }
            }
            catch
            {
                return null;
            }
            
        }

    }
}
