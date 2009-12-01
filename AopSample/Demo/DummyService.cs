using System;
using System.Collections.Generic;
using System.Linq;
using AopSample.CSharp.Transactions;

namespace AopSample.Demo
{
    public class DummyService : IDummyService
    {
        private readonly Dal dal = new Dal();
        private Dictionary<string, object> Cache = new Dictionary<string, object>();
        
        public Customer SaveNewCustomer(Customer newCustomer)
        {
            Console.WriteLine("Entering SaveNewCustomer with {0}", newCustomer);
            using (var transaction = new Transaction())
            {
                try
                {
                    var id = dal.SaveCustomer(newCustomer);
                    var customer = dal.RetrieveCustomer(id);
                    transaction.Commit();
                    Console.WriteLine("Exiting SaveNewCustomer with {0}", customer);
                    return customer;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occured : {0}", ex.Message);
                    transaction.RollBack();
                    throw;
                }
            }

        }
        public IList<string> GetAllCustomersNames()
        {
            const string cacheKey = "GetAllCustomersNames";
            Console.WriteLine("Entering GetAllCustomersNames");
            if (Cache.ContainsKey(cacheKey))
            {
                return Cache[cacheKey] as IList<string>;
            }
            var returnValue = (from c in dal.RetrieveCustomers() select c.Name).ToList();
            Cache.Add(cacheKey, returnValue);
            Console.WriteLine("Exiting SaveNewCustomer");
            return returnValue;
        }
    }
}