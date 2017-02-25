using Blog.GrenitausConsulting.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Blog.GrenitausConsulting.Domain;
using System.IO;

namespace Blog.GrenitausConsulting.Common
{
    public sealed class BlogContext
    {
        private string _path = string.Empty;
        private IEnumerable<PostSummary> _postSummaries;
        private IList<PostHtml> _postHtmlList = new List<PostHtml>();

        public IEnumerable<PostSummary> PostSummaries { get { return _postSummaries; }  }
        public IList<PostHtml> PostHtmlList { get { return _postHtmlList; } }

        public async Task Init(string path)
        {
            _path = path;
            await BuildPostSummaries();
            await BuildPostHtml();
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
    }
}
