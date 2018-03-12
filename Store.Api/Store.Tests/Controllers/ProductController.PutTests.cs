using Newtonsoft.Json;
using AutoFixture;
using Store.DataAccess.Entities;
using Store.Models.Products;
using Store.Tests.Utils;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class ProductController_PutTests : BaseTestController
    {
        [Fact]
        public async Task ShouldUpdateProduct()
        {
            var expected = Fixture.Build<Product>().With(t => t.Id, 1).Create();
            Context.Products.Add(expected);
            Context.SaveChanges();

            // Act
            expected.Code = "123456";
            expected.Description = "New desc";
            var response = await Client.PutAsync($"api/Product", new JsonContent(expected));
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonConvert.DeserializeObject<ProductDto>(jsonResult);
            var actual = Context.Products.Find(deserializedResponse.Id);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }
    }
}