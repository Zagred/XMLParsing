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
            string xmlUrl = @"https://usdirectory.com/sitemapbrowse.ashx";
            var resuleSavePath = "result.xml";

            string sitemap = new WebClient().DownloadString(xmlUrl);
            var doc=new HtmlDocument();
            doc.LoadHtml(sitemap);
            var link = doc.DocumentNode.SelectNodes(@"/urlset/url");

            DateTime dt;
            var result = new HtmlDocument();
            
            if (link != null)
            {
                foreach (var node in link)
                {
                    var lastmodNode = node.SelectSingleNode("./lastmod");
                    dt = DateTime.Parse(lastmodNode.InnerText);
                    if (dt > DateTime.Now.AddDays(-30))
                    {
                        result.DocumentNode.AppendChild(node);
                    }
                }
                result.Save(resuleSavePath);
            }
        }
    }
}