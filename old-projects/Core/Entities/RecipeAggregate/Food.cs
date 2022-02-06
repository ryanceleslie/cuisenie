using System.Collections.Generic;

namespace Core.Entities.RecipeAggregate
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public int ShiptId { get; set; }
        public string BrandName { get; set; }

        public Food() { }
    }
}
