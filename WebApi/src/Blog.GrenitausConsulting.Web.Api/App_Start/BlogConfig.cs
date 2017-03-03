using Blog.GrenitausConsulting.Common;
using Blog.GrenitausConsulting.Common.Interfaces;
using Blog.GrenitausConsulting.Web.Api.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.GrenitausConsulting.Web.Api
{
    public class BlogConfig
    {
        public static void Configure(string path)
        {
            BlogContextManager.Init(path);
            BlogMonitorManager.Start();
        }
    }
}