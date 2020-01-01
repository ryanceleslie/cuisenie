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

        private List<Equipment> _equipment = new List<Equipment>();
        public IEnumerable<Equipment> Equipment => _equipment;

        private List<Ingredient> _ingredients = new List<Ingredient>();
        public IEnumerable<Ingredient> Ingredients => _ingredients;

        private List<Instruction> _instructions = new List<Instruction>();
        public IEnumerable<Instruction> Instructions => _instructions;

        private List<RecipeCategory> _categories = new List<RecipeCategory>();
        public IEnumerable<RecipeCategory> Categories => _categories;

        private List<RelatedRecipe> _relatedRecipes = new List<RelatedRecipe>();
        public IEnumerable<RelatedRecipe> RelatedRecipes => _relatedRecipes;


        public Recipe() { }

        public Recipe(
            string name,
            int servings,
            TimeSpan prep,
            TimeSpan cook,
            TimeSpan ready,
            string externalUrl,
            List<Equipment> equipment,
            List<Ingredient> ingredients,
            List<Instruction> instructions,
            List<RecipeCategory> categories,
            List<RelatedRecipe> relatedRecipes) : this()
        {
            //TODO likely need to add more guards

            Name = name;
            Servings = servings;
            Prep = prep;
            Cook = cook;
            Ready = ready;
            ExternalUrl = externalUrl;
            _equipment = equipment;
            _ingredients = ingredients;
            _instructions = instructions;
            _categories = categories;
            _relatedRecipes = relatedRecipes;
        }
    }
}
