using Blog.GrenitausConsulting.Core.Domain;
using Blog.GrenitausConsulting.Core.Services;
using Blog.GrenitausConsulting.Core.Services.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Blog.GrenitausConsulting.Core.Unit.Tests
{
    [TestFixture]
    public class PagingServiceUnitTests
    {
        [Test]
        public void Can_Get_Correct_Total_Test()
        {
            //given
            IPagingService service = new PagingService();
            //when
            PagedResponse response = service.Get(new PagedCriteria() { PageNumber = 1, PageSize = 10, Posts = Data.Get() });
            //then
            response.Total.Should().Be(100);
        }

        [Test]
        public void Can_Get_Correct_Items_Test()
        {
            //given
            IPagingService service = new PagingService();
            //when
            PagedResponse response = service.Get(new PagedCriteria() { PageNumber = 1, PageSize = 25, Posts = Data.Get() });
            //then
            response.Posts.Count().Should().Be(25);
        }
    }
}
