using Blog.GrenitausConsulting.Core.Common;

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
