using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.SitemapTool.App.Services.Interfaces
{
    public interface ISitemapService
    {
        void Generate(string configurationPath, string sitemapOutputPath);
    }
}
