using Blog.GrenitausConsulting.CLI.Core.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace gc_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            //args = new string[] {"build", "-dev" };
            string path = Directory.GetCurrentDirectory();

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(path);
            builder.Build();

            try
            {
                new Startup().Configure(args, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal static void CLIProcessStatusChangedHandler(object sender, CLIProcessStatusChangedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
