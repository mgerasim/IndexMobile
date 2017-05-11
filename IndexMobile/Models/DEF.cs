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

        
        public static string GetOperator(long DEF, long Number)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                DEF theDEF = session.CreateCriteria(typeof(DEF))
                    .Add(Restrictions.Eq("NumberDEF", DEF))
                    .Add(Restrictions.Le("NumberBgn", Number))
                    .Add(Restrictions.Ge("NumberEnd", Number))
                    .UniqueResult<DEF>();

                if (theDEF == null)
                {
                    return "Не определен";
                }
                else
                {
                    return theDEF.Operator + "(" + theDEF.Region + ")";
                }

            }
        }

    }
}
