using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.RecipeAggregate
{
    public class Ingredient : BaseEntity
    {
        public decimal Quantity { get; set; }
        public string Measurement { get; private set; }
        public Food Food { get; set; }
        public string Description { get; set; }

        public IEnumerable<Nutrition> TotalNutrition()
        {
            var total = new List<Nutrition>();

            //TODO this may not work, need to test
            total.AddRange(
                Food.Nutrition.Select(n => { n.Value = Quantity * n.Value; return n; })
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
