using Core.Entities.RecipeAggregate;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seed
{
    public class RecipeSeed
    {
        private static DbSet<Recipe> _recipes { get; set; }
        private static DbSet<Food> _food { get; set; }
        private static DbSet<Ingredient> _ingredients { get; set; }
        private static DbSet<Instruction> _instructions { get; set; }

        public static async Task SeedAsync(CuisenieContext context, IAppLogger<RecipeSeed> logger, int? retry = 0)
        {
            var retryForAvailability = retry.Value;

            try
            {
                _recipes = context.Recipes;
                _food = context.Food;
                _ingredients = context.Ingredients;
                _instructions = context.Instructions;

                // Add base recipe data
                if (!_recipes.Any())
                {
                    _recipes.AddRange(GetPreconfiguredRecipes());
                    await context.SaveChangesAsync();
                }

                // Add base food
                if (!_food.Any())
                {
                    _food.AddRange(GetPreconfiguredFood());
                    await context.SaveChangesAsync();
                }

                // Add base ingredients
                if (!_ingredients.Any() && _recipes.Any())
                {
                    _ingredients.AddRange(GetPreconfiguredIngredients());
                    await context.SaveChangesAsync();
                }

                // Add base instructions
                if (!_instructions.Any() && _recipes.Any())
                {
                    _instructions.AddRange(GetPreconfiguredInstructions());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    logger.Error(ex, ex.Message);
                    await SeedAsync(context, logger, retryForAvailability);
                }
            }
        }

        public static IEnumerable<Recipe> GetPreconfiguredRecipes()
        {
            return new List<Recipe>()
            {
                new Recipe() { Name = "Test 0", Servings = 4 },
                new Recipe() { Name = "Test 1", Servings = 2 },
                new Recipe() { Name = "Test 2", Servings = 3 },
                new Recipe() { Name = "Test 3", Servings = 6 }
            }.Select(_ =>
            {
                _.CreatedBy = "Ryan";
                _.ModifiedBy = "Ryan Again";
                _.Prep = TimeSpan.FromHours(1);
                _.Cook = TimeSpan.FromHours(1);
                _.ExternalUrl = "http://www.google.com";
                return _;
            });
        }

        public static IEnumerable<Food> GetPreconfiguredFood()
        {
            return new List<Food>()
            {
                new Food() { Name = "Chicken Breast", BrandName = "Tyson" },
                new Food() { Name = "Tortilla", BrandName = "Mission" },
                new Food() { Name = "Olive Oil", BrandName = "Pompeian" },
                new Food() { Name = "Spring Onion" },
                new Food() { Name = "Cabbage" },
                new Food() { Name = "Ginger" },
                new Food() { Name = "Garlic" }
            }.Select(_ =>
            {
                _.CreatedBy = "Ryan";
                _.ModifiedBy = "Ryan Again";
                return _;
            });
        }

        public static IEnumerable<Ingredient> GetPreconfiguredIngredients()
        {
            return (from recipe in _recipes.ToList()
                    from ingredient in new List<Ingredient>() 
                    {
                        new Ingredient() { Quantity = 4, Food = _food.FirstOrDefault(f => f.Name == "Chicken Breast"), Description = "skinless" },
                        new Ingredient() { Quantity = 3, Food = _food.FirstOrDefault(f => f.Name == "Tortilla") },
                        new Ingredient() { Quantity = 1, Food = _food.FirstOrDefault(f => f.Name == "Olive Oil"), Description = "for frying" },
                        new Ingredient() { Quantity = 1, Food = _food.FirstOrDefault(f => f.Name == "Spring Onion"), Description = "finely shredded" },
                        new Ingredient() { Quantity = 0.5m, Food = _food.FirstOrDefault(f => f.Name == "Cabbage"), Description = "finely shredded" },
                        new Ingredient() { Quantity = 0.5m, Food = _food.FirstOrDefault(f => f.Name == "Ginger"), Description = "ground" },
                        new Ingredient() { Quantity = 0.5m, Food = _food.FirstOrDefault(f => f.Name == "Garlic"), Description = "minced" }
                    }
                    .Select(_ =>
                    {
                        _.CreatedBy = "Ryan";
                        _.ModifiedBy = "Ryan Again";
                        _.Recipe = recipe;
                        return _;
                    })
                    select ingredient
                );
        }

        public static IEnumerable<Instruction> GetPreconfiguredInstructions()
        {
            return (from recipe in _recipes.ToList()
                    from instruction in new List<Instruction>() 
                    {
                        new Instruction() { Step = 100, Description = "First make the marinade." },
                        new Instruction() { Step = 200, Description = "Preheat the oven to 400 degrees" },
                        new Instruction() { Step = 300, Description = "Heat a griddle pan over a medium heat" },
                    }
                    .Select(_ =>
                    {
                        _.CreatedBy = "Ryan";
                        _.ModifiedBy = "Ryan Again";
                        _.Recipe = recipe;
                        return _;
                    })
                    select instruction
                );
        }
    }
}
