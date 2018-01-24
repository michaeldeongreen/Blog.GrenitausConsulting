using Blog.GrenitausConsulting.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Core.Unit.Tests
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
