using System.Collections.Generic;
using Proxy.BE;

namespace Proxy.Cache
{
    public interface IProductCache
    {
        List<Product> GetProducts();
        Statistic GetStatistic();
    }
}
