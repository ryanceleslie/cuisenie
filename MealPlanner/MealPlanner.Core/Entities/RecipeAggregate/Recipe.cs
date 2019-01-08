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

        private readonly List<Ingredient> _ingredients = new List<Ingredient>();
        public IReadOnlyCollection<Ingredient> Ingredients => _ingredients.AsReadOnly();

        private readonly List<Instruction> _instructions = new List<Instruction>();
        public IReadOnlyCollection<Instruction> Instructions => _instructions.AsReadOnly();

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
