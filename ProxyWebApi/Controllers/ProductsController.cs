using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Proxy.BE;
using Proxy.Cache;

namespace ProxyWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductCache _productCache;

        public ProductsController(IProductCache productCache)
        {
            _productCache = productCache;
        }

        [HttpGet]
        [ActionName("Products")]
        public List<Product> GetProducts(int skip, int count)
        {
            return _productCache.GetProducts().Skip(skip).Take(count).ToList();
        }

        [HttpGet]
        [ActionName("Statistic")]
        public Statistic GetStatistic()
        {
            return _productCache.GetStatistic();
        }
        
    }
}
