using System;
using System.Threading.Tasks;
using Core.Interfaces;
using System.Collections.Generic;
using Core.Entities.RecipeAggregate;
using System.Linq;
using Core.Entities.RecipeAggregate.Joiners;
using Core.Entities;

namespace Infrastructure.Data.Seed
{
    public class RecipeSeed
    {
        public static async Task SeedAsync(CuisenieContext context, IAppLogger<RecipeSeed> logger, int? retry = 0)
        {
            var retryForAvailability = retry.Value;

            try
            {
                // Add base recipe data
                if (!context.Recipes.Any())
                {
                    context.Recipes.AddRange(GetPreconfiguredRecipes());
                    await context.SaveChangesAsync();
                }

                // Add base equipment
                if (!context.Equipment.Any())
                {
                    context.Equipment.AddRange(GetPreconfiguredEquipment());
                    await context.SaveChangesAsync();
                }

                // Add to RecipeEquipment
                if (!context.RecipeEquipment.Any() && context.Recipes.Any() && context.Equipment.Any())
                {
                    context.RecipeEquipment.AddRange(GetPreconfiguredRecipeEquipment());
                    await context.SaveChangesAsync();
                }

                // Add base ingredients

                // Add base food
                // Add base nutrion
                // Add base instructions

                // Add base categories

                // Add related recipes

                // Add joiner recipe data


                await context.SaveChangesAsync();
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
                new Recipe() { Name = "Test 3", Servings = 6 },
                new Recipe() { Name = "Test 4", Servings = 5 },
                new Recipe() { Name = "Test 5", Servings = 1 },
                new Recipe() { Name = "Test 6", Servings = 2 },
                new Recipe() { Name = "Test 7", Servings = 3 },
                new Recipe() { Name = "Test 8", Servings = 4 }
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

        public static IEnumerable<Equipment> GetPreconfiguredEquipment()
        {
            return new List<Equipment>()
            {
                new Equipment() { Name = "12\" frying pan" },
                new Equipment() { Name = "3 qt pot" },
                new Equipment() { Name = "Whisk" },
                new Equipment() { Name = "Strainer" },
                new Equipment() { Name = "8 qt mixing bowl"},
                new Equipment() { Name = "Making Sheet" }
            }.Select(_ =>
            {
                _.CreatedBy = "Ryan";
                _.ModifiedBy = "Ryan Again";
                return _;
            });
        }
        public static IEnumerable<RecipeEquipment> GetPreconfiguredRecipeEquipment()
        {
            var temp = from recipe in GetPreconfiguredRecipes()
                       from equipment in GetPreconfiguredEquipment()
                       select new RecipeEquipment() { RecipeId = recipe.Id, EquipmentId = equipment.Id };

            return temp.ToList();
        }

        public static IEnumerable<Ingredient> GetPreconfiguredIngredients()
        {
            return new List<Ingredient>()
            {
                new Ingredient() { Quantity = 4, Food = GetPreconfiguredFood().ElementAt(0), Description = "skinless" },
                new Ingredient() { Quantity = 3, Food = GetPreconfiguredFood().ElementAt(1) },
                new Ingredient() { Quantity = 1, Food = GetPreconfiguredFood().ElementAt(2), Description = "for frying" },
                new Ingredient() { Quantity = 1, Food = GetPreconfiguredFood().ElementAt(3), Description = "finely shredded" },
                new Ingredient() { Quantity = 0.5m, Food = GetPreconfiguredFood().ElementAt(5), Description = "finely shredded" },
                new Ingredient() { Quantity = 0.5m, Food = GetPreconfiguredFood().ElementAt(6), Description = "ground" },
                new Ingredient() { Quantity = 0.5m, Food = GetPreconfiguredFood().ElementAt(7), Description = "ground" },
                new Ingredient() { Quantity = 0.5m, Food = GetPreconfiguredFood().ElementAt(8), Description = "ground" },
                new Ingredient() { Quantity = 0.5m, Food = GetPreconfiguredFood().ElementAt(9), Description = "minced" }
            }.Select(_ =>
            {
                _.CreatedBy = "Ryan";
                _.ModifiedBy = "Ryan Again";
                return _;
            });
        }

        public static IEnumerable<Food> GetPreconfiguredFood()
        {
            return new List<Food>() 
            {
                new Food() { Name = "Chicken Breast", BrandName = "Tyson" }, // 0
                new Food() { Name = "Tortilla Wraps", BrandName = "Mission" }, // 1
                new Food() { Name = "Olive Oil", BrandName = "Pompeian" }, // 2
                new Food() { Name = "Spring Onion" }, // 3
                new Food() { Name = "White Onion" }, // 4
                new Food() { Name = "Cabbage" }, // 5
                new Food() { Name = "Cinnamon" }, // 6
                new Food() { Name = "Ginger" }, // 7
                new Food() { Name = "Coriander" }, // 8
                new Food() { Name = "Garlic" } // 9
            }.Select(_ =>
            {
                _.CreatedBy = "Ryan";
                _.ModifiedBy = "Ryan Again";
                return _;
            });
        }

        public static IEnumerable<Nutrition> GetPreconfiguredNutrion()
        {
            return new List<Nutrition>()
            {
                new Nutrition() { Value = 125, Measurement = "", Type = "Calories" },
                new Nutrition() { Value = 1.5m, Measurement = "g", Type = "Saturated fat" },
                new Nutrition() { Value = 120, Measurement = "mg", Type = "Cholesterol" },
                new Nutrition() { Value = 104, Measurement = "mg", Type = "Sodium" },
                new Nutrition() { Value = 40, Measurement = "g", Type = "Protien" },
                new Nutrition() { Value = 0, Measurement = "g", Type = "Fiber" },
                new Nutrition() { Value = 0, Measurement = "g", Type = "Carbohydrate" }
            }.Select(_ =>
            {
                _.CreatedBy = "Ryan";
                _.ModifiedBy = "Ryan Again";
                return _;
            });
        }

        public static IEnumerable<Instruction> GetPreconfiguredInstructions()
        {
            return new List<Instruction>()
            {
                new Instruction() { Step = 100, Description = "First make the marinade." },
                new Instruction() { Step = 200, Description = "Preheat the oven to 400 degrees" },
                new Instruction() { Step = 300, Description = "Heat a griddle pan over a medium heat" },
            }.Select(_ =>
            {
                _.CreatedBy = "Ryan";
                _.ModifiedBy = "Ryan Again";
                return _;
            });
        }

        public static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category() { Title = "Italian" },
                new Category() { Title = "Main Dish" }
            }.Select(_ =>
            {
                _.CreatedBy = "Ryan";
                _.ModifiedBy = "Ryan Again";
                return _;
            });
        }

        public static IEnumerable<RecipeCategory> GetPreconfiguredRecipeCategories()
        {
            return new List<RecipeCategory>()
            {
            };
        }

        public static IEnumerable<RelatedRecipe> GetPreconfiguredRelatedRecipes()
        {
            return new List<RelatedRecipe>()
            {
            };
        }
    }
}
