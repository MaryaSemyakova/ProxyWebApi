using System.Collections.Generic;
using Proxy.BE;

namespace Proxy.BL
{
    public interface IProductBL
    {
        List<Product> GetProducts(string url);
        Statistic GetStatistic(List<Product> products);
    }
}
