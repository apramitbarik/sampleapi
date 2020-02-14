using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using TodoApi.Models;

namespace TodoApi.IntegrationTest.Controllers
{
    public class MathControllerIntegrationTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        public MathControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanAddValue()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/Math/1/1");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<int>(stringResponse);
            Assert.Equal(2,value);
        }
    }
}