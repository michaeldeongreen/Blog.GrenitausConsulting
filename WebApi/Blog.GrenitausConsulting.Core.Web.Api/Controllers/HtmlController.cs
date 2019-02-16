using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Blog.GrenitausConsulting.Core.Common;

namespace Blog.GrenitausConsulting.Core.Web.Api.Controllers
{
    public class HtmlController : Controller
    {
        [Route("api/html/{link}")]
        public string Get(string link)
        {
            var post = BlogContextManager.PostSummaries.Where(p => p.Link.ToLower().Trim() == link.ToLower().Trim() && p.IsActive).FirstOrDefault();
            if (post != null)
                return BlogContextManager.PostHtmlList.Where(p => p.Link.ToLower().Trim() == link.ToLower().Trim()).FirstOrDefault().Hmtl;
            else
                return string.Empty;
        }

        [Route("api/html/{link}/preview")]
        public string GetPreview(string link)
        {
            var post = BlogContextManager.PostSummaries.Where(p => p.Link == link && p.CanPreview && p.PreviewExpirationDate.Value.Date >= DateTime.Now.Date).FirstOrDefault();
            if (post != null)
                return BlogContextManager.PostHtmlList.Where(p => p.Link.ToLower().Trim() == link.ToLower().Trim()).FirstOrDefault().Hmtl;
            else
                return string.Empty;
        }
    }
}