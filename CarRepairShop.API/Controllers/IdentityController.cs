using CarRepairShop.API.Helpers;
using CarRepairShop.Application.Common;
using CarRepairShop.Application.Identity.Interfaces;
using CarRepairShop.Application.Identity.Requests;
using CarRepairShop.Application.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.API.Controllers
{
    [AllowAnonymous]
    public class IdentityController : RouteBaseController
    {
        private readonly IIdentityService _service;

        public IdentityController(IIdentityService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<Response<TokenViewModel>> Login([FromBody] LoginRequest request)
        {
            return await _service.Login(request);
        }

        [HttpPost]
        public async Task<BaseResponse> Register([FromBody] RegisterRequest request)
        {
            return await _service.Register(request);
        }
    }
}