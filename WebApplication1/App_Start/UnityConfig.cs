using Example.Business;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPersonRepository, PersonRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}