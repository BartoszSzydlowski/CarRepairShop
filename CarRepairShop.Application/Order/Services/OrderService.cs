using AutoMapper;
using CarRepairShop.Application.Common.Responses;
using CarRepairShop.Application.Common.Validators;
using CarRepairShop.Application.Order.Interfaces;
using CarRepairShop.Application.Order.Requests;
using CarRepairShop.Application.Order.ViewModels;
using CarRepairShop.Application.User.Interfaces;
using CarRepairShop.Domain.Interfaces;
using System.Net;
using Entity = CarRepairShop.Domain.Models;

namespace CarRepairShop.Application.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;
        private readonly IUserResolverService _userResolverService;

        public OrderService(IOrderRepository repository, IMapper mapper, IValidationService validationService, IUserResolverService userResolverService)
        {
            _repository = repository;
            _mapper = mapper;
            _validationService = validationService;
            _userResolverService = userResolverService;
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

            throw new HttpRequestException("Not found", null, HttpStatusCode.NotFound);
        }

        public async Task<BaseResponse> Add(OrderAddRequest request)
        {
            await _validationService.ValidateAsync(request);
            await _repository.Add(_mapper.Map<Entity.Order>(request));
            return new BaseResponse();
        }

        public async Task<BaseResponse> Update(OrderUpdateRequest request)
        {
            await _validationService.ValidateAsync(request);
            var existingProduct = await _repository.Get(request.Id);
            var product = _mapper.Map(request, existingProduct);
            await _repository.Update(product);
            return new BaseResponse();
        }

        public async Task<BaseResponse> Delete(OrderDeleteRequest request)
        {
            await _validationService.ValidateAsync(request);
            await _repository.Delete(request.Id);
            return new BaseResponse();
        }

        public async Task<BaseResponse> UpdateOrderStatus(OrderUpdateStatusRequest request)
        {
            await _validationService.ValidateAsync(request);
            var existingProduct = await _repository.Get(request.Id);
            var product = _mapper.Map(request, existingProduct);
            await _repository.Update(product);
            return new BaseResponse();
        }

        public async Task<ListResponse<OrderViewModel>> GetUserOrders()
        {
            var data = await _repository.GetUserOrders(_userResolverService.UserId);
            return new ListResponse<OrderViewModel>
            {
                Data = _mapper.Map<IEnumerable<OrderViewModel>>(data),
                Total = data.Count()
            };
        }
    }
}