using CarRepairShop.Application.Common;
using CarRepairShop.Application.Identity.Requests;
using CarRepairShop.Application.Identity.ViewModels;

namespace CarRepairShop.Application.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<TokenViewModel>> Login(LoginRequest request);
    }
}