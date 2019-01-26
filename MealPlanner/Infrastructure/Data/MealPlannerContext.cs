using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;
using Core.Entities.RecipeAggregate;

namespace Infrastructure.Data
{
    public class MealPlannerContext : DbContext
    {
        public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlServer(ConnectionStrings, x => x.MigrationsAssembly("MyApp.Migrations"));

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Nutrition> Nutrition { get; set; }

        // Can't create DbSets of owned types
        //public DbSet<NutritionType> NutritionTypes { get; set; }
        //public DbSet<Measurement> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Recipe>(ConfigureRecipe);
            builder.Entity<Ingredient>(ConfigureIngredient);
            builder.Entity<Nutrition>(ConfigureNutrition);
        }

        private void ConfigureRecipe(EntityTypeBuilder<Recipe> builder)
        {
            var ingredientsNavigation = builder.Metadata.FindNavigation(nameof(Recipe.Ingredients));
            var instructionsNavigation = builder.Metadata.FindNavigation(nameof(Recipe.Instructions));

            ingredientsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            instructionsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureIngredient(EntityTypeBuilder<Ingredient> builder)
        {
            builder.OwnsOne(m => m.Measurement);
        }

        private void ConfigureNutrition(EntityTypeBuilder<Nutrition> builder)
        {
            builder.OwnsOne(t => t.Type);
            builder.OwnsOne(m => m.Measurement);
        }
    }
}