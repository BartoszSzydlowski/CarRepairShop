using CarRepairShop.Application.Common;
using CarRepairShop.Infrastructure.User.Interfaces;
using CarRepairShop.Infrastructure.User.ViewModels;

namespace CarRepairShop.Infrastructure.User.Services
{
    public class UserService : IUserService
    {
        public async Task<ListResponse<UserViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserViewModel>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> Edit(UserViewModel reqeuest)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}