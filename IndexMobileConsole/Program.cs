using IndexMobileEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobileConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //UpdateSchema();
            //AccessSave();
            //AccessList();
            SupportOperatorTele2();
            Console.ReadKey();
        }
        static void SupportOperatorTele2()
        {
            string res = IndexMobileCore.Helper.Telephone.OperatorTele2(924, 1086744, null, null);
            Console.WriteLine(res);
        }
        static void AccessList()
        {
            foreach (var item in Access.GetAll())
            {
                Console.WriteLine(item.Name);
            }
        }
        static void AccessSave()
        {
            Access theAccess = new Access();
            theAccess.Save();
            theAccess.Name = "Выборка " + theAccess.ID.ToString();
            theAccess.Update();
        }
        static void UpdateSchema()
        {
            Entity.Common.NHibernateHelper.UpdateSchema();
        }
    }
}
