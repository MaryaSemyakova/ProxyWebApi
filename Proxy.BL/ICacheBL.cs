using System.Collections.Generic;
using Proxy.BE;

namespace Proxy.BL
{
    public interface ICacheBL
    {
        IEnumerable<Product> GetProducts();
        Statistic GetStatistic(List<Product> products);
    }
}
