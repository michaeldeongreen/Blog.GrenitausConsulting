using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.GrenitausConsulting.Core.Domain;
using Blog.GrenitausConsulting.Core.Common;

namespace Blog.GrenitausConsulting.Core.Web.Api.Controllers
{
    [Produces("application/json")]
    public class CategoryController : Controller
    {
        [Route("api/categories")]
        public IEnumerable<Category> Get()
        {
            return BlogContextManager.Categories.OrderBy(c => c.Name);
        }
    }
}