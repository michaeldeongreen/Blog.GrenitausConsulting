using StructureMap;

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
