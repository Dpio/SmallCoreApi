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
    public class ProductController_GetActiveTests : BaseTestController
    {
        [Fact]
        public async Task ShouldGetActiveProducts()
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

        [Theory]
        [InlineData(0, 3)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        public async Task ShouldGetActiveProducts_WithPagination(int skip, int max)
        {
            var products = Fixture.Build<Product>().With(p => p.IsAvailable, true).CreateMany(5).OrderBy(p => p.Id).ToList();
            Context.Products.AddRange(products);
            Context.SaveChanges();

            // Act
            var response = await Client.GetAsync($"api/Product/getActive?MaxResultCount={max}&SkipCount={skip}");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonResult).ToList();
            Assert.True(actual.All(p => p.IsAvailable));
            Assert.Equal(actual.Count(), max);
        }

        [Fact]
        public async Task ShouldSkipFirstAndLastProduct()
        {
            var products = Fixture.Build<Product>().With(p => p.IsAvailable, true).CreateMany(4).OrderBy(p => p.Id).ToList();
            var skipedProduct = products.First();
            var skipedProduct2 = products.Last();
            Context.Products.AddRange(products);
            Context.SaveChanges();

            // Act
            var response = await Client.GetAsync($"api/Product/getActive?MaxResultCount=2&SkipCount=1");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonResult).ToList();
            Assert.True(actual.All(p => p.IsAvailable));
            var any = actual.All(dto => dto.Id != skipedProduct.Id && dto.Id != skipedProduct2.Id);
            Assert.True(any);
        }
    }
}