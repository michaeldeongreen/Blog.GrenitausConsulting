using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Common.Interfaces
{
    public interface IConfigurationManagerWrapper
    {
        IOptions<AppSettings> AppSettings { get; }
    }
}
