using NHibernate;
using NHibernate.Cfg;
using System;


namespace Entity.Common
{
	public class NHibernateHelper
    {
		/// <summary>
		/// Строка соединения с базой данных
		/// </summary>
		private static string _connectionString = string.Empty;

		/// <summary>
		/// Фабрика сессии
		/// </summary>
        private static ISessionFactory _sessionFactory;

		/// <summary>
		/// Строка соединения с базой данных
		/// </summary>
		public static string ConnectionString
		{
			get
			{
				if (string.IsNullOrEmpty(_connectionString))
				{
					using (var session = OpenSession())
					{
						_connectionString = session.Connection.ConnectionString;
					}
				}

				return _connectionString;
			}
		}

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    
                    configuration.AddAssembly("IndexMobileEntity");

                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void UpdateSchema()
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly("IndexMobileEntity");

            NHibernate.Tool.hbm2ddl.SchemaUpdate schemaUpdate
                = new NHibernate.Tool.hbm2ddl.SchemaUpdate(configuration);
            schemaUpdate.Execute(true, true);

            foreach (var item in schemaUpdate.Exceptions)
            {
                Console.WriteLine(item.Message + "\n\n" + item.Source + "\n\n" + item.StackTrace + "\n\n");
                if (item.InnerException != null) Console.WriteLine(item.InnerException.Message);
            }
        }
    }
}