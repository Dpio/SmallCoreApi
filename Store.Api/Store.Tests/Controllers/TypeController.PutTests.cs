using Newtonsoft.Json;
using AutoFixture;
using Store.DataAccess.Entities;
using Store.Tests.Utils;
using System.Net;
using System.Threading.Tasks;
using Store.Models.Types;
using Xunit;

namespace Store.Tests.Controllers
{
    public class TypeController_PutTests : BaseTestController
    {
        [Fact]
        public async Task ShouldUpdateType()
        {
            var expected = Fixture.Build<Type>().With(t => t.Id, 1).Create();
            Context.Types.Add(expected);
            Context.SaveChanges();

            // Act
            expected.Code = "123456";
            expected.Description = "New desc";
            var response = await Client.PutAsync($"api/Type", new JsonContent(expected));
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonConvert.DeserializeObject<TypeDto>(jsonResult);
            var actual = Context.Types.Find(deserializedResponse.Id);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Description, actual.Description);
        }
    }
}