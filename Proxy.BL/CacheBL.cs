using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Proxy.BE;

namespace Proxy.BL
{
    public class CacheBL : ICacheBL
    {
        private readonly HttpClient _client;

        public CacheBL()
        {
            _client = new HttpClient();
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>();

            var url = ConfigurationManager.AppSettings["serviceUrl"];

            while (null != url)
            {
                var response = _client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                var productResult = JsonConvert.DeserializeObject<ProductResponce>(response.Content.ReadAsStringAsync().Result);
                products.AddRange(productResult.Products);

                url = productResult.NextUrl;
            }

            return products;
        }

        public Statistic GetStatistic(List<Product> products)
        {
            if (null == products)
            {
                return null;
            }

            var averagePrice = products.Average(x => x.Price);

            return new Statistic
            {
                Count = products.Count,
                MaxPrice = products.Max(x => x.Price),
                MinPrice = products.Min(x => x.Price),
                LowAveragePrice = averagePrice * (decimal) 0.8,
                HighAveragePrice = averagePrice * (decimal)1.2,
            };
        }
    }
}
