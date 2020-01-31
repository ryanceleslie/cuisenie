using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Entities.RecipeAggregate
{
    public class Recipe : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public int Servings { get; set; }
        public TimeSpan Prep { get; set; }
        public TimeSpan Cook { get; set; }
        public string PictureUrl { get; set; }
        public string VideoUrl { get; set; }
        public string ExternalUrl { get; set; }
        public string Notes { get; set; }
        public bool IsArchived { get; set; } = false;

        private List<IngredientSet> _ingredientSets = new List<IngredientSet>();
        public IEnumerable<IngredientSet> IngredientSets => _ingredientSets;

        private List<InstructionSet> _instructionSets = new List<InstructionSet>();
        public IEnumerable<InstructionSet> InstructionSets => _instructionSets;


        public Recipe() { }

        public Recipe(
            string name,
            int servings,
            TimeSpan prep,
            TimeSpan cook,
            string pictureUrl, 
            string videoUrl,
            string externalUrl,
            string notes,
            bool isArchived,
            List<IngredientSet> ingredientSets,
            List<InstructionSet> instructionSets) : this()
        {
            //TODO likely need to add more guards

            Name = name;
            Servings = servings;
            Prep = prep;
            Cook = cook;
            PictureUrl = pictureUrl;
            VideoUrl = videoUrl;
            ExternalUrl = externalUrl;
            Notes = notes;
            IsArchived = isArchived;
            _ingredientSets = ingredientSets;
            _instructionSets = instructionSets;
        }
    }
}
