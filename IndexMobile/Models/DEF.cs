using Entity.Common;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobile.Models
{
    public class DEF : Entity.Common.BaseClass<DEF>
    {
        public virtual long   NumberDEF  { get; set; }
        public virtual long   NumberBgn  { get; set; }
        public virtual long   NumberEnd  { get; set; }
        public virtual string Operator { get; set; }
        public virtual string Region   { get; set; }

        public DEF()
        {
            NumberDEF = 0;
            NumberBgn = 0;
            NumberEnd = 0;
            Operator = "";
            Region  =  "";
        }

        
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

                    DEF theDEF = result[0];

                    return theDEF;

                }
            }
            catch
            {
                return null;
            }
            
        }

    }
}
