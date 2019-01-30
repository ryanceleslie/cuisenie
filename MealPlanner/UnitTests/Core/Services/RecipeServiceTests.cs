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

namespace UnitTests.Core.Services
{
    public class RecipeServiceTests
    {
        private Recipe _recipe { get; set; }
        private readonly Mock<IRepository<Recipe>> _repository;
        private readonly RecipeService _service;

        public RecipeServiceTests()
        {
            _recipe = new RecipeBuilder().WithDefaultValues(); //TODO add recipe builder
            _repository = new Mock<IRepository<Recipe>>();
            _service = new RecipeService(_repository.Object, new Mock<IAppLogger<Recipe>>().Object);
        }

        #region New

        [Fact]
        public async Task New_Recipe_ReturnsNothing()
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
        #endregion

        #region Remove
        #endregion

        #region Get
        #endregion

        #region GetAll
        #endregion
    }
}
