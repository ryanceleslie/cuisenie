using MealPlanner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Core.Entities.RecipeAggregate
{
    public class Instruction // ValueObject
    {
        public int Step { get; set; }
        public string Description { get; set; }

        public Instruction() { }

        public Instruction(int step, string description)
        {
            Step = step;
            Description = description;
        }
    }
}
