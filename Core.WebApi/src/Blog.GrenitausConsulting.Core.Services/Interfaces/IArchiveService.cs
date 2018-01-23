using Blog.GrenitausConsulting.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Core.Services.Interfaces
{
    public interface IArchiveService
    {
        IList<Archive> Get(IEnumerable<PostSummary> posts);
    }
}
