using System;

namespace Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; private set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime Modified { get; private set; } = DateTime.Now;
        public string ModifiedBy { get; set; }
    }
}
