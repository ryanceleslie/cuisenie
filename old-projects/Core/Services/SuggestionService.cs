using Core.Entities.SuggestionAggregate;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly IRepository<RecipePreference> _recipePreferenceRepository;
        private IAppLogger<RecipePreference> _recipePreferenceLogger;

        public SuggestionService(IRepository<RecipePreference> recipePreferenceRepository, IAppLogger<RecipePreference> recipePreferenceLogger)
        {
            _recipePreferenceRepository = recipePreferenceRepository;
            _recipePreferenceLogger = recipePreferenceLogger;
        }

        public async Task NewRecipePreference(RecipePreference recipePreference)
        {
            _recipePreferenceLogger.Information("Core.Services.SuggestionService: NewRecipePreference()");

            await _recipePreferenceRepository.Add(recipePreference);
        }

        public async Task EditRecipePreference(RecipePreference recipePreference)
        {
            _recipePreferenceLogger.Information("Core.Services.SuggestionService: EditRecipePreference()");

            await _recipePreferenceRepository.Update(recipePreference);
        }
        public async Task RemoveRecipePreference(RecipePreference recipePreference)
        {
            _recipePreferenceLogger.Information("Core.Services.SuggestionService: RemoveRecipePreference()");

            await _recipePreferenceRepository.Delete(recipePreference);
        }

        public async Task<RecipePreference> GetRecipePreference(int id)
        {
            _recipePreferenceLogger.Information("Core.Services.RecipeService: GetRecipePreference(int id)");

            return await _recipePreferenceRepository.GetById(id);
        }

        public async Task<IReadOnlyList<RecipePreference>> GetAllRecipePreferences()
        {
            _recipePreferenceLogger.Information("Core.Services.RecipeService: GetAllRecipePreferences()");

            return await _recipePreferenceRepository.ListAll();
        }

        public async Task<IReadOnlyList<RecipePreference>> GetAllRecipePreferencesForUser(string user)
        {
            //TODO add code
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<RecipePreference>> GenerateSuggestionsForUser(string user)
        {
            //TODO add code
            throw new NotImplementedException();
        }
    }
}
