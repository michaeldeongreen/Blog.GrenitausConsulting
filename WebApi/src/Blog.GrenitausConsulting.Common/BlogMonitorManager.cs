using Blog.GrenitausConsulting.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Blog.GrenitausConsulting.Common
{
    public sealed class BlogMonitorManager
    {
        private static readonly BlogMonitor _blogMonitor = new BlogMonitor();
        private static IConfigurationManagerWrapper _configurationManagerWrapper = new ConfigurationManagerWrapper(ConfigurationManager.AppSettings);

        public static void Start()
        {
            if (_configurationManagerWrapper.Convert("BlogMonitorEnabled").ToABool())
            {
                int monitorInterval = _configurationManagerWrapper.Convert("BlogMonitorInterval").ToAInt();
                _blogMonitor.Start(monitorInterval, HandleBlogMonitorElapsedEvent);
            }
        }

        public static void HandleBlogMonitorElapsedEvent(Object source, ElapsedEventArgs e)
        {
            string url = _configurationManagerWrapper.Convert("BlogMonitorApiUrl").ToAString();
            var client = new WebClient();
            var content = client.DownloadString(url);
        }
    }
}
