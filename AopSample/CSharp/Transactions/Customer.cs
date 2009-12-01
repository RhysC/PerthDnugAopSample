using System;

namespace AopSample.CSharp.Transactions
{
    /// <summary>
    /// A dumb class just for a trival example
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public override string ToString()
        {
            return "Customer id = " + Id;
        }
    }
}