namespace Core.Entities.RecipeAggregate
{
    public class Measurement // ValueObject
    {
        public string Type { get; set; }

        public Measurement() { }

        public Measurement(string type)
        {
            Type = type;
        }
    }
}