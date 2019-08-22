using Core.Entities.RecipeAggregate;
using Core.Entities.SuggestionAggregate;
using Core.Specifications;
using System;

namespace UnitTests.Builders
{
    public class SuggestionBuilder
    {
        // Starting with recipe preferences
        private RecipePreference _recipePreference;

        public int TestId => 1;
        public string TestCreatedBy => "createdByUser";
        public string TestModifiedBy => "modifiedByUser";
        public Recipe TestRecipe => new RecipeBuilder().WithDefaultValues();
        public int TestRating => 4;
        public TimeSpan TestFrequency => TimeSpan.FromDays(30);
        public string TestUser = "admin";

        public SuggestionBuilder()
        {
            _recipePreference = WithDefaultRecipePreferences();
        }

        public RecipePreference WithDefaultRecipePreferences()
        {
            _recipePreference = new RecipePreference()
            {
                Id = TestId,
                CreatedBy = TestCreatedBy,
                ModifiedBy = TestModifiedBy,
                Recipe = TestRecipe,
                Rating = TestRating,
                Frequency = TestFrequency,
                User = TestUser
            };

            return _recipePreference;
        }
    }

    public class RecipePreferenceSpecificationBuilder : BaseSpecification<Recipe>
    {
        public RecipePreferenceSpecificationBuilder(int id) : base(x => x.Id == id) { }
    }
}
