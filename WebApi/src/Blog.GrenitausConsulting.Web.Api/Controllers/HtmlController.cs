using Blog.GrenitausConsulting.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog.GrenitausConsulting.Web.Api.Controllers
{
    public class HtmlController : ApiController
    {
        [Route("api/html/{link}")]
        public string Get(string link)
        {
            return BlogContextManager.PostHtmlList.Where(p => p.Link.ToLower().Trim() == link.ToLower().Trim()).FirstOrDefault().Hmtl;
        }

    }
}
