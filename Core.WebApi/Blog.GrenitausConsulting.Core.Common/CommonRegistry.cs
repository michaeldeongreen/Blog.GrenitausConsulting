using Lamar;

namespace Blog.GrenitausConsulting.Core.Common
{
    public class CommonRegistry : ServiceRegistry
    {
        public CommonRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
       }
    }
}
