using Blog.GrenitausConsulting.CLI.Core.Common;
using Blog.GrenitausConsulting.CLI.Core.Domain;
using Blog.GrenitausConsulting.CLI.Core.Services;
using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace gc_cli
{
    public class Startup
    {
        private ICommandLineArgumentParseService _commandLineArgumentParseService;
        private ICommandLineArgumentValidationService _commandLineArgumentValidationService;

        public void Configure(string[] args, ICommandLineArgumentParseService commandLineArgumentParseService, ICommandLineArgumentValidationService commandLineArgumentValidationService)
        {
            _commandLineArgumentParseService = commandLineArgumentParseService;
            _commandLineArgumentValidationService = commandLineArgumentValidationService;

            var commandLineArguments = BuildCommandLineArguments(args);

            if (!_commandLineArgumentValidationService.IsValid(commandLineArguments))
            {
                throw new Exception(_commandLineArgumentValidationService.Errors[0].Description);
            }

            ICLIService cliService = new CLIService(commandLineArguments);

            cliService.CLILogMessageProcessStatusChanged += Program.CLILogMessageHandler;
            cliService.Generate();
            cliService.CLILogMessageProcessStatusChanged -= Program.CLILogMessageHandler;
        }

        private IList<CommandLineArgument> BuildCommandLineArguments(string[] args)
        {
            IList<CommandLineArgument> commandLineArguments = new List<CommandLineArgument>();
            foreach (CommandLineArgumentType type in Enum.GetValues(typeof(CommandLineArgumentType)))
            {
                var argument = _commandLineArgumentParseService.Parse(args, type);
                if (argument != null)
                    commandLineArguments.Add(argument);
            }
            return commandLineArguments;
        }
    }
}
