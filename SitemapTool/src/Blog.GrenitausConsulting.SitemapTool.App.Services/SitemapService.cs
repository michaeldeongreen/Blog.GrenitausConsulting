using Blog.GrenitausConsulting.Common;
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

        public void Generate(string configurationPath, string sitemapOutputPath)
        {
            _configurationPath = configurationPath;
            _sitemapOutputPath = sitemapOutputPath;
            BlogContextManager.Init(configurationPath);
        }

        private void 
    }
}
