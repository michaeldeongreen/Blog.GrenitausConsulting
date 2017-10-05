using Blog.GrenitausConsulting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Unit.Tests
{
    public static class Data
    {
        public static List<PostSummary> Get()
        {
            List<PostSummary> posts = new List<PostSummary>();
            for (int i = 1; i <= 100; i++)
            {
                posts.Add(new PostSummary() { Id = i, IsActive = true });
            }
            return posts;
        }
    }
}
