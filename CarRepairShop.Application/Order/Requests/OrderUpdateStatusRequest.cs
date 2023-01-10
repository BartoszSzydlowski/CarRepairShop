using AutoMapper;
using CarRepairShop.Application.Mapping;
using CarRepairShop.Domain.Enums;
using Entity = CarRepairShop.Domain.Models;

namespace CarRepairShop.Application.Order.Requests
{
    public class OrderUpdateStatusRequest : IMap
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public bool IsVisible { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderUpdateStatusRequest, Entity.Order>();
        }
    }
}