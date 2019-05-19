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
    public class Diapason : Entity.Common.BaseClass<Diapason>
    {
        public virtual long ValueMax { get; set; }

        public virtual long ValueMin { get; set; }


        public Diapason()
        {
            ValueMax = 0;
            ValueMin = 0;
        }

        public virtual Access Access { get; set; }

        public virtual List<Telephone> Telephones
        {
            get
            {
                return Telephone.GetAllByDiapason(this);
            }
        }

        public virtual string DisplayName
        {
            get
            {
                return this.ValueMin.ToString("0000000000") + " ... " + this.ValueMax.ToString("0000000000") +" =" + this.Telephones.Count;
            }
        }

        static public List<Diapason> GetAllByAccess(Access theAccess)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(Diapason));
                criteria.Add(Restrictions.Eq("Access", theAccess));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<Diapason>().ToList<Diapason>();
            }
        }
    }
}
