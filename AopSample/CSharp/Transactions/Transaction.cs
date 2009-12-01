using System;

namespace AopSample.CSharp.Transactions
{
    internal interface ITransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }

    class Transaction : ITransaction
    {
        public void Commit()
        {
        }

        public void RollBack()
        {
        }

        public void Dispose()
        {
        }
    }
}