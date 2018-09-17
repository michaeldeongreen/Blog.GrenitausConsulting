using Blog.GrenitausConsulting.CLI.Core.Common;
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
        static void Main(string[] args)
        {
            args = new string[] {"build", "-dev" };
            string path = Directory.GetCurrentDirectory();

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(path);
            builder.Build();

            try
            {
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                _logger = serviceCollection.BuildServiceProvider().GetService<ILogger<Program>>();
                new Startup().Configure(args, path);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole());
        }

        internal static void CLIProcessStatusChangedHandler(object sender, CLIProcessStatusChangedEventArgs e)
        {
            _logger.LogInformation(e.Message);
        }
    }
}
