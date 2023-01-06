using AutoMapper;
using CarRepairShop.Application.Mapping;
using Entity = CarRepairShop.Domain.Models;

namespace CarRepairShop.Application.Car.Requests
{
    public class CarUpdateRequest : IMap
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string Mileage { get; set; }

        public string VinNumber { get; set; }

        public string LicensePlateNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CarUpdateRequest, Entity.Car>();
        }
    }
}
