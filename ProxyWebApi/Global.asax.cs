using System.Web.Http;
using Proxy.Cache;

namespace ProxyWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ProductCache.Instance.LoadCache();
        }
    }
}
