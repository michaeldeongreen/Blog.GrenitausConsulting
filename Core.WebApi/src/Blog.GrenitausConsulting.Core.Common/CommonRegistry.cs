using StructureMap;

namespace Blog.GrenitausConsulting.Core.Common
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
       }
    }
}
