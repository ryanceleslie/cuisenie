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
        private static DbSet<IngredientSet> _ingredientSets { get; set; }
        private static DbSet<Instruction> _instructions { get; set; }
        private static DbSet<InstructionSet> _instructionSets { get; set; }

        public static async Task SeedAsync(CuisenieContext context, IAppLogger<RecipeSeed> logger)
        {
            try
            {
                _recipes = context.Recipes;
                _ingredientSets = context.IngredientSets;
                _instructionSets = context.InstructionSets;
                _food = context.Food;
                _ingredients = context.Ingredients;
                _instructions = context.Instructions;

                // Add base recipe data
                if (!_recipes.Any())
                {
                    _recipes.AddRange(GetPreconfiguredRecipes());
                    await context.SaveChangesAsync();
                }

                // Add base ingredient sets
                if (!_ingredientSets.Any() && _recipes.Any())
                {
                    _ingredientSets.AddRange(GetPreconfiguredIngredientSets());
                    await context.SaveChangesAsync();
                }

                // Add base instruction sets
                if (!_instructionSets.Any() && _recipes.Any())
                {
                    _instructionSets.AddRange(GetPreconfiguredInstructionSets());
                    await context.SaveChangesAsync();
                }
                
                // Add base food
                if (!_food.Any())
                {
                    _food.AddRange(GetPreconfiguredFood());
                    await context.SaveChangesAsync();
                }

                // Add base ingredients
                if (!_ingredients.Any() && _ingredientSets.Any())
                {
                    _ingredients.AddRange(GetPreconfiguredIngredients());
                    await context.SaveChangesAsync();
                }

                // Add base instructions
                if (!_instructions.Any() && _instructionSets.Any())
                {
                    _instructions.AddRange(GetPreconfiguredInstructions());
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
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
                _.PictureUrl = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";
                _.VideoUrl = "https://www.youtube.com/watch?v=gBJjRYk0yC0";
                return _;
            });
        }

        public static IEnumerable<IngredientSet> GetPreconfiguredIngredientSets()
        {
            return (from recipe in _recipes.ToList()
                    from ingredientSet in new List<IngredientSet>()
                    {
                        new IngredientSet() { Name = "Base", Recipe = recipe },
                        new IngredientSet() { Name = "Dressing", Recipe = recipe }
                    }
                    .Select(_ => 
                    {
                        _.CreatedBy = "Ryan";
                        _.ModifiedBy = "Ryan Again";
                        return _;
                    })
                    select ingredientSet
            );
        }

        public static IEnumerable<InstructionSet> GetPreconfiguredInstructionSets()
        {
            return (from recipe in _recipes.ToList()
                    from instructionSet in new List<InstructionSet>()
                    {
                        new InstructionSet() { Name = "Base", Recipe = recipe },
                        new InstructionSet() { Name = "Dressing", Recipe = recipe }
                    }
                    .Select(_ => 
                    {
                        _.CreatedBy = "Ryan";
                        _.ModifiedBy = "Ryan Again";
                        return _;
                    })
                    select instructionSet
            );
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
            return (from ingredientSet in _ingredientSets.ToList()
                    from ingredient in new List<Ingredient>() 
                    {
                        new Ingredient() { Quantity = 4, Measurement = "oz", Food = _food.FirstOrDefault(f => f.Name == "Chicken Breast"), Description = "skinless" },
                        new Ingredient() { Quantity = 3, Measurement = "lb", Food = _food.FirstOrDefault(f => f.Name == "Tortilla") },
                        new Ingredient() { Quantity = 1, Measurement = "mg", Food = _food.FirstOrDefault(f => f.Name == "Olive Oil"), Description = "for frying" },
                        new Ingredient() { Quantity = 1, Measurement = "lb", Food = _food.FirstOrDefault(f => f.Name == "Spring Onion"), Description = "finely shredded" },
                        new Ingredient() { Quantity = 0.5m, Measurement = "oz", Food = _food.FirstOrDefault(f => f.Name == "Cabbage"), Description = "finely shredded" },
                        new Ingredient() { Quantity = 0.5m, Measurement = "g", Food = _food.FirstOrDefault(f => f.Name == "Ginger"), Description = "ground" },
                        new Ingredient() { Quantity = 0.5m, Measurement = "oz", Food = _food.FirstOrDefault(f => f.Name == "Garlic"), Description = "minced" }
                    }
                    .Select(_ =>
                    {
                        _.CreatedBy = "Ryan";
                        _.ModifiedBy = "Ryan Again";
                        _.IngredientSet = ingredientSet;
                        return _;
                    })
                    select ingredient
                );
        }

        public static IEnumerable<Instruction> GetPreconfiguredInstructions()
        {
            return (from instructionSet in _instructionSets.ToList()
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
                        _.InstructionSet = instructionSet;
                        return _;
                    })
                    select instruction
                );
        }
    }
}
