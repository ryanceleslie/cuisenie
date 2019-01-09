using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.RecipeAggregate
{
    public class Ingredient : BaseEntity
    {
        public int Quantity { get; set; }
        public Food Food { get; set; }
        public string Description { get; set; }

        // I think this belong here and not the Food type, this may change
        public int ServingSize { get; set; }
        public Measurement Measurement { get; set; }

        private readonly List<Nutrition> _nutrition = new List<Nutrition>();
        public IReadOnlyCollection<Nutrition> Nutrition => _nutrition.AsReadOnly();

        public IReadOnlyCollection<Nutrition> TotalNutrition()
        {
            var total = new List<Nutrition>();

            total.AddRange(
                _nutrition.Select(n => { n.Value = Quantity * n.Value; return n; })
                .ToList());

            // The above statement should do the same thing as this foreach loop, but test it to make sure it does
            //foreach (var n in _nutrition)
            //{
            //    total.Add(new Nutrition() {
            //        Type = n.Type,
            //        Value = Amount * n.Value
            //    });
            //}

            return total.AsReadOnly();
        }
    }
}
