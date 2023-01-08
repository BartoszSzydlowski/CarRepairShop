using AutoMapper;
using CarRepairShop.Application.Mapping;
using CarRepairShop.Domain.Enums;
using Entity = CarRepairShop.Domain.Models;

namespace CarRepairShop.Application.Order.Requests
{
    public class OrderAddRequest : IMap
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderAddRequest, Entity.Order>();
        }
    }
}