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
        public void Parse_When_No_Config_Argment_ReturnsNull()
        {
            //given
            string[] args = new string[] {"-output", "c:\\output" };
            ICommandLineArgumentParseService service = new CommandLineArgumentParseService();
            //when
            CommandLineArgument argument = service.Parse(args, CommandLineArgumentType.Config);
            //then
            argument.Should().BeNull();
        }

        [Test]
        public void Parse_When_Config_Argment_But_Value_Outside_Of_ArgumentArrayRange_ReturnsNull()
        {
            //given
            string[] args = new string[] { "-config" };
            ICommandLineArgumentParseService service = new CommandLineArgumentParseService();
            //when
            CommandLineArgument argument = service.Parse(args, CommandLineArgumentType.Config);
            //then
            argument.Should().BeNull();
        }

        [Test]
        public void Parse_When_Config_Argment_And_Value_ReturnsCommandLineArgument()
        {
            //given
            string[] args = new string[] { "-config", "c:\\configdirectory" };
            ICommandLineArgumentParseService service = new CommandLineArgumentParseService();
            //when
            CommandLineArgument argument = service.Parse(args, CommandLineArgumentType.Config);
            //then
            argument.Should().NotBeNull();
        }

        [Test]
        public void Parse_When_Config_Argment_And_Value_ReturnsCorrectCommandLineArgumentValue()
        {
            //given
            string[] args = new string[] { "-config", "c:\\configdirectory" };
            ICommandLineArgumentParseService service = new CommandLineArgumentParseService();
            //when
            CommandLineArgument argument = service.Parse(args, CommandLineArgumentType.Config);
            //then
            argument.Value.Should().Be(args[1]);
        }
    }
}
