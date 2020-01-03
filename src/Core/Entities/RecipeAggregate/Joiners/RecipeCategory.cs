using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.RecipeAggregate.Joiners
{
    [Table("RecipeCategories")]
    public class RecipeCategory
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
