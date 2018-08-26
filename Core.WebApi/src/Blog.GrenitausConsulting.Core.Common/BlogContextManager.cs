using Blog.GrenitausConsulting.Core.Domain;
using System.Collections.Generic;

namespace Blog.GrenitausConsulting.Core.Common
{
    public sealed class BlogContextManager
    {
        private static readonly BlogContext _blogContext = new BlogContext();
        public static IEnumerable<PostSummary> PostSummaries { get { return _blogContext.PostSummaries; } }
        public static IList<PostHtml> PostHtmlList { get { return _blogContext.PostHtmlList; } }
        public static IEnumerable<Category> Categories { get {return _blogContext.Categories; } }
        public static IEnumerable<Tag> Tags { get { return _blogContext.Tags; }  }
        public static string JsonPath { get { return _blogContext.JsonPath; }  }
        public static IEnumerable<Quote> Quotes { get { return _blogContext.Quotes; } }

        public static void Init(string path)
        {
            _blogContext.Init(path);
        }
    }
}
