using CarRepairShop.API.Helpers;
using CarRepairShop.Application.Common.Responses;
using CarRepairShop.Infrastructure.Identity;
using CarRepairShop.Infrastructure.User.Interfaces;
using CarRepairShop.Infrastructure.User.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.API.Controllers
{
    public class UsersController : RouteBaseController
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<Response<UserViewModel>> GetUserDetails([FromQuery] string id)
        {
            return await _service.GetUserDetails(id);
        }
    }
}