using Newtonsoft.Json;
using AutoFixture;
using Store.Models.Units;
using Store.Tests.Utils;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class UnitController_PostTests : BaseTestController
    {
        [Fact]
        public async Task ShouldAddUnit()
        {
            var expected = Fixture.Build<CreateUnitDto>().With(t => t.Code, "001").Create();

            // Act
            var response = await Client.PostAsync("api/Unit", new JsonContent(expected));
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var deserializeObject = JsonConvert.DeserializeObject<UnitDto>(jsonResult);
            var actual = Context.Units.Find(deserializeObject.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }
    }
}