using Blog.GrenitausConsulting.Common;
using Blog.GrenitausConsulting.SitemapTool.App.Domain;
using Blog.GrenitausConsulting.SitemapTool.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.SitemapTool.App.Services
{
    public class SitemapService : ISitemapService
    {
        private string _configurationPath;
        private string _sitemapOutputPath;
        private string _domain;

        public void Generate(string domian, string configurationPath, string sitemapOutputPath)
        {
            _domain = domian;
            _configurationPath = configurationPath;
            _sitemapOutputPath = sitemapOutputPath;
            BlogContextManager.Init(configurationPath);
            GeneratePostSitemap();
        }

        private void GeneratePostSitemap()
        {
            Sitemap map = new Sitemap();
            string outputPath = string.Format(@"{0}\post-sitemap.xml", _sitemapOutputPath);
            foreach (var post in BlogContextManager.PostSummaries)
            {
                SitemapLocation location = new SitemapLocation() { ChangeFrequency = SitemapLocation.eChangeFrequency.daily, Url = string.Format("{0}/post/{1}",_domain, post.Link),
                 LastModified = DateTime.Now};
                if (post.Images != null)
                {
                    foreach (var image in post.Images)
                    {
                        location.Images.Add(new SitemapImage() { Location = image.Url });
                    }
                }
                map.Add(location);
            }
            map.WriteSitemapToFile(outputPath);
        }
    }
}
