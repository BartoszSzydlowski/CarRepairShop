using CarRepairShop.Application.Common;
using CarRepairShop.Infrastructure.Identity;
using CarRepairShop.Infrastructure.User.Interfaces;
using CarRepairShop.Infrastructure.User.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.User.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ListResponse<UserViewModel>> GetAll()
        {
            var data = await _context.Users.ToListAsync();
            var mappedData = new List<UserViewModel>();

            foreach (var user in data)
            {
                mappedData.Add(new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email });
            }

            return new ListResponse<UserViewModel>
            {
                Data = mappedData,
                Total = data.Count
            };
        }

        public async Task<Response<UserViewModel>> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var mappedUser = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            return new Response<UserViewModel>
            {
                Data = mappedUser
            };
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