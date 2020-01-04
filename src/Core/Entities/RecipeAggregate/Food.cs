using System.Collections.Generic;

namespace Core.Entities.RecipeAggregate
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        public int ShiptId { get; set; }
        public string BrandName { get; set; }

        private readonly List<Nutrition> _nutrition = new List<Nutrition>();
        public IEnumerable<Nutrition> Nutrition => _nutrition.AsReadOnly();

        public Food() { }

        public Food(List<Nutrition> nutrition) : this()
        {
            _nutrition = nutrition;
        }
    }
}
