using CarRepairShop.Domain.Models.Common;

namespace CarRepairShop.Domain.Models
{
    public class Car : AuditableEntity
    {
        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string Mileage { get; set; }

        public string VinNumber { get; set; }

        public string LicensePlateNumber { get; set; }
    }
}