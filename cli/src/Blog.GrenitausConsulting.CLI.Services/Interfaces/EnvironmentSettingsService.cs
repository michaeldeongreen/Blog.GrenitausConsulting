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
            _configurationManagerWrapper = new ConfigurationManagerWrapper(ConfigurationManager.AppSettings);

            if (environment == "-dev")
                return GetDevSettings();
            else
                return GetProdSettings();

        }

        private EnvironmentSettings GetDevSettings()
        {
            string domain = _configurationManagerWrapper.Convert("DevDomain").ToAString();
            string jsonConfigDirectory = _configurationManagerWrapper.Convert("DevJsonConfigDirectory").ToAString();
            string outputDirectory = _configurationManagerWrapper.Convert("DevOutputDirectory").ToAString();
            string angularCliSrcDirtory = _configurationManagerWrapper.Convert("DevAngularCLISrctDirectory").ToAString();
            return new EnvironmentSettings() { Domain = domain, JsonConfigDirectory = jsonConfigDirectory, OutputDirectory = outputDirectory, AngularCLISrcDirectory = angularCliSrcDirtory  };
        }

        private EnvironmentSettings GetProdSettings()
        {
            string domain = _configurationManagerWrapper.Convert("ProdDomain").ToAString();
            string jsonConfigDirectory = _configurationManagerWrapper.Convert("ProdJsonConfigDirectory").ToAString();
            string outputDirectory = _configurationManagerWrapper.Convert("ProdOutputDirectory").ToAString();
            string angularCliSrcDirtory = _configurationManagerWrapper.Convert("ProdAngularCLISrctDirectory").ToAString();
            return new EnvironmentSettings() { Domain = domain, JsonConfigDirectory = jsonConfigDirectory, OutputDirectory = outputDirectory, AngularCLISrcDirectory = angularCliSrcDirtory };
        }
    }
}
