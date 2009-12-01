using System;

namespace AopSample.CSharp.Transactions
{
    /// <summary>
    /// My bloated dummy class
    /// </summary>
    class DummyService
    {
        private readonly Dal dal = new Dal();

        public Customer SaveNewCustomer(Customer newCustomer)
        {
            using (var transaction = new Transaction())
            {
                try
                {
                    var id = dal.SaveCustomer(newCustomer);
                    var customer = dal.RetrieveCustomer(id);
                    transaction.Commit();
                    return customer;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.RollBack();
                    throw;
                }
            }
        }
        public Customer UpdateCustomerAddress(int customerId, Address address)
        {
            using (var transaction = new Transaction())
            {
                try
                {
                    var customer = dal.RetrieveCustomer(customerId);
                    customer.Address = address;
                    dal.SaveCustomer(customer);
                    customer = dal.RetrieveCustomer(customerId);
                    return customer;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.RollBack();
                    throw;
                }
            }
        }
    }
}