using Blog.GrenitausConsulting.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Blog.GrenitausConsulting.Domain;
using System.IO;
using System.Web;

namespace Blog.GrenitausConsulting.Common
{
    public sealed class BlogContext
    {
        private string _path = string.Empty;
        private IEnumerable<PostSummary> _postSummaries;
        private IList<PostHtml> _postHtmlList = new List<PostHtml>();
        private IEnumerable<Category> _categories;
        private IEnumerable<Tag> _tags;

        public IEnumerable<PostSummary> PostSummaries { get { return _postSummaries; }  }
        public IList<PostHtml> PostHtmlList { get { return _postHtmlList; } }
        public IEnumerable<Category> Categories { get { return _categories; } }
        public IEnumerable<Tag> Tags { get { return _tags; } }

        public async Task Init(string path)
        {
            _path = path;
           _postSummaries = await BuildPostSummaries();
           _postHtmlList = await BuildPostHtml();
            _categories = await BuildCategories();
            _tags = await BuildTags();
        }

        private async Task<IEnumerable<PostSummary>> BuildPostSummaries()
        {
            var summaries = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<PostSummary>>(File.ReadAllText(string.Format(@"{0}\post-summaries.json", _path))));

            return summaries;
        }

        private async Task<IList<PostHtml>> BuildPostHtml()
        {
            var blogs = Directory.GetFiles(_path, "*.txt");
            var htmlList = new List<PostHtml>();
            foreach (var blog in blogs)
            {
                using (var reader = File.OpenText(blog))
                {
                    string contents = await reader.ReadToEndAsync();
                    var post = _postSummaries.Where(p => p.Link == Path.GetFileNameWithoutExtension(blog)).FirstOrDefault();
                    htmlList.Add(new PostHtml() { Hmtl = contents, Link = post.Link });
                }
            }
            return htmlList;
        }

        private async Task<IEnumerable<Category>> BuildCategories()
        {
            var categories = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Category>>(File.ReadAllText(string.Format(@"{0}\categories.json", _path))));

            return categories;
        }

        private async Task<IEnumerable<Tag>> BuildTags()
        {
            var tags = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Tag>>(File.ReadAllText(string.Format(@"{0}\tags.json", _path))));

            return tags;
        }
    }
}
