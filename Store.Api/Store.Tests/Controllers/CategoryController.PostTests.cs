using Newtonsoft.Json;
using AutoFixture;
using Store.Models.Categories;
using Store.Tests.Utils;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class CategoryController_PostTests : BaseTestController
    {
        [Fact]
        public async Task ShouldAddCategory()
        {
            var expected = Fixture.Build<CreateCategoryDto>().With(t => t.Code, "001").Create();

            // Act
            var response = await Client.PostAsync("api/Category", new JsonContent(expected));
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var deserializeObject = JsonConvert.DeserializeObject<CategoryDto>(jsonResult);
            var actual = Context.Categories.Find(deserializeObject.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }
    }
}