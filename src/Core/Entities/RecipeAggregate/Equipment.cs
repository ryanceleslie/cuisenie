
using System.Collections.Generic;

namespace Core.Entities.RecipeAggregate
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        private List<RecipeEquipment> _recipes { get; set; }
        public IEnumerable<RecipeEquipment> Recipes => _recipes;
        public Equipment() { }

        public Equipment(List<RecipeEquipment> recipes)
        {
            _recipes = recipes;
        }
    }
}
