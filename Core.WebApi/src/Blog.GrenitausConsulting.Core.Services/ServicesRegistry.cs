using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Core.Services
{
    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            Scan(scan => {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
