using Blog.GrenitausConsulting.CLI.Core.Services.Interfaces;
using Blog.GrenitausConsulting.CLI.Core.Domain;
using Newtonsoft.Json;
using System.IO;

namespace Blog.GrenitausConsulting.CLI.Core.Services
{
    public class EnvironmentSettingsService : IEnvironmentSettingsService
    {
        private string _path = string.Empty;
        public EnvironmentSettings Get(string environment, string path)
        {
            _path = path;
            if (environment == "-dev")
                return GetDevSettings();
            else
                return GetProdSettings();

        }

        private EnvironmentSettings GetDevSettings()
        {
            EnvironmentSettings settings = JsonConvert.DeserializeObject<EnvironmentSettings>(File.ReadAllText(string.Format(@"{0}\appsettings.Development.json", _path)));
            return settings;
        }

        private EnvironmentSettings GetProdSettings()
        {
            EnvironmentSettings settings = JsonConvert.DeserializeObject<EnvironmentSettings>(File.ReadAllText(string.Format(@"{0}\appsettings.Production.json", _path)));
            return settings;
        }
    }
}
