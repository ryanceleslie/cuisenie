using Core.Entities.SuggestionAggregate;
using Core.Interfaces;
using Core.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Builders;
using Xunit;

namespace UnitTests.Core.Services
{
    public class SuggestionServiceTests
    {
        private RecipePreference _recipePreference { get; set; }
        private readonly Mock<IRepository<RecipePreference>> _recipePreferenceRepository;
        private readonly SuggestionService _service;

        public SuggestionServiceTests()
        {
            _recipePreference = new SuggestionBuilder().WithDefaultRecipePreferences();
            _recipePreferenceRepository = new Mock<IRepository<RecipePreference>>();
            _service = new SuggestionService(_recipePreferenceRepository.Object, new Mock<IAppLogger<RecipePreference>>().Object);
        }

        #region NewRecipePreference

        [Fact]
        public async Task New_RecipePreference_Returns_Nothing()
        {
            // Arrange
            var mockRecipePreference = _recipePreference;
            _recipePreferenceRepository.Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(mockRecipePreference));

            // Act
            await _service.NewRecipePreference(mockRecipePreference);

            // Assert
            _recipePreferenceRepository.Verify(x => x.Add(It.Is<RecipePreference>(y => y == mockRecipePreference)));
        }

        #endregion

        #region EditRecipePreference

        [Fact]
        public async Task Edit_RecipePreference_Returns_Nothing()
        {
            // Arrange
            _recipePreference.ModifiedBy = "differentUser";
            var mockRecipePreference = _recipePreference;
            _recipePreferenceRepository.Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(mockRecipePreference));

            // Act
            await _service.EditRecipePreference(mockRecipePreference);

            // Assert
            _recipePreferenceRepository.Verify(x => x.Update(It.Is<RecipePreference>(y => y == mockRecipePreference)));
        }

        #endregion

        #region RemoveRecipePreference

        [Fact]
        public async Task Remove_RecipePreference_Returns_Nothing()
        {
            // Arrange
            var mockRecipePreference = _recipePreference;
            _recipePreferenceRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(mockRecipePreference));

            // Act
            await _service.RemoveRecipePreference(mockRecipePreference);

            // Assert
            _recipePreferenceRepository.Verify(x => x.Delete(It.Is<RecipePreference>(y => y == mockRecipePreference)));
        }

        #endregion

        #region GetAllRecipePreferences

        [Fact]
        public async Task GetAll_Returns_Recipes()
        {
            // Arrange
            var mockRecipePreferences = new List<RecipePreference>() { _recipePreference };
            IReadOnlyList<RecipePreference> readOnlyList = mockRecipePreferences;

            _recipePreferenceRepository.Setup(r => r.ListAll())
                .Returns(Task.FromResult(readOnlyList));

            // Act
            var act = await _service.GetAllRecipePreferences();

            // Assert
            act.Should().BeEquivalentTo(mockRecipePreferences);
        }

        #endregion

        #region GetAllRecipePreferencesForUser
        //TODO add test
        #endregion

        #region GenerateSuggestionsForUser
        //TODO add test
        #endregion

    }
}
