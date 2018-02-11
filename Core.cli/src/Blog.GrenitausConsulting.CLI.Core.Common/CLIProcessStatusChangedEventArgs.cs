using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.CLI.Core.Common
{
    public class CLIProcessStatusChangedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
