using System;

namespace AopSample.CSharp.Logging
{
   class Kiwi : IGreeter
    {
        public void Greet(string name)
        {
            //Log entry
            Console.WriteLine("Entering Greet");
            //Do work
            Console.WriteLine("Kia ora {0}", name);
           //log exit
            Console.WriteLine("Exiting Greet");
        }
    }

    class Pom : IGreeter
    {
        public void Greet(string name)
        {
            //Log entry
            Console.WriteLine("Entering Greet");
            //Do work
            Console.WriteLine("Hello {0}", name);
            //log exit
            Console.WriteLine("Exiting Greet");
        }
    }

    class Aussie : IGreeter
    {
        /// <summary>
        /// Greets the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <remarks>
        /// ***
        ///     This is an inappropriate use of functional programming, it would be better to use true AOP here
        /// ***
        /// </remarks>
        public void Greet(string name)
        {
            Logger.Log(Console.WriteLine, string.Format("G'Day {0}o", name));
        }
    }
}