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


namespace HtmlParser
{
    internal class Program
    {
        static void Main(string[] args)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\paco\Desktop\Project\XMLParsing\XMLParsing\sitemapbrowse.ashx");

            XmlNodeList loc = doc.GetElementsByTagName("loc");
            XmlNodeList mod = doc.GetElementsByTagName("lastmod");
            XmlNodeList freq = doc.GetElementsByTagName("changefreq");
            XmlNodeList prior = doc.GetElementsByTagName("priority");

            string number = null;
            int counter = 0;
            int modNumber = 0;
            List<List<string>> FileContent = new List<List<string>>();
            for (int i = 0; i < doc.DocumentElement.ChildNodes.Count; i++)
            {
                number += mod[i].InnerText[14];
                number+= mod[i].InnerText[15];
                modNumber = int.Parse(number);
                /*for (int j = 0; j < mod[i].InnerText.Length; j++)
                {

                     switch (mod[i].InnerText[j])
                    {
                        case ':':
                            counter += 1;
                            break;
                        default:
                            if (counter == 1)
                            {
                                number += mod[i].InnerText[j];
                            }
                            else if (counter > 1)
                            {
                                modNumber = int.Parse(number);
                            }
                            break;
                    }
                }*/
                number = null;
                counter = 0;
                if (modNumber > 30)
                {
                    FileContent.Add(new List<string> { loc[i].InnerText, mod[i].InnerText, freq[i].InnerText, prior[i].InnerText });

                }
            }
            /*XmlDocument doc2 = new XmlDocument();
            doc2.Load(@"C:\Users\paco\Desktop\Project\XMLParsing\XMLParsing\xd.ashx");
            XElement root = new XElement("url");
            root.Add(new XAttribute("loc", loc[i].InnerText));
            root.Add(new XAttribute("lastmod", mod[i].InnerText));
            root.Add(new XAttribute("changefreq", freq[i].InnerText));
            root.Add(new XAttribute("priority", prior[i].InnerText));
            doc2.Save(@"C:\Users\ppandev\Desktop\XMLParser-master\xd.ashx");*/
            foreach (List<string> line in FileContent)
            {
                foreach (string token in line)
                {
                    Console.Write($"{token}|");
                }
                Console.WriteLine();
            }

            
        }
    }
}