using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Domain
{
    public class PagedCriteria
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<PostSummary> Posts { get; set; }
        public string SearchCriteria { get; set; }
    }
}
