using Blog.GrenitausConsulting.CLI.Core.Domain;
using System.Collections.Generic;


namespace Blog.GrenitausConsulting.CLI.Core.Services.Interfaces
{
    public interface IArgumentValidationService
    {
        IList<ArgumentError> Errors { get; }
        bool IsValid(string[] args);

    }
}
