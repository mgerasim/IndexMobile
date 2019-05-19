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
            
                Dictionary<char, char> translate = new Dictionary<char, char>();
                translate.Add('q', 'й');
                translate.Add('w', 'ц');
                translate.Add('e', 'у');
                translate.Add('r', 'к');
                translate.Add('t', 'е');
                translate.Add('y', 'н');
                translate.Add('u', 'г');
                translate.Add('i', 'ш');
                translate.Add('o', 'щ');
                translate.Add('p', 'з');
                translate.Add('[', 'х');
                translate.Add(']', 'ъ');

                translate.Add('a', 'ф');
                translate.Add('s', 'ы');
                translate.Add('d', 'в');
                translate.Add('f', 'а');
                translate.Add('g', 'п');
                translate.Add('h', 'р');
                translate.Add('j', 'о');
                translate.Add('k', 'л');
                translate.Add('l', 'д');
                translate.Add(';', 'ж');
                translate.Add('\'', 'э');
                
                translate.Add('z', 'я');
                translate.Add('x', 'ч');
                translate.Add('c', 'с');
                translate.Add('v', 'м');
                translate.Add('b', 'и');
                translate.Add('n', 'т');
                translate.Add('m', 'ь');
                translate.Add(',', 'б');
                translate.Add('.', 'ю');

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
