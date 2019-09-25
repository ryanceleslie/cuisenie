using Core.Entities.SuggestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISuggestionService
    {
        Task NewRecipePreference(RecipePreference recipePreference);
        Task EditRecipePreference(RecipePreference recipePreference);
        Task RemoveRecipePreference(RecipePreference recipePreference);
        Task<RecipePreference> GetRecipePreference(int id);
        Task<IReadOnlyList<RecipePreference>> GetAllRecipePreferences();
        Task<IReadOnlyList<RecipePreference>> GetAllRecipePreferencesForUser(string user);

        Task<IReadOnlyList<RecipePreference>> GenerateSuggestionsForUser(string user);
    }
}
