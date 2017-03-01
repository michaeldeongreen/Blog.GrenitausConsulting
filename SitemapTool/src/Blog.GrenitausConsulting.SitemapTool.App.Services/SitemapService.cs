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

            GenerateCategorySitemap();
            GeneratePageSitemap();
            GenerateTagSitemap();
            GeneratePostSitemap();
            GenerateSitemap(); 
        }

        private void GenerateCategorySitemap()
        {
            Sitemap map = new Sitemap();
            string outputPath = string.Format(@"{0}\category-sitemap.xml", _sitemapOutputPath);
            foreach (var category in BlogContextManager.Categories)
            {
                SitemapLocation location = new SitemapLocation()
                {
                    Url = string.Format("{0}/category/{1}", _domain, category.Name.Replace(" ", "%20")),
                    LastModified = DateTime.Now
                };
                map.Add(location);
            }
            map.WriteSitemapToFile(outputPath);
        }

        private void GeneratePageSitemap()
        {
            Sitemap map = new Sitemap();
            string outputPath = string.Format(@"{0}\page-sitemap.xml", _sitemapOutputPath);

            SitemapLocation l1 = new SitemapLocation()
            {
                Url = _domain,
                LastModified = DateTime.Now
            };
            SitemapLocation l2 = new SitemapLocation()
            {
                Url = string.Format("{0}/about", _domain),
                LastModified = DateTime.Now,
                Images = new List<SitemapImage>() { new SitemapImage() { Location = string.Format("{0}/assets/images/me.jpg", _domain) } }
            };

            map.Add(l1);
            map.Add(l2);

            map.WriteSitemapToFile(outputPath);
        }

        private void GenerateTagSitemap()
        {
            Sitemap map = new Sitemap();
            string outputPath = string.Format(@"{0}\post_tag-sitemap.xml", _sitemapOutputPath);
            foreach (var tag in BlogContextManager.Tags)
            {
                SitemapLocation location = new SitemapLocation()
                {
                    Url = string.Format("{0}/tag/{1}", _domain, tag.Name.Replace(" ", "%20")),
                    LastModified = DateTime.Now
                };
                map.Add(location);
            }
            map.WriteSitemapToFile(outputPath);
        }

        private void GeneratePostSitemap()
        {
            Sitemap map = new Sitemap();
            string outputPath = string.Format(@"{0}\post-sitemap.xml", _sitemapOutputPath);
            foreach (var post in BlogContextManager.PostSummaries.Where(p => p.IsActive == true))
            {
                SitemapLocation location = new SitemapLocation() { Url = string.Format("{0}/post/{1}",_domain, post.Link),
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

        private void GenerateSitemap()
        {
            SitemapIndex map = new SitemapIndex();
            string[] urls = new string[] {
                string.Format("{0}/category-sitemap.xml", _domain),
                string.Format("{0}/page-sitemap.xml", _domain),
                string.Format("{0}/post_tag-sitemap.xml", _domain),
                string.Format("{0}/post-sitemap.xml", _domain)
            };

            string outputPath = string.Format(@"{0}\sitemap.xml", _sitemapOutputPath);
            foreach (var url in urls)
            {
                SitemapLocation location = new SitemapLocation()
                {
                    Url = url,
                    LastModified = DateTime.Now
                };
                map.Add(location);
            }
            map.WriteSitemapToFile(outputPath);
        }
    }
}
