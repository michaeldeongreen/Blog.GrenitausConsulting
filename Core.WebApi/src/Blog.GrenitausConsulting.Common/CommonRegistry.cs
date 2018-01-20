using Blog.GrenitausConsulting.Common.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Common
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
            For<ITestService>().Use<TestService>();
        }
    }
}
