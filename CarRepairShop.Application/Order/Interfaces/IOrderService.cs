﻿using CarRepairShop.Application.Common.Responses;
using CarRepairShop.Application.Order.Requests;
using CarRepairShop.Application.Order.ViewModels;

namespace CarRepairShop.Application.Order.Interfaces
{
    public interface IOrderService
    {
        Task<ListResponse<OrderViewModel>> GetAll();

        Task<Response<OrderViewModel>> Get(int id);

        Task<BaseResponse> Add(OrderAddRequest request);

        Task<BaseResponse> Update(OrderUpdateRequest request);

        Task<BaseResponse> Delete(OrderDeleteRequest request);

        Task<BaseResponse> UpdateOrderStatus(OrderUpdateStatusRequest request);

        Task<ListResponse<OrderViewModel>> GetUserOrders();
    }
}