using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Core.Common.Interfaces
{
    public interface IConfigurationManagerWrapper
    {
        IOptions<AppSettings> AppSettings { get; }
    }
}
