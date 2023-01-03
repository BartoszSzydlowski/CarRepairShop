﻿namespace CarRepairShop.Domain.Models.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}