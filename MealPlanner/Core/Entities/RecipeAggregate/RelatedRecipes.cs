using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.RecipeAggregate
{
    [Table("RelatedRecipes")]
    public class RelatedRecipes
    {
        public int ParentRecipeId { get; set; }
        public Recipe ParentRecipe { get; set; }

        public int ChildRecipeId { get; set; }
        public Recipe ChildRecipe { get; set; }
    }
}
