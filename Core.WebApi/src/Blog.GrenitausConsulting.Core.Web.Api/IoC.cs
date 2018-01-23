using Blog.GrenitausConsulting.Core.Common;
using Blog.GrenitausConsulting.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Core.Web.Api
{
    internal static class IoC
    {
       internal static Container Configure(IConfiguration configuration, IServiceCollection services)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

            var container = new Container(config =>
            {
                config.Scan(s => {
                    s.TheCallingAssembly();
                    s.AssemblyContainingType<CommonRegistry>();
                    s.AssemblyContainingType<ServicesRegistry>();
                    s.WithDefaultConventions();
                });

                config.IncludeRegistry<CommonRegistry>();
                config.IncludeRegistry<ServicesRegistry>();
                config.IncludeRegistry<DefaultRegistry>();
                config.Populate(services);
            });
            return container;
        }
    }
}
