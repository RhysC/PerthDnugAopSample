using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AopSample.Unity
{
    class UnitySample
    {
        public static void RunLoggerSample()
        {
            Console.WriteLine("Starting UnitySample...");
            Console.WriteLine();
            //Register Components
            var container = Unity.ContainerRegistration.Init();
            //Retrieve Component
            var greeters = container.ResolveAll<IGreeter>();
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
