namespace Core.Entities.RecipeAggregate
{
    public class NutritionType // ValueObject
    {
        public string Type { get; private set; }

        public NutritionType() { }

        public NutritionType(string type)
        {
            Type = type;
        }
    }
}
