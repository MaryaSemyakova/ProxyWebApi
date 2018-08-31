using System.Net.Http;
using System.Web.Http;
using Proxy.BL;
using Proxy.Cache;
using ProxyWebApi.IoC;
using Unity;

namespace ProxyWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            var container = new UnityContainer();
            container.RegisterType<HttpClient, HttpClient>();
            container.RegisterType<ICacheBL, CacheBL>();
            container.RegisterType<IProductCache, ProductCache>();
            config.DependencyResolver = new UnityResolver(container);

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
