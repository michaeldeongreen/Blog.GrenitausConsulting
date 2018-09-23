using Blog.GrenitausConsulting.CLI.Core.Common;
using Blog.GrenitausConsulting.CLI.Core.Domain;
using Blog.GrenitausConsulting.CLI.Core.Services;
using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Blog.GrenitausConsulting.CLI.Core.Unit.Tests
{
    [TestFixture]
    public class CommandLineArgumentParseServiceTests
    {
        [Test]
        public void Parse_When_No_Config_Argment_ReturnsNull_Test()
        {
            //given
            string[] args = new string[] {"-outputdir", "c:\\output" };
            ICommandLineArgumentParseService service = new CommandLineArgumentParseService();
            //when
            CommandLineArgument argument = service.Parse(args, CommandLineArgumentType.ConfigDir);
            //then
            argument.Should().BeNull();
        }

        [Test]
        public void Parse_When_Config_Argment_But_Value_Outside_Of_ArgumentArrayRange_ReturnsNull_Test()
        {
            //given
            string[] args = new string[] { "-configdir" };
            ICommandLineArgumentParseService service = new CommandLineArgumentParseService();
            //when
            CommandLineArgument argument = service.Parse(args, CommandLineArgumentType.ConfigDir);
            //then
            argument.Should().BeNull();
        }

        [Test]
        public void Parse_When_Config_Argment_And_Value_ReturnsCommandLineArgument_Test()
        {
            //given
            string[] args = new string[] { "-configdir", "c:\\configdirectory" };
            ICommandLineArgumentParseService service = new CommandLineArgumentParseService();
            //when
            CommandLineArgument argument = service.Parse(args, CommandLineArgumentType.ConfigDir);
            //then
            argument.Should().NotBeNull();
        }

        [Test]
        public void Parse_When_Config_Argment_And_Value_ReturnsCorrectCommandLineArgumentValue_Test()
        {
            //given
            string[] args = new string[] { "-configdir", "c:\\configdirectory" };
            ICommandLineArgumentParseService service = new CommandLineArgumentParseService();
            //when
            CommandLineArgument argument = service.Parse(args, CommandLineArgumentType.ConfigDir);
            //then
            argument.Value.Should().Be(args[1]);
        }
    }
}
