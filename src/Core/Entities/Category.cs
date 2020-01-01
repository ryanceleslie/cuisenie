
using Core.Entities.RecipeAggregate;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }

        private List<RecipeCategory> _recipes { get; set; }
        public IEnumerable<RecipeCategory> Recipes => _recipes;
        public Category() { }

        public Category(List<RecipeCategory> relatedRecipes)
        {
            _recipes = relatedRecipes;
        }
    }
}
