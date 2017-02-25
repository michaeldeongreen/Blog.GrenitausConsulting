using Blog.GrenitausConsulting.Common.Interfaces;
using Blog.GrenitausConsulting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Common
{
    public sealed class BlogContextManager
    {
        private static readonly BlogContext _blogContext = new BlogContext();
        public static IEnumerable<Post> PostSummaries{ get { return _blogContext.PostSummaries; } }


        public static async Task Init(string path)
        {
            await _blogContext.Init(path);
        }

    }
}
