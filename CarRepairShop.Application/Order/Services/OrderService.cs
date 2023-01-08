﻿using AutoMapper;
using CarRepairShop.Application.Common;
using CarRepairShop.Application.Order.Interfaces;
using CarRepairShop.Application.Order.Requests;
using CarRepairShop.Application.Order.ViewModels;
using CarRepairShop.Domain.Interfaces;
using FluentValidation;
using System.Net;
using Entity = CarRepairShop.Domain.Models;

namespace CarRepairShop.Application.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<OrderAddRequest> _addValidator;
        private readonly IValidator<OrderUpdateRequest> _updateValidator;
        private readonly IValidator<OrderDeleteRequest> _deleteValidator;

        public OrderService(IOrderRepository repository, IMapper mapper, IValidator<OrderAddRequest> addValidator, IValidator<OrderUpdateRequest> updateValidator, IValidator<OrderDeleteRequest> deleteValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
            _deleteValidator = deleteValidator;
        }

        public async Task<ListResponse<OrderViewModel>> GetAll()
        {
            var data = await _repository.GetAll();
            return new ListResponse<OrderViewModel>
            {
                Data = _mapper.Map<IEnumerable<OrderViewModel>>(data),
                Total = data.Count()
            };
        }

        public async Task<Response<OrderViewModel>> Get(int id)
        {
            var data = await _repository.Get(id);
            if (data != null)
            {
                return new Response<OrderViewModel>
                {
                    Data = _mapper.Map<OrderViewModel>(data)
                };
            }

            throw new HttpRequestException("", null, HttpStatusCode.NotFound);
        }

        public async Task<BaseResponse> Add(OrderAddRequest request)
        {
            var validationResult = await _addValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _repository.Add(_mapper.Map<Entity.Order>(request));
            return new BaseResponse();
        }

        public async Task<BaseResponse> Update(OrderUpdateRequest request)
        {
            var validationResult = await _updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingProduct = await _repository.Get(request.Id);
            var product = _mapper.Map(request, existingProduct);
            await _repository.Update(product);
            return new BaseResponse();
        }

        public async Task<BaseResponse> Delete(OrderDeleteRequest request)
        {
            var validationResult = await _deleteValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _repository.Delete(request.Id);
            return new BaseResponse();
        }

        public async Task<bool> UserOwns(int id, string userId)
        {
            var order = await _repository.Get(id);

            if (order == null)
            {
                return false;
            }

            if (order.UserId != userId)
            {
                return false;
            }

            return true;
        }
    }
}
