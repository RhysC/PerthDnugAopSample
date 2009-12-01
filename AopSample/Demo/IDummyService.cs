using System.Collections.Generic;
using AopSample.CSharp.Transactions;

namespace AopSample.Demo
{
    public interface IDummyService
    {
        Customer SaveNewCustomer(Customer newCustomer);

        IList<string> GetAllCustomersNames();
    }
}