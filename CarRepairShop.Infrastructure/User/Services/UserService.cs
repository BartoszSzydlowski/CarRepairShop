using CarRepairShop.Application.Common.Responses;
using CarRepairShop.Application.User.Interfaces;
using CarRepairShop.Infrastructure.Identity;
using CarRepairShop.Infrastructure.User.Interfaces;
using CarRepairShop.Infrastructure.User.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace CarRepairShop.Infrastructure.User.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserResolverService _userResolverService;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IUserResolverService userResolverService)
        {
            _context = context;
            _userManager = userManager;
            _userResolverService = userResolverService;
        }

        public async Task<ListResponse<UserViewModel>> GetAll()
        {
            var data = await _context.Users.ToListAsync();
            var mappedData = new List<UserViewModel>();

            foreach (var user in data)
            {
                mappedData.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Name = user.Name,
                    Surname = user.Surname
                });
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
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Surname = user.Surname,
            };

            return new Response<UserViewModel>
            {
                Data = mappedUser
            };
        }

        public async Task<Response<CurrentUserViewModel>> GetCurrentUser()
        {
            var user = _userResolverService.User;

            var mappedUser = new CurrentUserViewModel
            {
                Id = user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).SingleOrDefault().Value,
                Email = user.Claims.Where(x => x.Type == ClaimTypes.Email).SingleOrDefault().Value,
                PhoneNumber = user.Claims.Where(x => x.Type == ClaimTypes.MobilePhone).SingleOrDefault().Value,
                Name = user.Claims.Where(x => x.Type == ClaimTypes.Name).SingleOrDefault().Value,
                Surname = user.Claims.Where(x => x.Type == ClaimTypes.Surname).SingleOrDefault().Value,
                Role = user.Claims.Where(x => x.Type == ClaimTypes.Role).SingleOrDefault().Value
            };

            return new Response<CurrentUserViewModel>
            {
                Data = mappedUser
            };
        }

        public async Task<Response<UserViewModel>> GetUserDetails(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new HttpRequestException("Not found", null, HttpStatusCode.NotFound);
            }

            var mappedUser = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Surname = user.Surname,
            };

            return new Response<UserViewModel>
            {
                Data = mappedUser
            };
        }
    }
}