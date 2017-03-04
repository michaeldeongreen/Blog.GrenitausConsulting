using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.GrenitausConsulting.ArtifactGeneratorTool.App.Domain;
using Blog.GrenitausConsulting.Common;
using Blog.GrenitausConsulting.CLI.Services.Interfaces;

namespace Blog.GrenitausConsulting.CLI.Services
{
    public class CLIService : ICLIService
    {
        private EnvironmentSettings _settings;

        public CLIService(EnvironmentSettings settings)
        {
            _settings = settings;
        }
        public void Generate()
        {
            BlogContextManager.Init(_settings.JsonConfigDirectory);
            GenerateSitemaps();
            GenerateRSSFeed();
            GenerateStaticHtml();
        }

        private void GenerateSitemaps()
        {
            ISitemapService sitemapService = new SitemapService();
            sitemapService.Generate(_settings.Domain, _settings.JsonConfigDirectory, _settings.OutputDirectory);
        }

        private void GenerateRSSFeed()
        {
            IRSSService rssService = new RSSService();
            rssService.Generate(_settings.Domain, _settings.OutputDirectory);
        }

        private void GenerateStaticHtml()
        {
            IHtmlService htmlService = new HtmlService();
            htmlService.Generate(_settings.Domain, _settings.OutputDirectory, _settings.AngularCLISrcDirectory);
        }
    }
}
