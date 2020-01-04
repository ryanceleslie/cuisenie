namespace Core.Entities.RecipeAggregate
{
    public class Nutrition : BaseEntity
    {
        public decimal Value { get; set; }
        public string Measurement { get; set; }
        public string Type { get;  set; }
    }
}
