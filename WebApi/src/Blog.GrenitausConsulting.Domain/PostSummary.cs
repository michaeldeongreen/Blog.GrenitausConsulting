﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Domain
{
    public class PostSummary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
        public string Snippet { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
