using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.GrenitausConsulting.ArtifactGeneratorTool.App.Domain;
using Blog.GrenitausConsulting.Common.Interfaces;
using Blog.GrenitausConsulting.Common;
using System.Configuration;

namespace Blog.GrenitausConsulting.CLI.Services.Interfaces
{
    public class EnvironmentSettingsService : IEnvironmentSettingsService
    {
        IConfigurationManagerWrapper _configurationManagerWrapper;
        public EnvironmentSettings Get(string environment)
        {
            _configurationManagerWrapper = new ConfigurationManagerWrapper(ConfigurationManager.AppSettings, ConfigurationManager.ConnectionStrings);

            if (environment == "-dev")
                return GetDevSettings();
            else
                return GetProdSettings();

        }

        private EnvironmentSettings GetDevSettings()
        {
            string domain = _configurationManagerWrapper.AppSetting("DevDomain").ToAString();
            string jsonConfigDirectory = _configurationManagerWrapper.AppSetting("DevJsonConfigDirectory").ToAString();
            string outputDirectory = _configurationManagerWrapper.AppSetting("DevOutputDirectory").ToAString();
            string angularCliSrcDirtory = _configurationManagerWrapper.AppSetting("DevAngularCLISrctDirectory").ToAString();
            return new EnvironmentSettings() { Domain = domain, JsonConfigDirectory = jsonConfigDirectory, OutputDirectory = outputDirectory, AngularCLISrcDirectory = angularCliSrcDirtory  };
        }

        private EnvironmentSettings GetProdSettings()
        {
            string domain = _configurationManagerWrapper.AppSetting("ProdDomain").ToAString();
            string jsonConfigDirectory = _configurationManagerWrapper.AppSetting("ProdJsonConfigDirectory").ToAString();
            string outputDirectory = _configurationManagerWrapper.AppSetting("ProdOutputDirectory").ToAString();
            string angularCliSrcDirtory = _configurationManagerWrapper.AppSetting("ProdAngularCLISrctDirectory").ToAString();
            return new EnvironmentSettings() { Domain = domain, JsonConfigDirectory = jsonConfigDirectory, OutputDirectory = outputDirectory, AngularCLISrcDirectory = angularCliSrcDirtory };
        }
    }
}
