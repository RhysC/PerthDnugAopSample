using System;
using System.Collections.Generic;
using System.Linq;

namespace AopSample.CSharp.Transactions
{
    /// <summary>
    /// A Data Access Layer fake
    /// </summary>
    class Dal
    {
        private List<Customer> customers = new List<Customer>();
        public int SaveCustomer(Customer customer)
        {
            if (customer.Id == 0)
            {
                customer.Id = new Random().Next();
            }
            customers.Add(customer);
            return customer.Id;
        }

        public Customer RetrieveCustomer(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> RetrieveCustomers()
        {
            return customers;
        }
    }
}