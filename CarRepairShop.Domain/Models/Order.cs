using CarRepairShop.Domain.Enums;
using CarRepairShop.Domain.Models.Common;

namespace CarRepairShop.Domain.Models
{
    public class Order : AuditableEntity
    {
        public int CarId { get; set; }

        public decimal Price { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string Annotations { get; set; }

        public string UserId { get; set; }

        public bool IsAccepted { get; set; }
    }
}