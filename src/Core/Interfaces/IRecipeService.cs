using Core.Entities.RecipeAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRecipeService
    {
        Task New(Recipe recipe);
        Task Edit(Recipe recipe);
        Task Remove(Recipe recipe);
        Task<Recipe> Get(int id);
        Task<IReadOnlyList<Recipe>> GetAll();
    }
}
