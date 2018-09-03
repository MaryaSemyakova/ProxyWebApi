using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Moq;
using System.Configuration;
using Proxy.BE;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Moq.Protected;
using System.Threading;

namespace Proxy.BL.Tests
{
    [TestClass]
    public class ProductBLTest
    {
        [TestMethod]
        public void GetProducts_UnitTest()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock.Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(GetSuccessTask())
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);            
            var productBl = new ProductBL(httpClient);

            // Act
            var result = productBl.GetProducts("http://alfa-test-api.dev.kroniak.net/api/v1/products/");

            // Assert
            Assert.AreEqual(result.Count, GetProducts().Count);
            Assert.AreEqual(result[0].Price, GetProducts()[0].Price);
            Assert.AreEqual(result[1].Price, GetProducts()[1].Price);
            Assert.AreEqual(result[2].Price, GetProducts()[2].Price);
        }

        [TestMethod]
        public void GetStatistic_UnitTest()
        {
            // Arrange
            var products = GetProducts();
            var httpClient = new Mock<HttpClient>(MockBehavior.Strict);
            var productBl = new ProductBL(httpClient.Object);

            // Act
            var result = productBl.GetStatistic(products);

            // Assert
            Assert.AreEqual((decimal)1428.80, result.MaxPrice);
            Assert.AreEqual((decimal)65.28, result.MinPrice);
            Assert.AreEqual((decimal)738.12, result.HighAveragePrice);
            Assert.AreEqual((decimal)492.08, result.LowAveragePrice);
            Assert.AreEqual(3, result.Count);
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{Price=(decimal)1428.80, PartNumber=3386166, Description = "Desc1"},
                new Product{Price=(decimal)351.22, PartNumber=9157023, Description = "Desc2"},
                new Product{Price=(decimal)65.28, PartNumber=4022749, Description = "Desc3"}                
            };
        }

        private HttpResponseMessage GetSuccessTask()
        {
            var data = "{ \"count\": 3, \"products\": [ { \"part_number\": 3386166, \"description\": \"Desc1\", \"price\": \"1428.80\" }, { \"part_number\": 9157023, \"description\": \"Desc2\", \"price\": \"351.22\" }, { \"part_number\": 4022749, \"description\": \"Desc3\", \"price\": \"65.28\" } ], \"next\": null }";
            var response = new HttpResponseMessage();
            response.Content = new StringContent(data);
            return response;
        }
    }
}
