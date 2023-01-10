using CarRepairShop.API.Helpers;
using CarRepairShop.Application.Common.Responses;
using CarRepairShop.Application.Order.Interfaces;
using CarRepairShop.Application.Order.Requests;
using CarRepairShop.Application.Order.ViewModels;
using CarRepairShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.API.Controllers
{
    public class OrdersController : RouteBaseController
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ListResponse<OrderViewModel>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<Response<OrderViewModel>> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        [Authorize]
        public async Task<BaseResponse> Add(OrderAddRequest request)
        {
            return await _service.Add(request);
        }

        [HttpPut]
        [Authorize]
        public async Task<BaseResponse> Update(OrderUpdateRequest request)
        {
            return await _service.Update(request);
        }

        [HttpDelete]
        [Authorize]
        public async Task<BaseResponse> Delete(OrderDeleteRequest request)
        {
            return await _service.Delete(request);
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<BaseResponse> UpdateOrderStatus(OrderUpdateStatusRequest request)
        {
            return await _service.UpdateOrderStatus(request);
        }

        [HttpGet]
        [Authorize]
        public async Task<BaseResponse> GetUserOrders()
        {
            return await _service.GetUserOrders();
        }
    }
}