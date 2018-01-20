using Blog.GrenitausConsulting.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.GrenitausConsulting.Common
{
    public class TestService : ITestService
    {
        public string Me()
        {
            return "I work";
        }
    }
}
