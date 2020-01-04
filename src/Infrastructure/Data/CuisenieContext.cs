using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;
using Core.Entities.RecipeAggregate;
using Core.Entities.SuggestionAggregate;

namespace Infrastructure.Data
{
    public class CuisenieContext : DbContext
    {
        public CuisenieContext(DbContextOptions<CuisenieContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Food> Food { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Recipe>(ConfigureRecipe);
            builder.Entity<Ingredient>(ConfigureIngredient);
            builder.Entity<Food>(ConfigureFood);
            builder.Entity<RecipePreference>(ConfigureRecipePreference);
        }

        private void ConfigureRecipe(EntityTypeBuilder<Recipe> builder)
        {
            builder.Metadata
                .FindNavigation(nameof(Recipe.Ingredients))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            
            builder.Metadata
                .FindNavigation(nameof(Recipe.Instructions))
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