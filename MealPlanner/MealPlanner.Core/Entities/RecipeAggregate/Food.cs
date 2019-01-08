using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Core.Entities.RecipeAggregate
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        public int ShiptId { get; set; }
        public string BrandName { get; set; }
    }
}
