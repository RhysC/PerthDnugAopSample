using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopSample.CSharp.Logging;

namespace AopSample.CSharp
{
    class FunctionalSample
    {
        public static void RunLoggerSample()
        {
            Console.WriteLine("Starting FunctionalSample...");
            Console.WriteLine();
            var greeters = new List<IGreeter>{new Aussie(),new Kiwi(),new Pom()};
            //Run Code
            foreach (var greeter in greeters)
            {
                greeter.Greet("Frank");
                Console.WriteLine();
            }
            Console.WriteLine("[Enter] to continue...");
            Console.ReadLine();
        }
    }
}
