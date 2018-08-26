using Microsoft.Extensions.Options;

namespace Blog.GrenitausConsulting.Core.Common.Interfaces
{
    public interface IConfigurationManagerWrapper
    {
        IOptions<AppSettings> AppSettings { get; }
    }
}
