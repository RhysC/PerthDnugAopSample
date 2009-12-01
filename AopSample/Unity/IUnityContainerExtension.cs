using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AopSample.Unity.Logging
{
    public static class UnityContainerExtension
    {
        /// <summary>
        /// Sets up a registered type for logging.TImpl must not be of the same type as T. T should be an interface
        /// </summary>
        /// <typeparam name="T">The type of the interface that is registered</typeparam>
        /// <typeparam name="TImpl">The implementation type to be intercepted that implements the interface.</typeparam>
        /// <param name="container">The container.</param>
        public static void SetUpForLogging<T, TImpl>(this IUnityContainer container) where TImpl : T
        {
            //Example for rule driven definitions
            container.Configure<Interception>().
                SetDefaultInterceptorFor<T>(new TransparentProxyInterceptor()).
                AddPolicy("Logging" + typeof(TImpl)).
                AddMatchingRule(new TypeMatchingRule(typeof(TImpl))).
                AddCallHandler(typeof(LogCallHandler));
        }

        //public static void SetUpForCaching<T>(this IUnityContainer container)
        //{
        //    //Example for rule driven definitions
        //    container.Configure<Interception>().
        //        SetInterceptorFor<T>(new TransparentProxyInterceptor()).
        //        AddPolicy("Cache").
        //        AddMatchingRule(new AttributeDrivenPolicyMatchingRule());
        //}
    }
}