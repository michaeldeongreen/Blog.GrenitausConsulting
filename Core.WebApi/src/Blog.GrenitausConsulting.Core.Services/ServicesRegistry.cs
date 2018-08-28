using Lamar;

namespace Blog.GrenitausConsulting.Core.Services
{
    public class ServicesRegistry : ServiceRegistry
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
