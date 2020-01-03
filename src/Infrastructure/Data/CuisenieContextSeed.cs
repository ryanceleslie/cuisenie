using System;
using System.Threading.Tasks;
using Core.Interfaces;
using System.Collections.Generic;
using Core.Entities.RecipeAggregate;
using System.Linq;

namespace Infrastructure.Data
{
    public class CuisenieContextSeed
    {
        public static async Task SeedAsync(CuisenieContext context, IAppLogger<CuisenieContextSeed> logger, int? retry = 0)
        {
            var retryForAvailability = retry.Value;

            try
            {
                if (!context.Recipes.Any())
                {
                    context.Recipes.AddRange(GetPreconfiguredRecipes());

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

        static IEnumerable<Recipe> GetPreconfiguredRecipes()
        {
            return new List<Recipe>()
            {
                new Recipe() { CreatedBy = "Ryan", ModifiedBy = "Ryan", Name = "Test 0", Servings = 4, Prep = TimeSpan.FromHours(1), Cook = TimeSpan.FromHours(1), Ready = TimeSpan.FromHours(2), ExternalUrl = "http://www.google.com" },
                new Recipe() { CreatedBy = "Ryan", ModifiedBy = "Ryan", Name = "Test 1", Servings = 2, Prep = TimeSpan.FromHours(1), Cook = TimeSpan.FromHours(1), Ready = TimeSpan.FromHours(2), ExternalUrl = "http://www.google.com" },
                new Recipe() { CreatedBy = "Ryan", ModifiedBy = "Ryan", Name = "Test 2", Servings = 3, Prep = TimeSpan.FromHours(1), Cook = TimeSpan.FromHours(1), Ready = TimeSpan.FromHours(2), ExternalUrl = "http://www.google.com" },
                new Recipe() { CreatedBy = "Ryan", ModifiedBy = "Ryan", Name = "Test 3", Servings = 6, Prep = TimeSpan.FromHours(1), Cook = TimeSpan.FromHours(1), Ready = TimeSpan.FromHours(2), ExternalUrl = "http://www.google.com" },
                new Recipe() { CreatedBy = "Ryan", ModifiedBy = "Ryan", Name = "Test 4", Servings = 5, Prep = TimeSpan.FromHours(1), Cook = TimeSpan.FromHours(1), Ready = TimeSpan.FromHours(2), ExternalUrl = "http://www.google.com" },
                new Recipe() { CreatedBy = "Ryan", ModifiedBy = "Ryan", Name = "Test 5", Servings = 1, Prep = TimeSpan.FromHours(1), Cook = TimeSpan.FromHours(1), Ready = TimeSpan.FromHours(2), ExternalUrl = "http://www.google.com" },
                new Recipe() { CreatedBy = "Ryan", ModifiedBy = "Ryan", Name = "Test 6", Servings = 2, Prep = TimeSpan.FromHours(1), Cook = TimeSpan.FromHours(1), Ready = TimeSpan.FromHours(2), ExternalUrl = "http://www.google.com" },
                new Recipe() { CreatedBy = "Ryan", ModifiedBy = "Ryan", Name = "Test 7", Servings = 3, Prep = TimeSpan.FromHours(1), Cook = TimeSpan.FromHours(1), Ready = TimeSpan.FromHours(2), ExternalUrl = "http://www.google.com" },
                new Recipe() { CreatedBy = "Ryan", ModifiedBy = "Ryan", Name = "Test 8", Servings = 4, Prep = TimeSpan.FromHours(1), Cook = TimeSpan.FromHours(1), Ready = TimeSpan.FromHours(2), ExternalUrl = "http://www.google.com" }
            };
        }

        static IEnumerable<Equipment> GetPreconfiguredEquipment()
        {
            throw new NotImplementedException();
        }

        static IEnumerable<Ingredient> GetPreconfiguredIngredients()
        {
            throw new NotImplementedException();
        }

        static IEnumerable<Instruction> GetPreconfiguredInstructions()
        {
            throw new NotImplementedException();
        }

        static IEnumerable<RecipeCategory> GetPreconfiguredRecipeCategories()
        {
            throw new NotImplementedException();
        }

        static IEnumerable<RelatedRecipe> GetPreconfiguredRelatedRecipes()
        {
            throw new NotImplementedException();
        }
    }
}
