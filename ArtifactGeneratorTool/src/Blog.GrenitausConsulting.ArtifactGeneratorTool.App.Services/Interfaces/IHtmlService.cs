using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.ArtifactGeneratorTool.App.Services.Interfaces
{
    public interface IHtmlService
    {
        void Generate(string domain, string htmlOutputPath);
    }
}
