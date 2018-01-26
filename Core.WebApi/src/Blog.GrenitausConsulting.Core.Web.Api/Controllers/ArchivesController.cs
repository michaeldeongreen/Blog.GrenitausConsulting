using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.GrenitausConsulting.Core.Services.Interfaces;
using Blog.GrenitausConsulting.Core.Domain;
using Blog.GrenitausConsulting.Core.Common;

namespace Blog.GrenitausConsulting.Core.Web.Api.Controllers
{
    public class ArchivesController : Controller
    {
        private readonly IArchiveService _archiveService;
        public ArchivesController(IArchiveService archiveService)
        {
            _archiveService = archiveService;
        }

        [Route("api/archives")]
        public IList<Archive> Get()
        {
            return _archiveService.Get(BlogContextManager.PostSummaries);
        }
    }
}