using Blog.GrenitausConsulting.ArtifactGeneratorTool.App.Domain;
using Blog.GrenitausConsulting.CLI.Services;
using Blog.GrenitausConsulting.CLI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gc_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[] {"build", "-dev" };

            IArgumentValidationService argumentValidationService = new ArgumentValidationService();
            IEnvironmentSettingsService environmentSettingsService = new EnvironmentSettingsService();

            if (!argumentValidationService.IsValid(args))
            {
                Console.WriteLine(argumentValidationService.Errors[0].Description);
                return;
            }

            try
            {
                EnvironmentSettings settings = environmentSettingsService.Get(args[1]);
                ICLIService cliService = new CLIService(settings);
                cliService.Generate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error processing your command.");
            }
        }
    }
}
