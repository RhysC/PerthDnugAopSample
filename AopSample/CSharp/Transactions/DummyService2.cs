using System;

namespace AopSample.CSharp.Transactions
{
    /// <summary>
    /// My slightly cleaned up dummy class. See the AopSample.Demo.DummyService2 for the cleaned up version
    /// </summary>
    class DummyService2
    {
        private readonly Dal dal = new Dal();

        public Customer SaveNewCustomer(Customer newCustomer)
        {
            return RunInTransaction(
                () =>
                {
                    var id = dal.SaveCustomer(newCustomer);
                    var customer = dal.RetrieveCustomer(id);
                    return customer;
                });
        }
        public Customer UpdateCustomerAddress(int customerId, Address address)
        {
            return RunInTransaction(
                () =>
                {
                    var customer = dal.RetrieveCustomer(customerId);
                    customer.Address = address;
                    dal.SaveCustomer(customer);
                    customer = dal.RetrieveCustomer(customerId);
                    return customer;
                });
        }

        /// <summary>
        /// Runs the in transaction.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        /// <remarks>
        /// ***
        /// A more appropriate use of using delegates, now the developer can:
        /// - still step thru their code using a debugger
        /// - easily tell the code is in a transaction, there is no behind the scenes magic 
        /// *** 
        /// </remarks>
        protected T RunInTransaction<T>(Func<T> function)
        {
            using (var transaction = new Transaction())
            {
                try
                {
                    var returnValue = function();
                    transaction.Commit();//Dont forget me!!!
                    return returnValue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);//could be removed and handled by runtime interception
                    transaction.RollBack();//Im important too!
                    throw;
                }
            }
        }
    }
}