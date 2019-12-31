using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;
using Core.Entities.RecipeAggregate;
using Core.Entities.SuggestionAggregate;

namespace Infrastructure.Data
{
    public class MealPlannerContext : DbContext
    {
        public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Nutrition> Nutrition { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Can't create DbSets of owned types
        //public DbSet<NutritionType> NutritionTypes { get; set; }
        //public DbSet<Measurement> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Recipe>(ConfigureRecipe);
            builder.Entity<Ingredient>(ConfigureIngredient);
            builder.Entity<Nutrition>(ConfigureNutrition);
            builder.Entity<RecipePreference>(ConfigureRecipePreference);

            // Joiner tables
            builder.Entity<RecipeCategory>(ConfigureRecipeCategory);
            builder.Entity<RelatedRecipe>(ConfigureRelatedRecipe);
        }

        private void ConfigureRelatedRecipe(EntityTypeBuilder<RelatedRecipe> builder)
        {
            builder.HasKey(rr => new { rr.ParentRecipeId, rr.ChildRecipeId });

            builder.HasOne(rr => rr.ParentRecipe)
                .WithMany(r => r.RelatedRecipes)
                .HasForeignKey(rr => rr.ParentRecipeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureRecipeCategory(EntityTypeBuilder<RecipeCategory> builder)
        {
            builder.HasKey(rc => new { rc.RecipeId, rc.CategoryId });

            builder.HasOne(rc => rc.Recipe)
                .WithMany(r => r.Categories)
                .HasForeignKey(rc => rc.RecipeId);

            builder.HasOne(rc => rc.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(rc => rc.CategoryId);
        }

        private void ConfigureRecipe(EntityTypeBuilder<Recipe> builder)
        {
            var equipmentNavigation = builder.Metadata.FindNavigation(nameof(Recipe.Equipment));
            var ingredientsNavigation = builder.Metadata.FindNavigation(nameof(Recipe.Ingredients));
            var instructionsNavigation = builder.Metadata.FindNavigation(nameof(Recipe.Instructions));

            equipmentNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            ingredientsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            instructionsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureIngredient(EntityTypeBuilder<Ingredient> builder)
        {
            builder.OwnsOne(m => m.Measurement);
            builder.Property(p => p.Quantity).HasColumnType("decimal(18,2)");
        }

        private void ConfigureNutrition(EntityTypeBuilder<Nutrition> builder)
        {
            builder.OwnsOne(t => t.Type);
            builder.OwnsOne(m => m.Measurement);
            builder.Property(p => p.Value).HasColumnType("decimal(18,2)");
        }

        private void ConfigureRecipePreference(EntityTypeBuilder<RecipePreference> builder)
        {

        }
    }
}