using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using System.IO;


namespace HtmlParser
{
    internal class Program
    {
        static void Main(string[] args)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\paco\Desktop\Project\XMLParsing\XMLParsing\sitemapbrowse.ashx");
            XDocument doc2 = XDocument.Load(@"C:\Users\paco\Desktop\Project\XMLParsing\XMLParsing\xd.ashx");

            XmlNodeList loc = doc.GetElementsByTagName("loc");
            XmlNodeList mod = doc.GetElementsByTagName("lastmod");
            XmlNodeList freq = doc.GetElementsByTagName("changefreq");
            XmlNodeList prior = doc.GetElementsByTagName("priority");

            string number = null;
            int modNumber = 0;
            List<List<string>> FileContent = new List<List<string>>();
            for (int i = 0; i < doc.DocumentElement.ChildNodes.Count; i++)
            {
                number += mod[i].InnerText[14];
                number+= mod[i].InnerText[15];
                modNumber = int.Parse(number);
                number = null;
                if (modNumber > 30)
                {
                    

                    XElement root = new XElement("url");

                    root.Add(new XElement("loc",loc[i].InnerText));
                    root.Add(new XElement("lastmod",mod[i].InnerText));
                    root.Add(new XElement("changefreq",freq[i].InnerText));
                    root.Add(new XElement("priority",prior[i].InnerText));
                    doc2.Element("urlset").Add(root);
                    doc2.Save(@"C:\Users\paco\Desktop\Project\XMLParsing\XMLParsing\xd.ashx");

                }
            }
        }
    }
}