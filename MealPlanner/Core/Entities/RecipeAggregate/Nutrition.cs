namespace Core.Entities.RecipeAggregate
{
    public class Nutrition : BaseEntity
    {
        public NutritionType Type { get; set; }
        public Measurement Measurement { get; set; }
        public int Value { get; set; }
    }
}
