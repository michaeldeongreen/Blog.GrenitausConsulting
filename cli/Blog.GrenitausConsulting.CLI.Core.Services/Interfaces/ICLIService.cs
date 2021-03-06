﻿using Blog.GrenitausConsulting.CLI.Core.Common;
using System;

namespace Blog.GrenitausConsulting.CLI.Core.Services.Interfaces
{
    public interface ICLIService
    {
        event EventHandler<CLILogMessageEventArgs> CLILogMessageProcessStatusChanged;
        void Generate();
    }
}
