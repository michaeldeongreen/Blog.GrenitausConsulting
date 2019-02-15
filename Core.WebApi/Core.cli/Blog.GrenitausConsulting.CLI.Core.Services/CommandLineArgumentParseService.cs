using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using System;
using Blog.GrenitausConsulting.CLI.Core.Common;
using Blog.GrenitausConsulting.CLI.Core.Domain;

namespace Blog.GrenitausConsulting.CLI.Core.Services
{
    public class CommandLineArgumentParseService : ICommandLineArgumentParseService
    {
        public CommandLineArgument Parse(string[] args, CommandLineArgumentType type)
        {
            string arg = type.ToArgument();
            int index = Array.IndexOf(args, arg);

            if (index == -1)
                return null;

            if (index + 1 > args.Length - 1)
                return null;

            return new CommandLineArgument(type, args[index + 1]);
        }
    }
}
