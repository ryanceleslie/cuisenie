using Core.Entities.RecipeAggregate;
using Core.Interfaces;
using Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using UnitTests.Builders;
using System.Collections.ObjectModel;

namespace UnitTests.Core.Services
{
    public class RecipeServiceTests
    {
        private Recipe _recipe { get; set; }
        private readonly Mock<IRepository<Recipe>> _repository;
        private readonly RecipeService _service;

        public RecipeServiceTests()
        {
            _recipe = new RecipeBuilder().WithDefaultValues();
            _repository = new Mock<IRepository<Recipe>>();
            _service = new RecipeService(_repository.Object, new Mock<IAppLogger<Recipe>>().Object);
        }

        #region New

        [Fact]
        public async Task New_Recipe_Returns_Nothing()
        {
            // Arrange
            var mockRecipe = _recipe;
            _repository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(mockRecipe));

            // Act
            await _service.New(mockRecipe);

            // Assert
            _repository.Verify(x => x.Add(It.Is<Recipe>(y => y == mockRecipe)));
        }

        #endregion

        #region Edit

        [Fact]
        public async Task Edit_Recipe_Returns_Nothing()
        {
            // Arrage
            _recipe.ModifiedBy = "differentUser";
            var mockRecipe = _recipe;
            _repository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(mockRecipe));

            // Act
            await _service.Edit(mockRecipe);

            // Assert
            _repository.Verify(x => x.Update(It.Is<Recipe>(y => y == mockRecipe)));
        }

        #endregion

        #region Remove

        [Fact]
        public async Task Remove_Recipe_Returns_Nothing()
        {
            // Arrange
            var mockRecipe = _recipe;
            _repository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(mockRecipe));

            // Act
            await _service.Remove(mockRecipe);

            // Assert
            _repository.Verify(x => x.Delete(It.Is<Recipe>(y => y == mockRecipe)));
        }

        #endregion

        #region Get

        [Fact]
        public async Task Get_By_Id_Returns_Type_And_Recipe()
        {
            // Arrange
            var id = 1;
            var mockRecipe = _recipe;
            _repository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(mockRecipe));

            // Act
            var act = await _service.Get(id);

            // Assert
            act.Should().BeOfType<Recipe>().And.BeEquivalentTo(mockRecipe);
        }

        #endregion

        #region GetAll

        [Fact]
        public async Task GetAll_Returns_Recipes()
        {
            // Arrange
            var mockRecipes = new List<Recipe>() { _recipe };
            IReadOnlyList<Recipe> readOnlyList = mockRecipes;

            _repository.Setup(r => r.ListAll())
                .Returns(Task.FromResult(readOnlyList));

            // Act
            var act = await _service.GetAll();

            // Assert
            act.Should().BeEquivalentTo(mockRecipes);
        }

        #endregion
    }
}
