using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Core.Domain
{
    public class PagedCriteria
    {
        public PagedCriteria()
        {
            IsActive = true;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<PostSummary> Posts { get; set; }
        public string SearchCriteria { get; set; }
        public bool IsActive  { get; set; }
        public int MonthCriteria { get; set; }
        public int YearCriteria { get; set; }
        public int SearchCriteriaInt { get; set; }
    }
}
