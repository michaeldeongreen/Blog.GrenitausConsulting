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
        public void CommandLineArgumentType_ToArgument_When_Config_Argument_ReturnsArgument()
        {
            const string arg = "-config";
            //given
            CommandLineArgumentType type = CommandLineArgumentType.Config;
            //when
            string value = type.ToArgument();
            //then
            value.Should().Be(arg);
        }

        [Test]
        public void CommandLineArgumentType_ToArgument_When_Output_Argument_ReturnsArgument()
        {
            const string arg = "-output";
            //given
            CommandLineArgumentType type = CommandLineArgumentType.Output;
            //when
            string value = type.ToArgument();
            //then
            value.Should().Be(arg);
        }

        [Test]
        public void CommandLineArgumentType_ToArgument_When_URL_Argument_ReturnsArgument()
        {
            const string arg = "-url";
            //given
            CommandLineArgumentType type = CommandLineArgumentType.Url;
            //when
            string value = type.ToArgument();
            //then
            value.Should().Be(arg);
        }
    }
}
