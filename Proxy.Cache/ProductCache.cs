using System.Collections.Generic;
using System.Runtime.Caching;
using Proxy.BE;
using Proxy.BL;

namespace Proxy.Cache
{
    public class ProductCache
    {
        private MemoryCache _memoryCache;
        private CacheBL _cacheBL;

        #region singleton

        private static ProductCache _instance;
        private static object _lock = new object();

        public static ProductCache Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (_lock)
                    {
                        _instance = new ProductCache();
                    }
                }

                return _instance;
            }
        }
        #endregion

        public ProductCache()
        {
            _memoryCache = MemoryCache.Default;
            _cacheBL = new CacheBL();
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

