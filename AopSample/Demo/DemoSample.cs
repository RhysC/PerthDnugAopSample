using System;
using System.Linq;
using AopSample.CSharp.Transactions;

namespace AopSample.Demo
{
    static class DemoSample
    {
        public static void RunDemoSample()
        {
            Console.WriteLine("---Starting AOP DemoSample...");
            Console.WriteLine();
            //Register Components
            var container = Demo.ContainerRegistration.Init();
            //Retrieve Component
            var dummyService = container.Resolve<IDummyService>();
            //Run Code
            var customer = dummyService.SaveNewCustomer(new Customer{Id=7, Name="Rhys"});
            Console.WriteLine("---Saved Customer id = {0}", customer.Id);
            var names = dummyService.GetAllCustomersNames();
            Console.WriteLine("---names are {0}", string.Join(",", names.ToArray()));
            
            customer = dummyService.SaveNewCustomer(new Customer { Name = "Mitch" });
            Console.WriteLine("---Saved Customer id = {0}", customer.Id);
            names = dummyService.GetAllCustomersNames();
            Console.WriteLine("---names are {0}",string.Join(",", names.ToArray()));//should be cached
            
            Console.WriteLine("[Enter] to continue...");
            Console.ReadLine();
        }

        public static void RunInitialDemoSample()
        {
            Console.WriteLine("---Starting Original DemoSample...");
            Console.WriteLine();

            var dummyService = new DummyService();
            
            var customer = dummyService.SaveNewCustomer(new Customer{Id=7, Name="Rhys"});
            Console.WriteLine("---Saved Customer id = {0}", customer.Id);
            var names = dummyService.GetAllCustomersNames();
            Console.WriteLine("---names are {0}", string.Join(",", names.ToArray()));
            
            customer = dummyService.SaveNewCustomer(new Customer { Name = "Mitch" });
            Console.WriteLine("---Saved Customer id = {0}", customer.Id);
            names = dummyService.GetAllCustomersNames();
            Console.WriteLine("---names are {0}",string.Join(",", names.ToArray()));//should be cached
            
            Console.WriteLine("[Enter] to continue...");
            Console.ReadLine();
        }
    }
}
