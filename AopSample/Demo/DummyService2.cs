using System.Collections.Generic;
using System.Linq;
using AopSample.CSharp.Transactions;
using AopSample.Unity.Caching;

namespace AopSample.Demo
{
    public class DummyService2 : IDummyService
    {
        private readonly Dal dal = new Dal();

        public Customer SaveNewCustomer(Customer newCustomer)
        {
            return Helper.RunInTransaction(() =>
                {
                    var id = dal.SaveCustomer(newCustomer);
                    return dal.RetrieveCustomer(id);
                });
        }

        [Cache]
        public IList<string> GetAllCustomersNames()
        {
            return (from c in dal.RetrieveCustomers() select c.Name).ToList();
        }
    }
}