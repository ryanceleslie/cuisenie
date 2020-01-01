using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using Newtonsoft.Json;
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
            // Arrange
            var response = await Client.GetAsync("/recipe");
            response.EnsureSuccessStatusCode();
            var tempasdas = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<Recipe>(await response.Content.ReadAsStringAsync());

            var temp = model;

            // Act

            // Assert 
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
