using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AopSample.Unity.Caching
{
    class CachingCallHandler : ICallHandler
    {
        private static Dictionary<string, object> Cache = new Dictionary<string, object>();
        /// <summary>
        /// Gets or sets the order of execution for this handler.
        /// </summary>
        /// <value>The order.</value>
        public int Order { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingCallHandler"/> class.
        /// </summary>
        public CachingCallHandler()
        {
            Order = 0; // Called first
        }

        /// <summary>
        /// Method called to invoke the method of the wrapped type used to
        /// inject the logging around the atual method call.
        /// </summary>
        /// <param name="input">The method to be invoked.</param>
        /// <param name="getNext">Gets the next call handler.</param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //check to see if the cache exits, if so return it
            var inputs = new object[input.Inputs.Count];
            for (int i = 0; i < inputs.Length; ++i)
            {
                inputs[i] = input.Inputs[i];
            }

            string cacheKey = string.Format("{0}-{1}-{2}",
                input.MethodBase.DeclaringType.FullName,
                input.MethodBase.Name,
                string.Join(",", (from i in inputs select i.ToString()).ToArray()));
            if (Cache.ContainsKey(cacheKey))
            {
                return input.CreateMethodReturn(Cache[cacheKey], input.Arguments) ;
            }
            // Call next handler in chain with the actual method the end of the chain
            var result = getNext().Invoke(input, getNext);
            Cache.Add(cacheKey, result.ReturnValue);
            return result;
        }

    }
}
