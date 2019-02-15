using Blog.GrenitausConsulting.CLI.Core.Common;
using Blog.GrenitausConsulting.CLI.Core.Domain;

namespace Blog.GrenitausConsulting.CLI.Core.Services.Interfaces
{
    public interface ICommandLineArgumentParseService
    {
        CommandLineArgument Parse(string[] args, CommandLineArgumentType type);
    }
}
