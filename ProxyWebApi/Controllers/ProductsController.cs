using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Proxy.BE;
using Proxy.Cache;

namespace ProxyWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        [ActionName("Products")]
        public List<Product> GetProducts(int skip, int count)
        {
            return ProductCache.Instance.GetProducts().Skip(skip).Take(count).ToList();
        }

        [HttpGet]
        [ActionName("Statistic")]
        public Statistic GetStatistic()
        {
            return ProductCache.Instance.GetStatistic();
        }
        
    }
}
