namespace Core.Entities.RecipeAggregate
{
    public class Instruction : BaseEntity
    {
        public int Step { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string VideoUrl { get; set; }
        public string ExternalUrl { get; set; }
        public InstructionSet InstructionSet { get; set; }

        public Instruction() { }

        public Instruction(int step, string description, string pictureUrl, string videoUrl, string externalUrl, InstructionSet instructionSet)
        {
            Step = step;
            Description = description;
            PictureUrl = pictureUrl;
            VideoUrl = videoUrl;
            ExternalUrl = externalUrl;
            InstructionSet = instructionSet;
        }
    }
}
