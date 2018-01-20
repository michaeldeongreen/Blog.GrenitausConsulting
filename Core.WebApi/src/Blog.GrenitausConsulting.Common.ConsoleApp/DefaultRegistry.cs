using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Common.ConsoleApp
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
