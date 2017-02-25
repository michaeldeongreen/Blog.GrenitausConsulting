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
        private IEnumerable<Post> _postSummaries;

        public IEnumerable<Post> PostSummaries { get { return _postSummaries; }  }

        public async Task Init(string path)
        {
            _path = path;
            await BuildPostSummaries();
        }

        private async Task BuildPostSummaries()
        {
            _postSummaries = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Post>>(File.ReadAllText(_path)));
        }
    }
}
