using System;
using System.Text;

namespace AopSample.CSharp.Logging
{
    class Logger
    {
        public static void Log<T>(Action<T> action, T param)
        {
            Console.WriteLine(GetEntryMessage(action, param));
            try
            {
                action(param);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception thrown with message : {0}.", ex.Message));
                throw;
            }
            Console.WriteLine("Exiting {0}", action.Method.Name);
        }

        private static String GetEntryMessage<T>(Action<T> input, T param)
        {
            var message = new StringBuilder();
            message.AppendFormat("Entering {0}", input.Method.Name);
            var parameters = input.Method.GetParameters();
            if (parameters.Length > 0)
            {
                message.Append(" with arguments [");
                message.AppendFormat("{0} {1}", param.GetType(), param);
                message.Append("]");
            }
            message.Append(".");
            return message.ToString();
        }
    }
}