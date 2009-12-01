using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopSample.CSharp.Transactions;

namespace AopSample.Demo
{
    class Helper
    {
        internal static T RunInTransaction<T>(Func<T> function)
        {
            using (var transaction = new Transaction())
            {
                try
                {
                    var returnValue = function();
                    transaction.Commit();//Dont forget me!!!
                    return returnValue;
                }
                catch (Exception)
                {
                    transaction.RollBack();//Im important too!
                    throw;
                }
            }
        }
    }
}
