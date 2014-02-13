using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.IO;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        public static Trie trie;


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getResults(string userInput)
        {
            trie = new Trie();

            using (StreamReader sr = new StreamReader(Server.MapPath("querysearches.txt")))
            {
                while (sr.EndOfStream == false)
                {
                    string eachLine = sr.ReadLine();

                    try
                    {
                        trie.insert(eachLine);
                    }
                    catch (OutOfMemoryException)
                    {
                        break;
                    }
                }
            }

        }
    }
}
