using Newtonsoft.Json;
using AutoFixture;
using Store.DataAccess.Entities;
using Store.Models.Units;
using Store.Tests.Utils;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class UnitController_PutTests : BaseTestController
    {
        [Fact]
        public async Task ShouldUpdateUnit()
        {
            var expected = Fixture.Build<Unit>().With(t => t.Id, 1).Create();
            Context.Units.Add(expected);
            Context.SaveChanges();

            // Act
            expected.Code = "123456";
            expected.Description = "New desc";
            var response = await Client.PutAsync($"api/Unit", new JsonContent(expected));
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonConvert.DeserializeObject<UnitDto>(jsonResult);
            var actual = Context.Units.Find(deserializedResponse.Id);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }
    }
}