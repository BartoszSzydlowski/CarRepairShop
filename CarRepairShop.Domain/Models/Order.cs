using CarRepairShop.Domain.Enums;
using CarRepairShop.Domain.Models.Common;

namespace CarRepairShop.Domain.Models
{
    public class Order : AuditableEntity
    {
        public decimal Price { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public ServiceType ServiceType { get; set; }

        public string Annotations { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string Mileage { get; set; }

        public string VinNumber { get; set; }

        public string LicensePlateNumber { get; set; }

        public bool IsVisible { get; set; }
    }
}