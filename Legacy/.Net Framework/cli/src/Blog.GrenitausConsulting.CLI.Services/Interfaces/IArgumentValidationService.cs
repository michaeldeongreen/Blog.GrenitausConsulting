using Blog.GrenitausConsulting.ArtifactGeneratorTool.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.CLI.Services.Interfaces
{
    public interface IArgumentValidationService
    {
        IList<ArgumentError> Errors { get; }
        bool IsValid(string[] args);

    }
}
