using Core.Entities.RecipeAggregate;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> _repository;
        private ILogger<Recipe> _logger;

        public RecipeService(IRepository<Recipe> repository, ILogger<Recipe> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task New(Recipe recipe)
        {
            _logger.LogInformation("Core.Services.RecipeService: New()");

            await _repository.Add(recipe);
        }

        public async Task Edit(Recipe recipe)
        {
            _logger.LogInformation("Core.Services.RecipeService: Edit()");

            await _repository.Update(recipe);
        }
        
        public async Task Remove(Recipe recipe)
        {
            _logger.LogInformation("Core.Services.RecipeService: Remove()");

            await _repository.Delete(recipe);
        }

        public async Task<Recipe> Get(int id)
        {
            _logger.LogInformation("Core.Services.RecipeService: Get(int id)");

            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            _logger.LogInformation("Core.Services.RecipeService: GetAll()");

            return await _repository.ListAll();
        }
    }
}
