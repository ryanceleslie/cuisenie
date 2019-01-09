using Ardalis.GuardClauses;
using MealPlanner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Core.Entities.RecipeAggregate
{
    public class Recipe : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public int Servings { get; set; }
        public int Rating { get; set; }
        public TimeSpan Prep { get; set; }
        public TimeSpan Cook { get; set; }
        public TimeSpan Ready { get; set; }
        public string ExternalUrl { get; set; }

        private List<Ingredient> _ingredients = new List<Ingredient>();
        public IEnumerable<Ingredient> Ingredients => _ingredients;

        private List<Instruction> _instructions = new List<Instruction>();
        public IEnumerable<Instruction> Instructions => _instructions;

        public Recipe()
        {

        }

        public Recipe(int rating) : this()
        {
            Guard.Against.OutOfRange(rating, nameof(rating), 1, 5);
            Rating = rating;
        }
    }
}
