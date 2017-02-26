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
        public static IEnumerable<PostSummary> PostSummaries { get { return _blogContext.PostSummaries; } }
        public static IList<PostHtml> PostHtmlList { get { return _blogContext.PostHtmlList; } }
        public static IEnumerable<Category> Categories { get {return _blogContext.Categories; } }
        public static IEnumerable<Tag> Tags { get { return _blogContext.Tags; }  }



        public static async Task Init(string path)
        {
            await _blogContext.Init(path);
        }

    }
}
