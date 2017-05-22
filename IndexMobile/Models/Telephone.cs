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
    public class Telephone : Entity.Common.BaseClass<Telephone>
    {
        public virtual long Number { get; set; }

        public virtual Selection Selection { get; set; }
        public virtual Diapason Diapason { get; set; }
        public virtual Access Access { get; set; }

        public Telephone()
        {
            Number = 0;
        }

        static public bool CheckInAccess(long Number, Access theAccess)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Telephone))
                .Add(Restrictions.Eq("Access", theAccess))
                .Add(Restrictions.Eq("Number", Number));
                criteria.AddOrder(Order.Asc("ID"));
                if (criteria.List<Telephone>().ToList<Telephone>().Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        static public List<Telephone> GetAllByDiapason(Diapason theDiapason)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                criteria.Add(Restrictions.Eq("Diapason", theDiapason));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Telephone>().ToList<Telephone>();
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
