﻿using System.Reflection.Metadata.Ecma335;

namespace WouShop.Database.Entities
{
    public class BaseEntityModel
    {
        public DateTime CreatedAt { get; set; } 

        public DateTime? ModifiedAt { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public string? ModifiedBy { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime? DeletedAt { get; set; } = null;
    }
}
