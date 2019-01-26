namespace Core.Entities.RecipeAggregate
{
    public class Nutrition : BaseEntity
    {
        public NutritionType Type { get; private set; }
        public Measurement Measurement { get; private set; }
        public int Value { get; set; }
    }
}
