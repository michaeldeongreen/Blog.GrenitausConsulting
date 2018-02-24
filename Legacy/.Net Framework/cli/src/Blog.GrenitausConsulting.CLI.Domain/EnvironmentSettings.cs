using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.ArtifactGeneratorTool.App.Domain
{
    public class EnvironmentSettings
    {
        public string Domain { get; set; }
        public string JsonConfigDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public string AngularCLISrcDirectory { get; set; }
    }
}
