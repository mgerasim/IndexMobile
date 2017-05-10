using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace IndexMobileCore.Helper
{
    static public class Telephone
    {
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        static public string OperatorRequest()
        {
            string HtmlResult;
            try
            {
                string postUrlPrivate = "http://mnp.tele2.ru/gateway.php";
                string URI = postUrlPrivate;
                string myParameters = "private";

                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, myParameters);
                }

                if (HtmlResult != "")
                {
                    return HtmlResult;
                }
                else
                {
                    return "Не определен";
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return err;
            }
        }

        static public string Operator(int Code, int Number)
        {            
            try
            {
                string urlAddress = "http://indexmain.ru/mobile/ru/search?searchcode=" + Code.ToString("000") + "&searchnumber=" + Number.ToString("0000000") ;
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

                    string xpathDivSelector = "//tbody";
                    var tagTBody = doc.DocumentNode.SelectSingleNode(xpathDivSelector);
                    if (tagTBody == null)
                    {
                        throw new Exception("Не обнаружен тег tbody");
                    }
                    if (tagTBody.ChildNodes.Count != 1)
                    {
                        return "Пустой тег tbody";
                    }
                    if (tagTBody.ChildNodes[0].ChildNodes.Count >= 4)
                    {
                        return tagTBody.ChildNodes[0].ChildNodes[3].InnerText;
                    }

                }

                return "Не определен";

            }
            catch(Exception ex)
            {
                string err = ex.Message;
                return err;
            }         
        }
    }
}
