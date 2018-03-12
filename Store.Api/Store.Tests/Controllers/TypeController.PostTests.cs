using Newtonsoft.Json;
using AutoFixture;
using Store.Models.Types;
using Store.Tests.Utils;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class TypeController_PostTests : BaseTestController
    {
        [Fact]
        public async Task ShouldAddProduct()
        {
            var expected = Fixture.Build<CreateTypeDto>().With(t => t.Code, "001").Create();

            // Act
            var response = await Client.PostAsync("api/Type", new JsonContent(expected));
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var deserializeObject = JsonConvert.DeserializeObject<TypeDto>(jsonResult);
            var actual = Context.Types.Find(deserializeObject.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }
    }
}