using Entity.Common;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobileEntity.Models
{
    public class Selection : Entity.Common.BaseClass<Selection>
    {
        public virtual int Count { get; set; }
        public virtual string Name { get; set; }
        public virtual Access Access { get; set; }
        public Selection()
        {
            Name = "";
            Count = 0;
        }

        public virtual List<Telephone> Telephones
        {
            get
            {
                return Telephone.GetAllBySelection(this);
            }
        }
        public virtual string DisplayName
        {
            get
            {
                return "Отбор " + Count.ToString() + " шт. от " + this.created_at.ToString() ;
            }
        }
        static public List<Selection> GetAllByAccess(Access theAccess)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Selection));
                criteria.Add(Restrictions.Eq("Access", theAccess));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Selection>().ToList<Selection>();
            }
        }
       

    }
}
