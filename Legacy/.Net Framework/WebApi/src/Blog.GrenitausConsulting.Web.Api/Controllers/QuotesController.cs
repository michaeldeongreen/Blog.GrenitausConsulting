using Blog.GrenitausConsulting.Common;
using Blog.GrenitausConsulting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blog.GrenitausConsulting.Web.Api.Controllers
{
    public class QuotesController : ApiController
    {
        [Route("api/quote")]
        public Quote Get()
        {
            return BlogContextManager.Quotes.OrderByDescending(q => q.AddedDate).Take(1).SingleOrDefault();
        }
    }
}
