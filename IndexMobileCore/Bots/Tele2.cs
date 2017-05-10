using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Forms;

namespace IndexMobileCore.Bots
{
    public class Tele2
    {
        public void Start()
        {
            Uri uri = new Uri("http://mnp.tele2.ru/whois.html");
            run_Start(uri);
        }

        private void run_Start(Uri url) 
        {
            var th = new Thread(() =>
            {
                var br = new WebBrowser();
                br.DocumentCompleted += browser_StartCompleted;
                br.ScriptErrorsSuppressed = true;
                br.Navigate(url);
                Application.Run();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        void Log(string msg)
        {
            Console.WriteLine(msg);
        }

        void browser_StartCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var br = sender as WebBrowser;
            if (br.Url == e.Url)
            {
                Log(e.Url.ToString());
                Log(br.Document.Body.OuterText);
                try
                {
                    HtmlElement logBut = br.Document.GetElementsByTagName("button")[0];
                    br.Document.GetElementById("phone").InnerText = "9241086744";
                    br.DocumentCompleted -= browser_StartCompleted;
                    br.DocumentCompleted += browser_EndCompleted;
                    logBut.InvokeMember("click");
                    Log("Natigated to " + e.Url);
                    // Application.ExitThread();   // Stops the thread

                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                }
            }
        }

        void browser_EndCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var br = sender as WebBrowser;
            if (br.Url == e.Url)
            {
                Log(br.Document.Body.OuterText);
                Application.ExitThread();   // Stops the thread
            }
        }
    }
}
