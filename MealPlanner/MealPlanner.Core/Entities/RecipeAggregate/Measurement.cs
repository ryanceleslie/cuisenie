using MealPlanner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Core.Entities.RecipeAggregate
{
    public class Measurement // ValueObject
    {
        public string Type { get; set; }

        public Measurement() { }

        public Measurement(string type)
        {
            Type = type;
        }
    }
}
