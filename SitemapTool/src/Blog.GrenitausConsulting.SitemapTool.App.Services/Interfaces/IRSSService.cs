﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.SitemapTool.App.Services.Interfaces
{
    public interface IRSSService
    {
        void Generate(string domain, string rssOutputPath);
    }
}