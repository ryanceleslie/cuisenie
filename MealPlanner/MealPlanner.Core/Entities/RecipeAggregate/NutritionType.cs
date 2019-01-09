namespace MealPlanner.Core.Entities.RecipeAggregate
{
    public class NutritionType // ValueObject
    {
        public string Type { get; set; }

        public NutritionType() { }

        public NutritionType(string type)
        {
            Type = type;
        }
    }
}
