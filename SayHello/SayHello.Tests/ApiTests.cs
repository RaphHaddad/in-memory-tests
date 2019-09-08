using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SayHello.Tests
{
    public class ApiTests: IClassFixture<WebApplicationFactory<SayHello.Web.Startup>>
    {
        private readonly WebApplicationFactory<SayHello.Web.Startup> factory;

        public ApiTests(WebApplicationFactory<SayHello.Web.Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task ShouldGoToHelloPage()
        {
            var client = this.factory.CreateClient();

            var response = await client.GetAsync("/SayHello/eng");

            response.EnsureSuccessStatusCode();
        }
    }
}
