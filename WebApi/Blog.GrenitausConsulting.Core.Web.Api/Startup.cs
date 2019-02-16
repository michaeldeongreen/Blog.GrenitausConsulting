using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lamar;
using Blog.GrenitausConsulting.Core.Common;
using Blog.GrenitausConsulting.Core.Services;

namespace Blog.GrenitausConsulting.Core.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ServiceRegistry services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddMvc();
            services.AddCors();
            services.AddLogging();

            services.Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
                s.AssemblyContainingType<CommonRegistry>();
                s.AssemblyContainingType<ServicesRegistry>();
                s.AssemblyContainingType<DefaultRegistry>();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c => c.AllowAnyOrigin());
            BlogConfig.Configure($"{env.ContentRootPath}\\AppData");

            app.UseMvc();
        }
    }
}
