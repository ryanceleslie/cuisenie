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
        public async Task Get_Returns_Recipes()
        {
            // Act
            var response = await Client.GetAsync("/recipe");
            response.EnsureSuccessStatusCode();
            var streamResponse = await response.Content.ReadAsStreamAsync();

            var act = await JsonSerializer.DeserializeAsync<IEnumerable<Recipe>>(streamResponse);

            // Assert
            act.Should().BeOfType<List<Recipe>>();
        }

        #endregion

        #region Get(int id)

        //TODO temporarily deactivating this test since the DB is empty
        //[Fact]
        //public async Task Get_By_Id_Returns_Type_And_Recipe()
        //{
        //    // Act
        //    var response = await Client.GetAsync("/recipe/2");
        //    response.EnsureSuccessStatusCode();
        //    var streamResponse = await response.Content.ReadAsStreamAsync();

        //    var act = await JsonSerializer.DeserializeAsync<Recipe>(streamResponse);

        //    // Assert
        //    act.Should().BeOfType<Recipe>();
        //}

        #endregion

        #region Put
        #endregion

        #region Post
        #endregion

        #region Delete
        #endregion
    }
}
