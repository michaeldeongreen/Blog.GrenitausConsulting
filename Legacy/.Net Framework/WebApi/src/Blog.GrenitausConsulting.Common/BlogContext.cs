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
        private IEnumerable<Quote> _quotes;

        public IEnumerable<PostSummary> PostSummaries { get { return _postSummaries; }  }
        public IList<PostHtml> PostHtmlList { get { return _postHtmlList; } }
        public IEnumerable<Category> Categories { get { return _categories; } }
        public IEnumerable<Tag> Tags { get { return _tags; } }
        public string JsonPath { get { return _path; } }
        public IEnumerable<Quote> Quotes{ get { return _quotes; } }

        public void Init(string path)
        {
            _path = path;
            BuildPostSummaries();
            BuildPostHtml();
            BuildCategories();
            BuildTags();
            BuildQuotes();
        }

        private void BuildPostSummaries()
        {
            _postSummaries = JsonConvert.DeserializeObject<IEnumerable<PostSummary>>(File.ReadAllText(string.Format(@"{0}\configuration\post-summaries.json", _path)));
        }

        private void BuildPostHtml()
        {
            var blogs = Directory.GetFiles(string.Format(@"{0}\html",_path), "*.html");

            foreach (var blog in blogs)
            {
                using (var reader = File.OpenText(blog))
                {
                    string contents = reader.ReadToEnd();
                    var post = _postSummaries.Where(p => p.Link == Path.GetFileNameWithoutExtension(blog)).FirstOrDefault();
                    _postHtmlList.Add(new PostHtml() { Hmtl = contents, Link = post.Link });
                }
            }
        }

        private void BuildCategories()
        {
            _categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(File.ReadAllText(string.Format(@"{0}\configuration\categories.json", _path)));
        }

        private void BuildTags()
        {
            _tags = JsonConvert.DeserializeObject<IEnumerable<Tag>>(File.ReadAllText(string.Format(@"{0}\configuration\tags.json", _path)));
        }

        private void BuildQuotes()
        {
            _quotes = JsonConvert.DeserializeObject<IEnumerable<Quote>>(File.ReadAllText(string.Format(@"{0}\configuration\quotes.json", _path)));
        }
    }
}
