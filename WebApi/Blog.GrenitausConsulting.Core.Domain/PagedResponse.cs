using System.Collections.Generic;

namespace Blog.GrenitausConsulting.Core.Domain
{
    public class PagedResponse
    {
        public int Total { get; set; }
        public IEnumerable<PostSummary> Posts { get; set; }
        public string ArchiveMonth { get; set; }
        public int ArchiveYear { get; set; }
    }
}
