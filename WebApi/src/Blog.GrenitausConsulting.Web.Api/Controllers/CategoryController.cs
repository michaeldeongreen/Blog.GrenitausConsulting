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
    public class CategoryController : ApiController
    {
        [Route("api/categories")]
        public IEnumerable<Category> Get()
        {
            return BlogContextManager.Categories.OrderBy(c => c.Name);
        }
    }
}
