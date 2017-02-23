using Blog.GrenitausConsulting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Services.Interfaces
{
    public interface IPagingService
    {
        PagedResponse Get(int pageNumber, int pageSize, IEnumerable<Post> posts);
    }
}
