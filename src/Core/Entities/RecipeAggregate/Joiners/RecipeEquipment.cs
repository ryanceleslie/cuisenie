using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.RecipeAggregate.Joiners
{
    [Table("RecipeEquipment")]
    public class RecipeEquipment : BaseEntity
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
