using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.CLI.Common
{
    public class CLIProcessStatusChangedEventArgs : EventArgs
    {
       public string Message { get; set; }
    }
}
