using CarRepairShop.Application.Common;
using CarRepairShop.Infrastructure.User.ViewModels;

namespace CarRepairShop.Infrastructure.User.Interfaces
{
    public interface IUserService
    {
        Task<ListResponse<UserViewModel>> GetAll();

        Task<Response<UserViewModel>> Get(string id);

        Task<Response<UserViewModel>> GetCurrentUser();
    }
}