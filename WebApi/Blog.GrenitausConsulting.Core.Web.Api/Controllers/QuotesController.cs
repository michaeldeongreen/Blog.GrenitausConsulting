using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Blog.GrenitausConsulting.Core.Domain;
using Blog.GrenitausConsulting.Core.Common;

namespace Blog.GrenitausConsulting.Core.Web.Api.Controllers
{
    public class QuotesController : Controller
    {
        [Route("api/quote")]
        public Quote Get()
        {
            return BlogContextManager.Quotes.OrderByDescending(q => q.AddedDate).Take(1).SingleOrDefault();
        }
    }
}