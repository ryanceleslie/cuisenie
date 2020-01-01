using API;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using FluentAssertions;
using Core.Entities.RecipeAggregate;

namespace L2.API.Controllers
{
    [Collection("Sequential")]
    public class RecipeControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }

        public RecipeControllerTest(CustomWebApplicationFactory<Startup> webFactory)
        {
            Client = webFactory.CreateClient();
        }

        #region Get

        [Fact]
        public async Task Get_Recipes()
        {
            // Act
            var response = await Client.GetAsync("/recipe");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStreamAsync();

            var act = await JsonSerializer.DeserializeAsync<IEnumerable<Recipe>>(stringResponse);

            // Assert
            act.Should().BeOfType<List<Recipe>>();
        }

        #endregion

        #region Get(int id)
        #endregion

        #region Put
        #endregion

        #region Post
        #endregion

        #region Delete
        #endregion
    }
}
