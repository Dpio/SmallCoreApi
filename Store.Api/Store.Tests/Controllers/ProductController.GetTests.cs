using Newtonsoft.Json;
using AutoFixture;
using Store.DataAccess.Entities;
using Store.Models.Products;
using Store.Tests.Utils;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class ProductController_GetTests : BaseTestController
    {
        [Fact]
        public async Task ShouldGetProduct()
        {
            var expected = Fixture.Build<Product>().With(t => t.Id, 1).Create();
            Context.Products.Add(expected);
            Context.SaveChanges();

            // Act
            var id = 1;
            var response = await Client.GetAsync($"api/Product/{id}");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<ProductDto>(jsonResult);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }

        [Fact]
        public async Task ShouldGetProductWithDetails()
        {
            var expected = new ProductBuilder().Build();
            expected.Code = "001";
            expected.Description = "Des";
            expected.DeliveryDate = new DateTime(2019, 4, 4);
            expected.Price = 3.2M;
            Context.Products.Add(expected);
            Context.SaveChanges();

            // Act
            var response = await Client.GetAsync($"api/Product/details/{expected.Id}");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<ProductDetailsDto>(jsonResult);
            Assert.Equal("(001) Des", actual.ProductDescription);
            Assert.Equal("(001) Des", actual.Type);
            Assert.Equal("(001) Des", actual.Unit);
            Assert.Equal("Dostępny", actual.IsAvailable);
            Assert.Equal("04.04.2019", actual.DeliveryDate);
            Assert.Equal(1, actual.CategoriesCount);
            Assert.Equal($"{expected.Price:C2}", actual.Price);
        }
    }
}