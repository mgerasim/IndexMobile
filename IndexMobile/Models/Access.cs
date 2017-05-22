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
    public class Access : Entity.Common.BaseClass<Access>
    {
        public virtual string Name { get; set; }

        public virtual string DisplayName
        {
            get
            {
                return this.Name  +" Всего: " + this.TelephonesCount.ToString() + " Свободно: " + this.TelephonesBySelectionIsNullCount.ToString();
            }
        }

        public Access()
        {
            Name = "";
        }

        public virtual List<Diapason> Diapasons
        {
            get
            {
                return Diapason.GetAllByAccess(this);
            }
        }
        public virtual List<Selection> Selections
        {
            get
            {
                return Selection.GetAllByAccess(this);
            }
        }
        public virtual List<Telephone> Telephones
        {
            get
            {
                return Telephone.GetAllByAccess(this);
            }
        }

        public virtual List<Telephone> TelephonesBySelectionIsNull
        {
            get
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(typeof(Telephone));
                    criteria.Add(Restrictions.Eq("Access", this));
                    criteria.Add(Restrictions.IsNull("Selection"));
                    criteria.AddOrder(Order.Asc("ID"));
                    return criteria.List<Telephone>().ToList<Telephone>();
                }
            }
        }
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
