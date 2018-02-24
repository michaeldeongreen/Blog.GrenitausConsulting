﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.GrenitausConsulting.ArtifactGeneratorTool.App.Domain;
using Blog.GrenitausConsulting.Common;
using Blog.GrenitausConsulting.CLI.Services.Interfaces;
using Blog.GrenitausConsulting.CLI.Common;

namespace Blog.GrenitausConsulting.CLI.Services
{
    public class CLIService : ICLIService
    {
        private EnvironmentSettings _settings;
        public event EventHandler<CLIProcessStatusChangedEventArgs> CLIProcessStatusChanged;

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
            AnnounceEvent("Process completed successfully....");
        }

        private void GenerateSitemaps()
        {
            AnnounceEvent("Sitemap generation has started....");
            ISitemapService sitemapService = new SitemapService();
            sitemapService.Generate(_settings.Domain, _settings.JsonConfigDirectory, _settings.OutputDirectory);
            AnnounceEvent("Sitemap generation has completed....");
        }

        private void GenerateRSSFeed()
        {
            AnnounceEvent("RSS Feed generation has started....");
            IRSSService rssService = new RSSService();
            rssService.Generate(_settings.Domain, _settings.OutputDirectory);
            AnnounceEvent("RSS Feed generation has completed....");
        }

        private void GenerateStaticHtml()
        {
            AnnounceEvent("Static HTML generation has started....");
            IHtmlService htmlService = new HtmlService();
            htmlService.Generate(_settings.Domain, _settings.OutputDirectory, _settings.AngularCLISrcDirectory);
            AnnounceEvent("Static HTML generation has completed....");
        }

        private void AnnounceEvent(string message)
        {
            OnCLIProcessStatusChanged(this, new CLIProcessStatusChangedEventArgs() { Message = message });
        }

        protected virtual void OnCLIProcessStatusChanged(object sender, CLIProcessStatusChangedEventArgs e)
        {
            EventHandler<CLIProcessStatusChangedEventArgs> handler = CLIProcessStatusChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
