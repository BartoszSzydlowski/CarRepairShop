using CarRepairShop.Application.Common;
using CarRepairShop.Infrastructure.User.Interfaces;
using CarRepairShop.Infrastructure.User.ViewModels;

namespace CarRepairShop.Infrastructure.User.Services
{
    public class UserService : IUserService
    {
        public Task<ListResponse<UserViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserViewModel>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Edit(UserViewModel reqeuest)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}