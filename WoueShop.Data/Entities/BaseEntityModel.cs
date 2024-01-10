using System.Reflection.Metadata.Ecma335;

namespace WouShop.Database.Entities
{
    public class BaseEntityModel
    {
        public DateTime CreatedAt { get; set; } 

        public DateTime? ModifiedAt { get; set; }

        public string CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public bool IsActive { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
