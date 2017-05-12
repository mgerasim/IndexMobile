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
    public class Nameface : Entity.Common.BaseClass<Nameface>
    {
        public virtual string   NameOn  { get; set; }
        public virtual string   NameOff  { get; set; }
        public Nameface()
        {
        }

        public static bool Check(string Name)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var result = session.CreateCriteria(typeof(Nameface))
                        .Add(Restrictions.Eq("NameOn", Name).IgnoreCase())
                        .List<Nameface>().ToList<Nameface>();

                    if (result == null)
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static string Normalize(string Name)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var result = session.CreateCriteria(typeof(Nameface))
                        .Add(Restrictions.Like("NameOff", Name))
                        .List<Nameface>().ToList();

                    if (result == null)
                    {
                        return "";
                    }

                    return result[0].NameOn;
                }
            }
            catch
            {
                return "";
            }
        }
        

    }
}
