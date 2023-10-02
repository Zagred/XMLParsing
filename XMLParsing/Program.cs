using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;


namespace HtmlParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xml = @"C:\Users\paco\Desktop\Project\XMLParsing\XMLParsing\sitemapbrowse.ashx";

            HtmlWeb web = new HtmlWeb();

            var doc = web.Load(xml);
            var link = doc.DocumentNode.SelectNodes(@"/urlset/url");

            var result = new HtmlDocument();
            if (link != null)
            {
                foreach (var node in link)
                {
                    var lastmodNode = node.SelectSingleNode("./lastmod");
                    DateTime dt = DateTime.Parse(lastmodNode.InnerText);
                    if (dt > DateTime.Now.AddDays(-30))
                    {
                        result.DocumentNode.AppendChild(node);
                    }
                }
                result.Save("result.xml");
            }
        }
    }
}