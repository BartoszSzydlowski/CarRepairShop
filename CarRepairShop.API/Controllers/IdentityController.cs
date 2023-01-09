using CarRepairShop.API.Helpers;
using CarRepairShop.Application.Common.Responses;
using CarRepairShop.Application.Identity.Interfaces;
using CarRepairShop.Application.Identity.Requests;
using CarRepairShop.Application.Identity.ViewModels;
using CarRepairShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.API.Controllers
{
    public class IdentityController : RouteBaseController
    {
        private readonly IIdentityService _service;

        public IdentityController(IIdentityService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<Response<TokenViewModel>> Login([FromBody] LoginRequest request)
        {
            return await _service.Login(request);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<BaseResponse> RegisterUser([FromBody] RegisterRequest request)
        {
            return await _service.RegisterUser(request);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<BaseResponse> RegisterAdmin([FromBody] RegisterRequest request)
        {
            return await _service.RegisterAdmin(request);
        }
    }
}