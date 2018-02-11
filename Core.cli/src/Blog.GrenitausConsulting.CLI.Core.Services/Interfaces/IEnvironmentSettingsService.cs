using Blog.GrenitausConsulting.CLI.Core.Domain;

namespace Blog.GrenitausConsulting.CLI.Core.Services.Interfaces
{
    public interface IEnvironmentSettingsService
    {
        EnvironmentSettings Get(string environment);
    }
}
