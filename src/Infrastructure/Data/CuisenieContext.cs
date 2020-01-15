using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;
using Core.Entities.RecipeAggregate;
using Core.Entities.SuggestionAggregate;
using System;

namespace Infrastructure.Data
{
    public class CuisenieContext : DbContext
    {
        public CuisenieContext(DbContextOptions<CuisenieContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<IngredientSet> IngredientSets { get; set; }
        public DbSet<InstructionSet> InstructionSets { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Food> Food { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Recipe>(ConfigureRecipe);
            builder.Entity<IngredientSet>(ConfigureIngredientSet);
            builder.Entity<InstructionSet>(ConfigureInstructionSet);
            builder.Entity<Ingredient>(ConfigureIngredient);
            builder.Entity<Food>(ConfigureFood);
            builder.Entity<RecipePreference>(ConfigureRecipePreference);
        }

        private void ConfigureRecipe(EntityTypeBuilder<Recipe> builder)
        {
            builder.Metadata
                .FindNavigation(nameof(Recipe.IngredientSets))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            
            builder.Metadata
                .FindNavigation(nameof(Recipe.InstructionSets))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureIngredientSet(EntityTypeBuilder<IngredientSet> builder)
        {
            builder.Metadata
                .FindNavigation(nameof(IngredientSet.Ingredients))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureInstructionSet(EntityTypeBuilder<InstructionSet> builder)
        {
            builder.Metadata
                .FindNavigation(nameof(InstructionSet.Instructions))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureIngredient(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(p => p.Quantity).HasColumnType("decimal(18,2)");
        }

        private void ConfigureFood(EntityTypeBuilder<Food> builder)
        {

        }

        private void ConfigureRecipePreference(EntityTypeBuilder<RecipePreference> builder)
        {
            
        }
    }
}