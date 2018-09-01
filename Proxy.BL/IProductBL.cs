using System.Collections.Generic;
using Proxy.BE;

namespace Proxy.BL
{
    public interface IProductBL
    {
        IEnumerable<Product> GetProducts();
        Statistic GetStatistic(List<Product> products);
    }
}
