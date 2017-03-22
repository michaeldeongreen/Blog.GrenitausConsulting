using Blog.GrenitausConsulting.Web.Api;
using Blog.GrenitausConsulting.Web.Api.App_Start;
using Blog.GrenitausConsulting.Web.Api.DependencyResolution;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(Startup))]
namespace Blog.GrenitausConsulting.Web.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureStructureMap(config);
            WebApiConfig.Register(config);
            ConfigureBlog();
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureStructureMap(HttpConfiguration config)
        {
            IContainer container = IoC.Initialize();
            StructuremapMvc.StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructuremapMvc.StructureMapDependencyScope);
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
        }

        private void ConfigureBlog()
        {
            BlogConfig.Configure(System.Web.Hosting.HostingEnvironment.MapPath(@"/App_Data"));
        }
    }
}