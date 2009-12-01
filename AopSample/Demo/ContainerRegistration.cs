using AopSample.Unity;
using AopSample.Unity.Logging;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AopSample.Demo
{
    public static class ContainerRegistration
    {
        public static IUnityContainer Init()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<IDummyService, DummyService2>();
            container.SetUpForLogging<IDummyService, DummyService2>();
            return container;
        }
    }
}