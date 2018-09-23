using Blog.GrenitausConsulting.CLI.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace Blog.GrenitausConsulting.CLI.Core.Domain
{
    public class EnvironmentSettings
    {
        private readonly IList<CommandLineArgument> _commandLineArguments;
        public EnvironmentSettings(IList<CommandLineArgument> commandLineArguments)
        {
            _commandLineArguments = commandLineArguments;
            ApiUrl = _commandLineArguments.Where(a => a.Type == CommandLineArgumentType.ApiUrl).SingleOrDefault();
            ConfigDir = _commandLineArguments.Where(a => a.Type == CommandLineArgumentType.ConfigDir).SingleOrDefault();
            OutputDir = _commandLineArguments.Where(a => a.Type == CommandLineArgumentType.OutputDir).SingleOrDefault();
        }

        public CommandLineArgument ApiUrl { get; private set; }
        public CommandLineArgument ConfigDir { get; private set; }
        public CommandLineArgument OutputDir { get; private set; }
    }
}
