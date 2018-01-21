using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Common.Interfaces
{
    public interface IConfigurationManagerWrapper
    {
        IConfigurationManagerWrapper Setting(string section, string key);
        string ToAString();
    }
}
