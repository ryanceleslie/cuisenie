using Core.Entities.RecipeAggregate.Joiners;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
    }
}
