using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using Blog.GrenitausConsulting.Core.Common;
using System.Linq;
using System.Text;
using System.Xml;

namespace Blog.GrenitausConsulting.CLI.Core.Services
{
    public class RSSService : IRSSService
    {
        private string _domain;
        private string _rssOutputPath;

        public void Generate(string domain, string rssOutputPath)
        {
            _domain = domain;
            _rssOutputPath = rssOutputPath;
            GenerateRSS();
        }

        private void GenerateRSS()
        {
            using (XmlTextWriter writer = new XmlTextWriter(string.Format(@"{0}\rss.xml",_rssOutputPath), Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("rss");
                writer.WriteAttributeString("version", "2.0");
                writer.WriteAttributeString("xmlns:atom", "http://www.w3.org/2005/Atom");
                writer.WriteStartElement("channel");
                writer.WriteElementString("title", "Grenitaus Consulting Blogs");
                writer.WriteElementString("link", _domain);
                writer.WriteElementString("description", "Grenitaus Consulting Blog RSS Feed");
                writer.WriteElementString("copyright", "Copyright 2017 Grenitaus Consulting");

                foreach (var post in BlogContextManager.PostSummaries.Where(p => p.IsActive == true))
                {
                    writer.WriteStartElement("item");
                    writer.WriteElementString("title",post.Title);
                    writer.WriteElementString("description", post.Snippet);
                    writer.WriteElementString("link", string.Format("{0}/post/{1}",_domain, post.Link));
                    writer.WriteElementString("guid", string.Format("{0}/post/{1}", _domain, post.Link));
                    writer.WriteElementString("pubDate", post.PostDate.ToString("R"));
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
        }
    }
}
