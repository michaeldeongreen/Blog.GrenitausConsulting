using Blog.GrenitausConsulting.Core.Domain;
using System.Collections.Generic;

namespace Blog.GrenitausConsulting.Core.Services.Interfaces
{
    public interface IArchiveService
    {
        IList<Archive> Get(IEnumerable<PostSummary> posts);
    }
}
