using System.Collections.Generic;

namespace Core.Entities.RecipeAggregate
{
    public class IngredientSet : BaseEntity
    {
        public string Name { get; set; }
        public Recipe Recipe { get; set; }
        private List<Ingredient> _ingredients = new List<Ingredient>();
        public IEnumerable<Ingredient> Ingredients => _ingredients;
        
        public IngredientSet() { }
        
        public IngredientSet(string name, List<Ingredient> ingredients)
        {
            Name = name;
            _ingredients = ingredients;
        }
    }
}