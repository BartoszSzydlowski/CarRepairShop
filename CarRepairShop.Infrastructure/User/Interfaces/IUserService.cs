using CarRepairShop.Application.Common;
using CarRepairShop.Infrastructure.User.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Infrastructure.User.Interfaces
{
    public interface IUserService
    {
        Task<ListResponse<UserViewModel>> GetAll();

        Task<Response<UserViewModel>> Get(string id);

        Task<BaseResponse> Edit(UserViewModel reqeuest);

        Task<BaseResponse> Delete(string id);
    }
}
