using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Blog.GrenitausConsulting.Core.Domain;
using Blog.GrenitausConsulting.Core.Common;

namespace Blog.GrenitausConsulting.Core.Web.Api.Controllers
{
    public class CategoryController : Controller
    {
        [Route("api/categories")]
        public IEnumerable<Category> Get()
        {
            return BlogContextManager.Categories.OrderBy(c => c.Name);
        }
    }
}