using Blog.GrenitausConsulting.CLI.Core.Common;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.CLI.Core.Unit.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void CommandLineArgumentType_ToArgument_When_ConfigDir_Argument_ReturnsArgument_Test()
        {
            const string arg = "-configdir";
            //given
            CommandLineArgumentType type = CommandLineArgumentType.ConfigDir;
            //when
            string value = type.ToArgument();
            //then
            value.Should().Be(arg);
        }

        [Test]
        public void CommandLineArgumentType_ToArgument_When_OutputDir_Argument_ReturnsArgument_Test()
        {
            const string arg = "-outputdir";
            //given
            CommandLineArgumentType type = CommandLineArgumentType.OutputDir;
            //when
            string value = type.ToArgument();
            //then
            value.Should().Be(arg);
        }

        [Test]
        public void CommandLineArgumentType_ToArgument_When_BlogUrl_Argument_ReturnsArgument_Test()
        {
            const string arg = "-blogurl";
            //given
            CommandLineArgumentType type = CommandLineArgumentType.BlogUrl;
            //when
            string value = type.ToArgument();
            //then
            value.Should().Be(arg);
        }
    }
}
