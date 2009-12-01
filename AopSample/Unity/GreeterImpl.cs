using System;
using AopSample.Unity.Logging;

namespace AopSample.Unity
{
    class Aussie : IGreeter
    {
        public void Greet(string name)
        {
            Console.WriteLine("G'Day {0}o", name);
        }
    }
    class Kiwi : IGreeter
    {
        public void Greet(string name)
        {
            Console.WriteLine("Kia ora {0}", name);
        }
    }

    class Pom : IGreeter
    {
        [Log]
        public void Greet(string name)
        {
            Console.WriteLine("Hello {0}", name);
        }
    }
}