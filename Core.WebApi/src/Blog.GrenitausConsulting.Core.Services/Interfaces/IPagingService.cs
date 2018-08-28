using Blog.GrenitausConsulting.Core.Domain;

namespace Blog.GrenitausConsulting.Core.Services.Interfaces
{
    public interface IPagingService
    {
        PagedResponse Get(PagedCriteria criteria);

        PagedResponse Search(PagedCriteria criteria);

        PagedResponse GetByCategory(PagedCriteria criteria);

        PagedResponse GetByTag(PagedCriteria criteria);

        PagedResponse GetByMonthAndYear(PagedCriteria criteria);

        PagedResponse GetAlsoOn(PagedCriteria criteria);

        PagedResponse GetPreviews();
    }
}
