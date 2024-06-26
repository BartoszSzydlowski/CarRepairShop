﻿using CarRepairShop.Application.Common.Responses;
using CarRepairShop.Application.Identity.Requests;
using CarRepairShop.Application.Identity.ViewModels;

namespace CarRepairShop.Application.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<TokenViewModel>> Login(LoginRequest request);

        Task<BaseResponse> RegisterUser(RegisterRequest request);

        Task<BaseResponse> RegisterAdmin(RegisterRequest request);
    }
}