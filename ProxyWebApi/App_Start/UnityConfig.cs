using System.Web.Http;
using Unity;
using Unity.WebApi;
using Proxy.BL;
using Proxy.Cache;
using Unity.Lifetime;
using System.Net.Http;
using System.Configuration;
using Unity.Injection;

namespace ProxyWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<HttpClient>( new InjectionFactory(x => new HttpClient()));
            container.RegisterType<IProductBL, ProductBL>(new ContainerControlledLifetimeManager());
            container.RegisterType<IProductCache, ProductCache>(new ContainerControlledLifetimeManager()); 
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}