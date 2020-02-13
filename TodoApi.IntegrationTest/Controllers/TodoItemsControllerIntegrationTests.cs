using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using TodoApi.Models;

namespace TodoApi.IntegrationTest.Controllers
{
    public class TodoItemsControllerIntegrationTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        public TodoItemsControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetTodoItemsById()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/TodoItems/1");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var todoItem = JsonConvert.DeserializeObject<TodoItem>(stringResponse);
            Assert.Equal(1,todoItem.Id);
            Assert.Equal("walk dog", todoItem.Name);
        }
    }
}