using Blog.GrenitausConsulting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.GrenitausConsulting.Domain;

namespace Blog.GrenitausConsulting.Services
{
    public class PagingService : IPagingService
    {
        public PagedResponse Get(int pageNumber, int pageSize, IEnumerable<Post> posts)
        {
            if (pageNumber == 0)
                pageNumber = 1;

            int skip = (pageNumber - 1) * pageSize;

            return new PagedResponse() { Total = posts.Count(), Posts = posts.Skip(skip).Take(pageSize).OrderByDescending(p => p.PostDate) };
        }
    }
}
