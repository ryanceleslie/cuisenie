using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Services
{
    public class RecipeService
    {
        //TODO this service is deprecated in favor of direct SQL access in the Blazor app, instead of an API
        private readonly HttpClient _client;
        public RecipeService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            var bearerToken = httpContextAccessor.HttpContext.Request
                              .Headers["Authorization"]
                              .FirstOrDefault(h => h.StartsWith("bearer ", StringComparison.InvariantCultureIgnoreCase));

            var temp = httpContextAccessor.HttpContext.Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"];

            // Add authorization if found
            if (bearerToken != null)
                client.DefaultRequestHeaders.Add("Authorization", bearerToken);

            // Or the value from httpClientSettings:
            // client.DefaultRequestHeaders.Add("Authorization", httpClientSettings.BearerToken);

            //client.DefaultRequestHeaders.Add("Authorization", bearerToken);

            client.BaseAddress = new Uri("https://cuisenie-api-test.azurewebsites.net");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", httpContextAccessor.HttpContext.Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"]);

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