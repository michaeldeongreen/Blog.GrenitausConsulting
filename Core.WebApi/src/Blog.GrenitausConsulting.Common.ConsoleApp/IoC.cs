using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Common.ConsoleApp
{
    internal static class IoC
    {
        internal static Container Configure()
        {
            var container = new Container(config =>
            {
                config.Scan(s => {
                    s.TheCallingAssembly();
                    s.AssemblyContainingType<CommonRegistry>();
                    s.WithDefaultConventions();
                });

                config.IncludeRegistry<CommonRegistry>();
                config.IncludeRegistry<DefaultRegistry>();
            });

            return container;
        }
    }
}
