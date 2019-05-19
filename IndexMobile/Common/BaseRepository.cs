using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;
using NHibernate;
using NHibernate.Criterion;

namespace Entity.Common
{
    public class BaseRepository<T>
    {
        #region IRepository<T> Members

        internal void Save(BaseClass<T> entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        internal void Update(BaseClass<T> entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        internal void Delete(BaseClass<T> entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        internal T GetById(int ID)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(T)).Add(Restrictions.Eq("ID", ID)).UniqueResult<T>();

            }
        }

        internal List<T> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(T));
                criteria.AddOrder(Order.Asc("ID"));
                return criteria.List<T>().ToList<T>();
            }
        }

        #endregion


    }
}
