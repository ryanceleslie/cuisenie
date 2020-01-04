using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;
using Core.Entities.RecipeAggregate;
using Core.Entities.SuggestionAggregate;
using Core.Entities.RecipeAggregate.Joiners;

namespace Infrastructure.Data
{
    public class CuisenieContext : DbContext
    {
        public CuisenieContext(DbContextOptions<CuisenieContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeEquipment> RecipeEquipment { get; set; }
        public DbSet<RecipeCategory> RecipeCategory { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Nutrition> Nutrition { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Recipe>(ConfigureRecipe);
            builder.Entity<Ingredient>(ConfigureIngredient);
            builder.Entity<Food>(ConfigureFood);
            builder.Entity<Nutrition>(ConfigureNutrition);
            builder.Entity<RecipePreference>(ConfigureRecipePreference);

            // Joiner tables
            //TODO once EF Core supports HasMany+WithMany, refactor these so you can drop joiner entities
            builder.Entity<RecipeEquipment>(ConfigureRecipeEquipment);
            builder.Entity<RecipeCategory>(ConfigureRecipeCategory);
            builder.Entity<RelatedRecipe>(ConfigureRelatedRecipe);
        }

        private void ConfigureRecipe(EntityTypeBuilder<Recipe> builder)
        {
            builder.Metadata
                .FindNavigation(nameof(Recipe.Equipment))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Recipe.Ingredients))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            
            builder.Metadata
                .FindNavigation(nameof(Recipe.Instructions))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
            
            builder.Metadata
                .FindNavigation(nameof(Recipe.Categories))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            //TODO this is throwing a null error for some reason, I wonder if it's from the recursion
            //builder.Metadata
            //    .FindNavigation(nameof(Recipe.RelatedRecipes))
            //    .SetPropertyAccessMode(PropertyAccessMode.Field);

        }

        private void ConfigureIngredient(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(p => p.Quantity).HasColumnType("decimal(18,2)");
        }

        private void ConfigureFood(EntityTypeBuilder<Food> builder)
        {
            builder.Metadata
                .FindNavigation(nameof(Core.Entities.RecipeAggregate.Food.Nutrition))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureNutrition(EntityTypeBuilder<Nutrition> builder)
        {
            builder.Property(p => p.Value).HasColumnType("decimal(18,2)");
        }

        private void ConfigureRecipePreference(EntityTypeBuilder<RecipePreference> builder)
        {
            
        }

        // Joiners
        private void ConfigureRecipeEquipment(EntityTypeBuilder<RecipeEquipment> builder)
        {
            builder
                .HasOne(re => re.Recipe)
                .WithMany(r => r.Equipment)
                .HasForeignKey(re => re.EquipmentId);
        }

        private void ConfigureRecipeCategory(EntityTypeBuilder<RecipeCategory> builder)
        {
            builder
                .HasOne(rc => rc.Recipe)
                .WithMany(r => r.Categories)
                .HasForeignKey(rc => rc.CategoryId);
        }

        private void ConfigureRelatedRecipe(EntityTypeBuilder<RelatedRecipe> builder)
        {
            builder
                .HasOne(rr => rr.Recipe)
                .WithMany(r => r.RelatedRecipes)
                .HasForeignKey(rr => rr.ParentRecipeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}