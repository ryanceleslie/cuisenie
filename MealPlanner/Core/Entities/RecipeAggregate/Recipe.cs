using Ardalis.GuardClauses;
using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Entities.RecipeAggregate
{
    public class Recipe : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public int Servings { get; set; }
        public TimeSpan Prep { get; set; }
        public TimeSpan Cook { get; set; }
        public TimeSpan Ready { get; set; }
        public string ExternalUrl { get; set; }

        private List<Ingredient> _ingredients = new List<Ingredient>();
        public IEnumerable<Ingredient> Ingredients => _ingredients;

        private List<Instruction> _instructions = new List<Instruction>();
        public IEnumerable<Instruction> Instructions => _instructions;

        public Recipe() { }

        public Recipe(string name, int servings, TimeSpan prep, TimeSpan cook, TimeSpan ready, string externalUrl, List<Ingredient> ingredients, List<Instruction> instructions) : this()
        {
            //TODO likely need to add more guards

            Name = name;
            Servings = servings;
            Prep = prep;
            Cook = cook;
            Ready = ready;
            ExternalUrl = externalUrl;
            _ingredients = ingredients;
            _instructions = instructions;
        }
    }
}
