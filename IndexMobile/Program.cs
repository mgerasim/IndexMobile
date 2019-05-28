using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IndexMobile
{
	static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form());

			Application.ThreadException += Application_ThreadException;

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

		/// <summary>
		///  Необработанные исключения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Исключения потока
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			throw new NotImplementedException();
		}

		private static Random rng = new Random();

		/// <summary>
		/// Расширение - перемешивает элементы списка случайным порядком
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
