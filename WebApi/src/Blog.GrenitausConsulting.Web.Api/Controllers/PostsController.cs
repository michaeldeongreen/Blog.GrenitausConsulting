using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog.GrenitausConsulting.Domain;
using Blog.GrenitausConsulting.Services.Interfaces;
using Blog.GrenitausConsulting.Web.Api.App_Start;
using Blog.GrenitausConsulting.Common.Interfaces;
using System.Net.Http.Headers;

namespace Blog.GrenitausConsulting.Web.Api.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPagingService _pagingService;
        private readonly IConfigurationManagerWrapper _configurationManagerWrapper;
        private readonly int _pageSize;

        public PostsController(IPagingService pagingService,
            IConfigurationManagerWrapper configurationManagerWrapper
            )
        {
            _pagingService = pagingService;
            _configurationManagerWrapper = configurationManagerWrapper;
            _pageSize = _configurationManagerWrapper.Convert("PageSize").ToAInt();
        }

        [Route("api/posts/page/{pageNumber}") ]
        public PagedResponse Get(int pageNumber)
        {
            return _pagingService.Get(new PagedCriteria() { PageNumber = pageNumber, PageSize = _pageSize, Posts = Build()});
        }

       /* public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<a href='http://blog.grenitausconsulting.com/wp-content/uploads/2017/02/Blogs-By-Grenitaus.png'><img src='http://blog.grenitausconsulting.com/wp-content/uploads/2017/02/Blogs-By-Grenitaus.png' alt='' width='600' height='400' /></a>Check out my latest blog I wrote for my client <a href='http://architectinginnovation.com' target='_blank'> Architecting Innovation </a> about some of the odd behavior I encountered while working with The Azure Portal, Azure Storage and Visual Studio.  In this blog, I talk about working on the Contoso Ads Demo Application and I outline some of the issues that I faced with Azure..  You can find the blog <a href='http://blog.architectinginnovation.com/navigating-odd-behaviors-azure/' target = '_blank'> here </a>.");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }*/

        public string Get()
        {
            return "<a href = 'http://blog.grenitausconsulting.com/wp-content/uploads/2017/02/Blogs-By-Grenitaus.png' ><img src = 'http://blog.grenitausconsulting.com/wp-content/uploads/2017/02/Blogs-By-Grenitaus.png' alt = '' width = '600' height = '400'/></a> Check out my latest blog I wrote for my client <a href = 'http://architectinginnovation.com' target = '_blank' > Architecting Innovation </a> about some of the odd behavior I encountered while working with The Azure Portal, Azure Storage and Visual Studio.  In this blog, I talk about working on the Contoso Ads Demo Application and I outline some of the issues that I faced with Azure..  You can find the blog <a href = 'http://blog.architectinginnovation.com/navigating-odd-behaviors-azure/' target = '_blank' > here </a>.";
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
                    Snippet = "<a href=http://blog.grenitausconsulting.com/wp-content/uploads/2017/02/Blogs-By-Grenitaus.png><img src=http://blog.grenitausconsulting.com/wp-content/uploads/2017/02/Blogs-By-Grenitaus.png alt='' width=600 height=400 /></a>Check out my latest blog I wrote for my client < a href = http://architectinginnovation.com target = _blank > Architecting Innovation </ a > about some of the odd behavior I encountered while working with The Azure Portal, Azure Storage and Visual Studio.  In this blog, I talk about working on the Contoso Ads Demo Application and I outline some of the issues that I faced with Azure..  You can find the blog < a href = http://blog.architectinginnovation.com/navigating-odd-behaviors-azure/ target = _blank > here </ a >.",
                    Title = "Odd Azure Storage, Azure Portal and Visual Studio 2015 Behavior",
                    Link = "odd-azure-storage-azure-portal-and-visual-studio-2015-behavior"
                });
            }

            return posts;
        }
    }
}
