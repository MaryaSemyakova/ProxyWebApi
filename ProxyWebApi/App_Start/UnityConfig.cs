using System.Web.Http;
using Unity;
using Unity.WebApi;
using Proxy.BL;
using Proxy.Cache;
using Unity.Lifetime;

namespace ProxyWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICacheBL, CacheBL>(new ContainerControlledLifetimeManager());
            container.RegisterType<IProductCache, ProductCache>(new ContainerControlledLifetimeManager()); 
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}