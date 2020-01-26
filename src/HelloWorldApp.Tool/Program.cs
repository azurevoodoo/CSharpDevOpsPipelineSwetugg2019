using System;
using System.Linq;
using HelloWorldApp.Common;

namespace HelloWorldApp.Tool
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var name = args.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Usage: HelloWorldApp [NAME]");
                return 1;
            }

            Console.WriteLine(Greeter.GetGreeting(name));
            return 0;
        }
    }
}
