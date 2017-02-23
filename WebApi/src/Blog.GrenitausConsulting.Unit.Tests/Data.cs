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
        public static List<Post> Get()
        {
            List<Post> posts = new List<Post>();
            for (int i = 1; i <= 100; i++)
            {
                posts.Add(new Post() { Id = i });
            }
            return posts;
        }
    }
}
