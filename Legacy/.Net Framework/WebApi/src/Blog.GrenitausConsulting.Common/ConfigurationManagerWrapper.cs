using Blog.GrenitausConsulting.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Common
{
    public class ConfigurationManagerWrapper : IConfigurationManagerWrapper
    {
        private string _key = string.Empty;
        private readonly NameValueCollection _appSettings;
        private readonly ConnectionStringSettingsCollection _connectionStrings;

        public ConfigurationManagerWrapper(NameValueCollection appSettings, ConnectionStringSettingsCollection connectionStrings)
        {
            _appSettings = appSettings;
            _connectionStrings = connectionStrings;
        }

        public IConfigurationManagerWrapper AppSetting(string key)
        {
            _key = key;
            return this;
        }

        public string ConnectionString(string key)
        {
            return _connectionStrings[key].ConnectionString;
        }

        public bool ToABool()
        {
            return bool.Parse(_appSettings[_key]);
        }

        public int ToAInt()
        {
            return int.Parse(_appSettings[_key]);
        }

        public string ToAString()
        {
            return _appSettings[_key].ToString();
        }
    }
}
