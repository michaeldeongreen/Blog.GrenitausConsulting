using Blog.GrenitausConsulting.Common;
using Blog.GrenitausConsulting.Common.Interfaces;
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
        private readonly IConfigurationManagerWrapper _configurationManagerWrapper;
        private readonly int _pageSize;

        public SearchController(IPagingService pagingService,
            IConfigurationManagerWrapper configurationManagerWrapper)
        {
            _pagingService = pagingService;
            _configurationManagerWrapper = configurationManagerWrapper;
            _pageSize = _configurationManagerWrapper.AppSetting("PageSize").ToAInt();
        }

        [Route("api/search/{criteria}/page/{pagenumber}")]
        public PagedResponse Get(string criteria, int pageNumber)
        {
            return _pagingService.Search(new PagedCriteria() { PageNumber = pageNumber, PageSize = _pageSize, Posts = BlogContextManager.PostSummaries, SearchCriteria = criteria, IsActive = true });
        }
    }
}
