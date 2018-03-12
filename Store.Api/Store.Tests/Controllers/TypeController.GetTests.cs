using Newtonsoft.Json;
using AutoFixture;
using Store.DataAccess.Entities;
using Store.Models.Types;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Store.Tests.Controllers
{
    public class TypeController_GetTests : BaseTestController
    {
        [Fact]
        public async Task ShouldGetType()
        {
            var expected = Fixture.Build<Type>().With(t => t.Id, 1).Create();
            Context.Types.Add(expected);
            Context.SaveChanges();

            // Act
            var id = 1;
            var response = await Client.GetAsync($"api/Type/{id}");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<TypeDto>(jsonResult);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }
    }
}