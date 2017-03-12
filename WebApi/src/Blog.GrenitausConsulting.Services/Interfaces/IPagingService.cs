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
        PagedResponse Get(PagedCriteria criteria);

        PagedResponse Search(PagedCriteria criteria);

        PagedResponse GetByCategory(PagedCriteria criteria);

        PagedResponse GetByTag(PagedCriteria criteria);

        PagedResponse GetByMonthAndYear(PagedCriteria criteria);

        PagedResponse GetAlsoOn(PagedCriteria criteria);
    }
}
