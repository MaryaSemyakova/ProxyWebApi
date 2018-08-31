using System.Collections.Generic;
using System.Runtime.Caching;
using Proxy.BE;
using Proxy.BL;

namespace Proxy.Cache
{
    public class ProductCache : IProductCache
    {
        private readonly MemoryCache _memoryCache;
        private readonly ICacheBL _cacheBL;
        
        public ProductCache(ICacheBL cacheBL)
        {
            _memoryCache = MemoryCache.Default;
            _cacheBL = cacheBL;
            LoadCache();
        }

        public void LoadCache()
        {
            if (null == _memoryCache["products"])
            {
                _memoryCache["products"] = _cacheBL.GetProducts();
            }

            if (null == _memoryCache["statistic"])
            {
                _memoryCache["statistic"] = _cacheBL.GetStatistic(GetProducts());
            }
        }

        public List<Product> GetProducts()
        {
            return _memoryCache["products"] as List<Product>;
        }

        public Statistic GetStatistic()
        {
            return _memoryCache["statistic"] as Statistic;
        }
    }
}

