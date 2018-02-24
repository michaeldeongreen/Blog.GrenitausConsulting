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
        private static IConfigurationManagerWrapper _configurationManagerWrapper = new ConfigurationManagerWrapper(ConfigurationManager.AppSettings, ConfigurationManager.ConnectionStrings);

        public static void Start()
        {
            if (_configurationManagerWrapper.AppSetting("BlogMonitorEnabled").ToABool())
            {
                int monitorInterval = _configurationManagerWrapper.AppSetting("BlogMonitorInterval").ToAInt();
                _blogMonitor.Start(monitorInterval, HandleBlogMonitorElapsedEvent);
            }
        }

        public static void HandleBlogMonitorElapsedEvent(Object source, ElapsedEventArgs e)
        {
            string url = _configurationManagerWrapper.AppSetting("BlogMonitorApiUrl").ToAString();
            var client = new WebClient();
            var content = client.DownloadString(url);
        }
    }
}
