﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Blog.GrenitausConsulting.Core.Services.Interfaces;
using Blog.GrenitausConsulting.Core.Common.Interfaces;
using Blog.GrenitausConsulting.Core.Domain;
using Blog.GrenitausConsulting.Core.Common;

namespace Blog.GrenitausConsulting.Core.Web.Api.Controllers
{
    public class PostsController : Controller
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
            _pageSize = _configurationManagerWrapper.AppSettings.Value.PageSize;
        }

        [Route("api/posts/page/{pageNumber}")]
        public PagedResponse Get(int pageNumber)
        {
            return _pagingService.Get(new PagedCriteria() { PageNumber = pageNumber, PageSize = _pageSize, Posts = BlogContextManager.PostSummaries });
        }

        [Route("api/post/{link}")]
        public PostSummary GetByLink(string link)
        {
            return BlogContextManager.PostSummaries.Where(p => p.Link.ToLower().Trim() == link.ToLower().Trim() && p.IsActive).FirstOrDefault();
        }

        [Route("api/posts/category/{category}/page/{pageNumber}")]
        public PagedResponse GetByCategory(int pageNumber, string category)
        {
            return _pagingService.GetByCategory(new PagedCriteria() { PageNumber = pageNumber, PageSize = _pageSize, Posts = BlogContextManager.PostSummaries, SearchCriteria = category });
        }

        [Route("api/posts/tag/{tag}/page/{pageNumber}")]
        public PagedResponse GetByTag(int pageNumber, string tag)
        {
            return _pagingService.GetByTag(new PagedCriteria() { PageNumber = pageNumber, PageSize = _pageSize, Posts = BlogContextManager.PostSummaries, SearchCriteria = tag });
        }

        [Route("api/posts/month/{month}/year/{year}/page/{pageNumber}")]
        public PagedResponse GetByMonthAndYear(int pageNumber, int month, int year)
        {
            return _pagingService.GetByMonthAndYear(new PagedCriteria() { PageNumber = pageNumber, PageSize = _pageSize, Posts = BlogContextManager.PostSummaries, MonthCriteria = month, YearCriteria = year });
        }

        [Route("api/post/{link}/preview")]
        public PostSummary GetPreview(string link)
        {
            return BlogContextManager.PostSummaries.Where(p => p.Link == link && p.CanPreview && p.PreviewExpirationDate.Value.Date >= DateTime.Now.Date).FirstOrDefault();
        }

        [Route("api/post/{id}/alsoon")]
        public PagedResponse GetAlsoOn(int id)
        {
            return _pagingService.GetAlsoOn(new PagedCriteria() { Posts = BlogContextManager.PostSummaries, SearchCriteriaInt = id });
        }

        [Route("api/post/previews")]
        public PagedResponse GetPreviews()
        {
            return _pagingService.GetPreviews();
        }
    }
}