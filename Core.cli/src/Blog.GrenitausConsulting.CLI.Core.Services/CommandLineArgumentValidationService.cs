using Blog.GrenitausConsulting.CLI.Core.Common;
using Blog.GrenitausConsulting.CLI.Core.Domain;
using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.GrenitausConsulting.CLI.Core.Services
{
    public class CommandLineArgumentValidationService : ICommandLineArgumentValidationService
    {
        private IList<CommandLineArgument> _commandLineArguments;
        private IList<CommandLineArgumentError> _errors;
        public IList<CommandLineArgumentError> Errors { get { return _errors; } }

        public CommandLineArgumentValidationService()
        {
            _errors = new List<CommandLineArgumentError>();
        }

        public bool IsValid(IList<CommandLineArgument> commandLineArguments)
        {
            _commandLineArguments = commandLineArguments;
            if (!IsThereArguments())
                return false;
            if (!IsThereAConfigArgument())
                return false;
            if (!IsThereAOutputArgument())
                return false;
            if (!IsThereAApiUrlArgument())
                return false;

            return true;
        }

        private bool IsThereArguments()
        {
            if (_commandLineArguments == null || _commandLineArguments.Count == 0)
            {
                this._errors.Add(new CommandLineArgumentError() { Id = 0, Description = "Invalid arguments provided.  Should be: gc-cli -config \"c:\\configdirectory\" -output \"c:\\outputdirectory\" -apiurl \"http://blog.grenitausconsulting.com\" " });
                return false;
            }
            return true;
        }

        private bool IsThereAConfigArgument()
        {
            var argument = _commandLineArguments.Where(a => a.Type == CommandLineArgumentType.ConfigDir).SingleOrDefault();
            if (argument == null || string.IsNullOrEmpty(argument.Value))
            {
                this._errors.Add(new CommandLineArgumentError() { Id = 0, Description = "-configdir argument not provided. Example: -configdir \"c:\\configdirectory\"" });
                return false;
            }
            return true;
        }

        private bool IsThereAOutputArgument()
        {
            var argument = _commandLineArguments.Where(a => a.Type == CommandLineArgumentType.OutputDir).SingleOrDefault();
            if (argument == null || string.IsNullOrEmpty(argument.Value))
            {
                this._errors.Add(new CommandLineArgumentError() { Id = 0, Description = "-outputdir argument not provided.  Example: -outputdir \"c:\\outputdirectory\"" });
                return false;
            }
            return true;
        }

        private bool IsThereAApiUrlArgument()
        {
            var argument = _commandLineArguments.Where(a => a.Type == CommandLineArgumentType.ApiUrl).SingleOrDefault();
            if (argument == null || string.IsNullOrEmpty(argument.Value))
            {
                this._errors.Add(new CommandLineArgumentError() { Id = 0, Description = "-apiurl argument not provided.  Example: -apiurl \"http://blog.grenitausconsulting.com\"" });
                return false;
            }
            return true;
        }
    }
}