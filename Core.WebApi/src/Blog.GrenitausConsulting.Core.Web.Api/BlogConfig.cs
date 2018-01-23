using Blog.GrenitausConsulting.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Core.Web.Api
{
    public class BlogConfig
    {
        public static void Configure(string path)
        {
            BlogContextManager.Init(path);
        }
    }
}
