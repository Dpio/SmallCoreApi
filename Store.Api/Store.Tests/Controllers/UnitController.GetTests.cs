using Newtonsoft.Json;
using AutoFixture;
using Store.DataAccess.Entities;
using Store.Models.Units;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class UnitController_GetTests : BaseTestController
    {
        [Fact]
        public async Task ShouldGetUnit()
        {
            var expected = Fixture.Build<Unit>().With(t => t.Id, 1).Create();
            Context.Units.Add(expected);
            Context.SaveChanges();

            // Act
            var id = 1;
            var response = await Client.GetAsync($"api/Unit/{id}");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<UnitDto>(jsonResult);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }
    }
}