using Blog.GrenitausConsulting.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Common
{
    public class ConfigurationManagerWrapper : IConfigurationManagerWrapper
    {
        private string _key = string.Empty;
        private NameValueCollection _collection;

        public ConfigurationManagerWrapper(NameValueCollection collection)
        {
            _collection = collection;
        }

        public IConfigurationManagerWrapper Convert(string key)
        {
            _key = key;
            return this;
        }

        public bool ToABool()
        {
            return bool.Parse(_collection[_key]);
        }

        public int ToAInt()
        {
            return int.Parse(_collection[_key]);
        }

        public string ToAString()
        {
            return _collection[_key].ToString();
        }
    }
}
