using System.Net.Http;
using AutoFixture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Store.Api;
using Store.DataAccess;
using Store.Tests.Utils;

namespace Store.Tests.Controllers
{
    public abstract class BaseTestController
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;
        protected readonly ApplicationDbContext Context;
        protected readonly IFixture Fixture;


        protected BaseTestController()
        {
            // Arrange
            Server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>());
            Context = Server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            Client = Server.CreateClient();
            Fixture = new Fixture().WithStandardCustomization();
        }
    }
}