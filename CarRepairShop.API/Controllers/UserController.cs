using CarRepairShop.API.Helpers;
using CarRepairShop.Application.Common;
using CarRepairShop.Infrastructure.User.Interfaces;
using CarRepairShop.Infrastructure.User.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.API.Controllers
{
    public class UserController : RouteBaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ListResponse<UserViewModel>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [Authorize]
        public async Task<Response<UserViewModel>> GetCurrentUser()
        {
            return await _service.GetCurrentUser();
        }
    }
}