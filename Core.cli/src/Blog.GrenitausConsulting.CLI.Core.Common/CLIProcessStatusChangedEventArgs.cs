using System;

namespace Blog.GrenitausConsulting.CLI.Core.Common
{
    public class CLIProcessStatusChangedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
