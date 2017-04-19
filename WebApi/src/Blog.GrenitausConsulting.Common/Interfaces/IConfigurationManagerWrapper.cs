using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.GrenitausConsulting.Common.Interfaces
{
    public interface IConfigurationManagerWrapper
    {
        IConfigurationManagerWrapper AppSetting(string key);

        string ConnectionString(string key);

        int ToAInt();

        bool ToABool();

        string ToAString();
    }
}
