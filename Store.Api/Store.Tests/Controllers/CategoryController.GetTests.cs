using Newtonsoft.Json;
using AutoFixture;
using Store.DataAccess.Entities;
using Store.Models.Categories;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class CategoryController_GetTests : BaseTestController
    {
        [Fact]
        public async Task ShouldGetCategory()
        {
            var expected = Fixture.Build<Category>().With(t => t.Id, 1).Create();
            Context.Categories.Add(expected);
            Context.SaveChanges();

            // Act
            var id = 1;
            var response = await Client.GetAsync($"api/Category/{id}");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<CategoryDto>(jsonResult);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }
    }
}