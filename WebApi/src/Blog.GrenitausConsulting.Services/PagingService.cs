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
        public PagedResponse Get(int pageNumber, int pageSize, List<Post> posts)
        {
            return new PagedResponse() { Total = posts.Count, Posts = posts.Skip(pageNumber-1).Take(pageSize).OrderByDescending(p => p.PostDate) };
        }
    }
}
