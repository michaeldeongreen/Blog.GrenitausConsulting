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

        public IEnumerable<PostSummary> PostSummaries { get { return _postSummaries; }  }
        public IList<PostHtml> PostHtmlList { get { return _postHtmlList; } }
        public IEnumerable<Category> Categories { get { return _categories; } }

        public async Task Init(string path)
        {
            _path = path;
            await BuildPostSummaries();
            await BuildPostHtml();
            await BuildCategories();
        }

        private async Task BuildPostSummaries()
        {
            _postSummaries = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<PostSummary>>(File.ReadAllText(string.Format(@"{0}\post-summaries.json", _path))));
        }

        private async Task BuildPostHtml()
        {
            var blogs = Directory.GetFiles(_path, "*.txt");
            foreach (var blog in blogs)
            {
                using (var reader = File.OpenText(blog))
                {
                    string contents = await reader.ReadToEndAsync();
                    var post = _postSummaries.Where(p => p.Link == Path.GetFileNameWithoutExtension(blog)).FirstOrDefault();
                    _postHtmlList.Add(new PostHtml() { Hmtl = contents, Link = post.Link });
                }
            }
        }

        private async Task BuildCategories()
        {
            _categories = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Category>>(File.ReadAllText(string.Format(@"{0}\categories.json", _path))));
        }
    }
}
