using Blog.GrenitausConsulting.CLI.Core.Domain;
using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Blog.GrenitausConsulting.CLI.Core.Services
{
    public class ArgumentValidationService : ICommandLineArgumentValidationService
    {
        private string[] _args;
        private IList<ArgumentError> _errors;
        public IList<ArgumentError> Errors { get { return _errors; } }

        public ArgumentValidationService()
        {
            _errors = new List<ArgumentError>();
        }

        public bool IsValid(string[] args)
        {
            _args = args;
            if (!IsThereAHelpArgument())
            {
                if (!IsThereArguments())
                    return false;
                if (!IsThereABuildArgument())
                    return false;
                if (!IsThereAEnvironmentArgument())
                    return false;
            }

            return true;
        }

        private bool IsThereAHelpArgument()
        {
            if (!_args[0].Trim().Equals("-help", StringComparison.OrdinalIgnoreCase))
                return false;

            return true;
        }

        private bool IsThereArguments()
        {
            if (_args == null || _args.Length == 0 || _args.Length < 2)
            {
                this._errors.Add(new ArgumentError() { Id = 0, Description = "Invalid arguments provided.  Should be: gc-cli build -dev or gc-cli build -prod" });
                return false;
            }
            return true;
        }

        private bool IsThereABuildArgument()
        {
            if (_args[0].Trim() != "build")
            {
                this._errors.Add(new ArgumentError() { Id = 0, Description = "build argument not provided.  Should be: gc-cli build -dev or gc-cli build -prod" });
                return false;
            }
            return true;
        }

        private bool IsThereAEnvironmentArgument()
        {
            if (_args[1].Trim() != "-dev" && _args[1].Trim() != "-prod")
            {
                this._errors.Add(new ArgumentError() { Id = 0, Description = "environment argument not provided.  Should be: gc-cli build -dev or gc-cli build -prod" });
                return false;
            }
            return true;
        }
    }
}
