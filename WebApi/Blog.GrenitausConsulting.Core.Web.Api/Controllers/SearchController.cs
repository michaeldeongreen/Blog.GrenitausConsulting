using Microsoft.AspNetCore.Mvc;
using Blog.GrenitausConsulting.Core.Services.Interfaces;
using Blog.GrenitausConsulting.Core.Common.Interfaces;
using Blog.GrenitausConsulting.Core.Domain;
using Blog.GrenitausConsulting.Core.Common;

namespace Blog.GrenitausConsulting.Core.Web.Api.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPagingService _pagingService;
        private readonly IConfigurationManagerWrapper _configurationManagerWrapper;
        private readonly int _pageSize;

        public SearchController(IPagingService pagingService,
            IConfigurationManagerWrapper configurationManagerWrapper)
        {
            _pagingService = pagingService;
            _configurationManagerWrapper = configurationManagerWrapper;
            _pageSize = _configurationManagerWrapper.AppSettings.Value.PageSize;
        }

        [Route("api/search/{criteria}/page/{pagenumber}")]
        public PagedResponse Get(string criteria, int pageNumber)
        {
            return _pagingService.Search(new PagedCriteria() { PageNumber = pageNumber, PageSize = _pageSize, Posts = BlogContextManager.PostSummaries, SearchCriteria = criteria, IsActive = true });
        }
    }
}