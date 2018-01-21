using Blog.GrenitausConsulting.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Common
{
    public class ConfigurationManagerWrapper : IConfigurationManagerWrapper
    {
        private readonly IConfiguration _configuration;
        private string _section = string.Empty;
        private string _key = string.Empty;

        public ConfigurationManagerWrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfigurationManagerWrapper Setting(string section, string key)
        {
            _section = section;
            _key = key;
            return this;
        }

        public string ToAString()
        {
            return _configuration[$"{_section}:{_key }"];
        }
    }
}
