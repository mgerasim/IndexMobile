using Entity.Common;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using System.Linq;

namespace IndexMobileEntity.Models
{
	public class Nameface : BaseClass<Nameface>
    {
        public virtual string   NameOn  { get; set; }
        public virtual string   NameOff  { get; set; }

        static public string NameOffTranslate(string _name)
        {

			Dictionary<char, char> translate = new Dictionary<char, char>
			{
				{ 'q', 'й' },
				{ 'w', 'ц' },
				{ 'e', 'у' },
				{ 'r', 'к' },
				{ 't', 'е' },
				{ 'y', 'н' },
				{ 'u', 'г' },
				{ 'i', 'ш' },
				{ 'o', 'щ' },
				{ 'p', 'з' },
				{ '[', 'х' },
				{ ']', 'ъ' },
				{ 'a', 'ф' },
				{ 's', 'ы' },
				{ 'd', 'в' },
				{ 'f', 'а' },
				{ 'g', 'п' },
				{ 'h', 'р' },
				{ 'j', 'о' },
				{ 'k', 'л' },
				{ 'l', 'д' },
				{ ';', 'ж' },
				{ '\'', 'э' },
				{ 'z', 'я' },
				{ 'x', 'ч' },
				{ 'c', 'с' },
				{ 'v', 'м' },
				{ 'b', 'и' },
				{ 'n', 'т' },
				{ 'm', 'ь' },
				{ ',', 'б' },
				{ '.', 'ю' }
			};

			string res = "";

                foreach (var item in _name.ToLower())
                {
                    if (translate.ContainsKey(item))
                    {
                        res += translate[item].ToString();
                    }
                }

                return res;
            
        }
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
