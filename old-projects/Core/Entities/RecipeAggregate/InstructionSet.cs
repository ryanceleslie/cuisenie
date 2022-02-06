using System.Collections.Generic;

namespace Core.Entities.RecipeAggregate
{
    public class InstructionSet : BaseEntity
    {
        public string Name { get; set; }
        public Recipe Recipe { get; set; }
        public string PictureUrl { get; set; }
        public string VideoUrl { get; set; }
        public string ExternalUrl { get; set; }
        private List<Instruction> _instructions = new List<Instruction>();
        public IEnumerable<Instruction> Instructions => _instructions;

        public InstructionSet() { }

        public InstructionSet(string name, Recipe recipe, string pictureUrl, string videoUrl, string externalUrl, List<Instruction> instructions)
        {
            Name = name;
            Recipe = recipe;
            PictureUrl = pictureUrl;
            VideoUrl = videoUrl;
            ExternalUrl = externalUrl;
            _instructions = instructions;
        }
    }
}