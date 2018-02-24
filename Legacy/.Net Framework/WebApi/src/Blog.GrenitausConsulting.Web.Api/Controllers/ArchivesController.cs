using Blog.GrenitausConsulting.Common;
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
    public class ArchivesController : ApiController
    {
        private readonly IArchiveService _archiveService;
        public ArchivesController(IArchiveService archiveService)
        {
            _archiveService = archiveService;
        }

        public IList<Archive> Get()
        {
            return _archiveService.Get(BlogContextManager.PostSummaries);
        }
    }
}
