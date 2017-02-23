using Blog.GrenitausConsulting.Domain;
using Blog.GrenitausConsulting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog.GrenitausConsulting.Web.Api.Controllers
{
    public class SearchController : ApiController
    {
        private readonly IPagingService _pagingService;

        public SearchController(IPagingService pagingService)
        {
            _pagingService = pagingService;
        }

        [Route("api/search/{criteria}/page/{pageNumber}")]
        public PagedResponse Get(string criteria, int pageNumber)
        {
            return _pagingService.Search(new PagedCriteria() { PageNumber = pageNumber, PageSize = 10, Posts = Build(), SearchCriteria = criteria });
        }

        private IEnumerable<Post> Build()
        {
            var posts = new List<Post>();
            for (int i = 1; i <= 100; i++)
            {
                posts.Add(new Post()
                {
                    Id = i,
                    Author = "Michael D. Green",
                    PostDate = DateTime.Now.AddDays(-i),
                    Snippet = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolore, veritatis, tempora, necessitatibus inventore nisi quam quia repellat ut tempore laborum possimus eum dicta id animi corrupti debitis ipsum officiis rerum.",
                    Title = string.Format("My Great Blog# {0}", i)
                });
            }

            return posts;
        }
    }
}
