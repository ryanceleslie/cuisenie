using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.RecipeAggregate.Joiners
{
    [Table("RelatedRecipes")]
    public class RelatedRecipe : BaseEntity
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int ParentRecipeId { get; set; }
        public Recipe ParentRecipe { get; set; }
    }
}
