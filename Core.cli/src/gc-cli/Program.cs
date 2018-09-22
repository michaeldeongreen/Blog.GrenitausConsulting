using Blog.GrenitausConsulting.CLI.Core.Common;
using Blog.GrenitausConsulting.CLI.Core.Services;
using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace gc_cli
{
    class Program
    {
        private static ILogger<Program> _logger;
        private static ICommandLineArgumentParseService _commandLineArgumentParseService;
        private static ICommandLineArgumentValidationService _commandLineArgumentValidationService;
        static void Main(string[] args)
        {
            args = new string[] {"-configdir", @"C:\temp\gc-cli\config", "-outputdir", @"C:\temp\gc-cli\output", "-apiurl", "http://localhost:4200" };
            string path = Directory.GetCurrentDirectory();

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(path);
            builder.Build();

            try
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                _logger = serviceCollection.BuildServiceProvider().GetService<ILogger<Program>>();
                _commandLineArgumentParseService = serviceCollection.BuildServiceProvider().GetService<ICommandLineArgumentParseService>();
                _commandLineArgumentValidationService = serviceCollection.BuildServiceProvider().GetService<ICommandLineArgumentValidationService>();
                new Startup().Configure(args, _commandLineArgumentParseService, _commandLineArgumentValidationService, path);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
            services.AddScoped<ICommandLineArgumentParseService, CommandLineArgumentParseService>();
        }

        internal static void CLILogMessageHandler(object sender, CLILogMessageEventArgs e)
        {
            _logger.LogInformation(e.Message);
        }
    }
}
