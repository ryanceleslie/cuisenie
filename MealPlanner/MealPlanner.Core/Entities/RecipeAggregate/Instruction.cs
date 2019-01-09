namespace MealPlanner.Core.Entities.RecipeAggregate
{
    public class Instruction : BaseEntity
    {
        public int Step { get; set; }
        public string Description { get; set; }
    }
}
