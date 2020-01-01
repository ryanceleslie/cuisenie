namespace Core.Entities.RecipeAggregate
{
    public class NutritionType // ValueObject
    {
        public string Name { get; private set; }

        public NutritionType() { }

        public NutritionType(string name)
        {
            Name = name;
        }
    }
}
