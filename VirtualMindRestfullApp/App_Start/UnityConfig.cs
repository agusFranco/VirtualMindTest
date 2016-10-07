using Infrastructure.Implementation;
using Infrastructure.Interfaces;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Repository.Interfaces;
using Repository.Implementation;

namespace VirtualMindRestfullApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();   

            container.RegisterType<ICurrencyService, CurrencyService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}