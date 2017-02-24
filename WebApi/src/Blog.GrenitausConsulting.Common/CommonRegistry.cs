using Blog.GrenitausConsulting.Common.Interfaces;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Blog.GrenitausConsulting.Common
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            Scan(scan => {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            For<IConfigurationManagerWrapper>().Use<ConfigurationManagerWrapper>().Ctor<NameValueCollection>().Is(ConfigurationManager.AppSettings);
        }
    }
}
