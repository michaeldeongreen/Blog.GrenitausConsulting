using NUnit.Framework;
using FluentAssertions;
using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using Blog.GrenitausConsulting.CLI.Core.Services;

namespace Blog.GrenitausConsulting.CLI.Core.Unit.Tests
{
    [TestFixture]
    public class ArgumentValidationServiceTests
    {
        [Test]
        public void IsValid_When_Argument_Is_Help_Then_ReturnsTrue_Test()
        {
            //given
            IArgumentValidationService service = new ArgumentValidationService();
            string[] args = new string[] { "-help" };
            //when
            bool result = service.IsValid(args);
            //then
            result.Should().BeTrue();
        }
    }
}
