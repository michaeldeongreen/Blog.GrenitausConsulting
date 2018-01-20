using Blog.GrenitausConsulting.Common;
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
       internal static Container Configure(IServiceCollection services)
        {
            var container = new Container(config =>
            {
                config.IncludeRegistry<CommonRegistry>();
                config.IncludeRegistry<DefaultRegistry>();
                config.Populate(services);
            });

            return container;
        }
    }
}
