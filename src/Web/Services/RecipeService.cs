using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Services
{
    public class RecipeService
    {
        private readonly HttpClient _client;
        public RecipeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<string>> GetAll()
        {
            var response = await _client.GetAsync("recipe");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var temp = await JsonSerializer.DeserializeAsync<IEnumerable<string>>(responseStream);

            return temp;
        }
    }
}