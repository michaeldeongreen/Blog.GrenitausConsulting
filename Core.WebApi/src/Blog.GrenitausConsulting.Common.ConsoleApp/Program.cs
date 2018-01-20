using System;

namespace Blog.GrenitausConsulting.Common.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = IoC.Configure();
            Console.WriteLine("Hello World!");
        }
    }
}
