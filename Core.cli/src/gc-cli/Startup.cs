using Blog.GrenitausConsulting.CLI.Core.Common;
using Blog.GrenitausConsulting.CLI.Core.Domain;
using Blog.GrenitausConsulting.CLI.Core.Services;
using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace gc_cli
{
    public class Startup
    {
        public void Configure(string[] args, string path)
        {
            IArgumentValidationService argumentValidationService = new ArgumentValidationService();
            IEnvironmentSettingsService environmentSettingsService = new EnvironmentSettingsService();

            if (!argumentValidationService.IsValid(args))
            {
                throw new Exception(argumentValidationService.Errors[0].Description);
            }

            try
            {
                EnvironmentSettings settings = environmentSettingsService.Get(args[1], path);
                ICLIService cliService = new CLIService(settings);

                cliService.CLIProcessStatusChanged += Program.CLIProcessStatusChangedHandler;
                cliService.Generate();
                cliService.CLIProcessStatusChanged -= Program.CLIProcessStatusChangedHandler;
            }
            catch (Exception)
            {
                throw new Exception("There was an error processing your command.");
            }
        }
    }
}
