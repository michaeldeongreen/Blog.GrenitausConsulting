using Blog.GrenitausConsulting.ArtifactGeneratorTool.App.Domain;
using Blog.GrenitausConsulting.CLI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.CLI.Services.Interfaces
{
    public interface ICLIService
    {
        event EventHandler<CLIProcessStatusChangedEventArgs> CLIProcessStatusChanged;
        void Generate();
    }
}
