using System;
using AopSample.CSharp;
using AopSample.Unity;

namespace AopSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo.DemoSample.RunInitialDemoSample(); //the bloated Dummy Service
            //UnitySample.RunLoggerSample();
            //FunctionalSample.RunLoggerSample();
            Demo.DemoSample.RunDemoSample(); //The cleaned up service, should return similar values to the first example
        }
    }
}
