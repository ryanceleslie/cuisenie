namespace Core.Entities.RecipeAggregate
{
    public class Instruction : BaseEntity
    {
        public int Step { get; set; }
        public string Description { get; set; }
        public Recipe Recipe { get; set; }

        public Instruction() { }
    }
}
