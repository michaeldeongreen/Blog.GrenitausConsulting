using Blog.GrenitausConsulting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Services.Interfaces
{
    public interface IArchiveService
    {
        IList<Archive> Get(IEnumerable<PostSummary> posts);
    }
}
