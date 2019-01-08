using MealPlanner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Core.Entities.RecipeAggregate
{
    public class Ingredient : BaseEntity
    {
        public Food Food { get; set; }
        public int Amount { get; set; }
        public Measurement Measurement { get; set; }
    }
}
