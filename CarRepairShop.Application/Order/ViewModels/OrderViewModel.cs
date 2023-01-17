using AutoMapper;
using CarRepairShop.Application.Mapping;
using CarRepairShop.Domain.Enums;
using Entity = CarRepairShop.Domain.Models;

namespace CarRepairShop.Application.Order.ViewModels
{
    public class OrderViewModel : IMap
    {
        public int Id { get; set; }

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

        public string CreatedBy { get; set; }

        public string Created { get; set; }

        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entity.Order, OrderViewModel>();
        }
    }
}