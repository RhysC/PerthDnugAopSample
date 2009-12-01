using AopSample.Unity.Logging;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AopSample.Unity
{
    public static class ContainerRegistration
    {
        public static IUnityContainer Init()
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<IGreeter, Aussie>("Aussie");
            container.RegisterType<IGreeter, Kiwi>("Kiwi");
            container.RegisterType<IGreeter, Pom>("Pom");
            container.SetUpForLogging<IGreeter, Aussie>();
            return container;
        }
    }
}
