using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobileCore.Helper
{
    static public class DEF
    {
        static public void Parser()
        {
            try
            {
                string urlAddress = "https://www.rossvyaz.ru/docs/articles/DEF-9x.html" ;
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;
                    doc.LoadHtml(data);

                    string xpathDivSelector = "//table";
                    var tagTBody = doc.DocumentNode.SelectSingleNode(xpathDivSelector);
                    if (tagTBody == null)
                    {
                        throw new Exception("Не обнаружен тег table");
                    }
                    if (tagTBody.ChildNodes.Count == 0)
                    {
                        throw new Exception("Пустой тег table");
                    }
                    if (tagTBody.ChildNodes[1].ChildNodes.Count >= 0)
                    {
                        string err = tagTBody.ChildNodes[0].ChildNodes[3].InnerText;
                    }
                }
            }
            catch (Exception  ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
