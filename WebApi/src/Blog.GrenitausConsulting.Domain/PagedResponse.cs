using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Domain
{
    public class PagedResponse
    {
        public int Total { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
