using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AopSample.Unity.Logging
{
    /// <summary>
    /// CallHandler, which can be added to Interception policy to wrap logging
    /// around calls Types that match the defined MatchingRule.
    /// </summary>
    public class LogCallHandler : ICallHandler
    {
        /// <summary>
        /// Gets or sets the order of execution for this handler.
        /// </summary>
        /// <value>The order.</value>
        public int Order { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogCallHandler"/> class.
        /// </summary>
        public LogCallHandler()
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
            // Log before method invocation
            Console.WriteLine(GetEntryMessage(input));

            // Call next handler in chain with the actual method the end of the chain
            var result = getNext().Invoke(input, getNext);

            // Log after method invocation
            if (result.Exception != null)
            {
                Console.WriteLine(GetExceptionMessage(input, result));
            }
            else
            {
                Console.WriteLine(GetExitMessage(input, result));
            }
            return result;
        }

        private static String GetEntryMessage(IMethodInvocation input)
        {
            var message = new StringBuilder();
            message.AppendFormat("Entering {0}", input.MethodBase.Name);
            if (input.Arguments.Count > 0)
            {
                message.Append(" with arguments [");
                IList<String> arguments = new List<string>();
                foreach (var argument in input.Arguments)
                {
                    arguments.Add(argument.ToString());
                }
                message.Append(String.Join(", ", arguments.ToArray()));
                message.Append("]");
            }
            message.Append(".");
            return message.ToString();
        }

        private static string GetExceptionMessage(IMethodInvocation input, IMethodReturn result)
        {
            if (result.Exception != null)
                return string.Format("Exception thrown with message : {0}.",
                                     result.Exception.Message);
            else
                return string.Format("No exception thrown on {0}.",
                                     input.MethodBase);

        }

        private static string GetExitMessage(IMethodInvocation input, IMethodReturn result)
        {
            if (result.ReturnValue != null)
                return string.Format("Exiting {0} with return value [{1}].",
                                     input.MethodBase.Name,
                                     result.ReturnValue);
            else
                return string.Format("Exiting {0}.", input.MethodBase.Name);

        }
    }
}