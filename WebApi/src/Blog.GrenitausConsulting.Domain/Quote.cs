using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string quote { get; set; }
        public DateTime AddedDate { get; set; }
        public string Url { get; set; }
    }
}
