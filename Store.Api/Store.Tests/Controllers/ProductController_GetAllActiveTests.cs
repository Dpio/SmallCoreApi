using Newtonsoft.Json;
using AutoFixture;
using Store.DataAccess.Entities;
using Store.Models.Products;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class ProductController_GetAllActiveTests : BaseTestController
    {
        [Fact]
        public async Task ShouldGetProducts()
        {
            var products = Fixture.Build<Product>().With(p => p.IsAvailable, false).CreateMany().ToList();
            var activeProduct = products.First();
            activeProduct.IsAvailable = true;
            Context.Products.AddRange(products);
            Context.SaveChanges();

            // Act
            var response = await Client.GetAsync($"api/Product/getActive");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonResult);
            Assert.True(actual.All(p => p.IsAvailable));
        }
    }
}