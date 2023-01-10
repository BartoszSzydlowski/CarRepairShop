using CarRepairShop.Application.User.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CarRepairShop.Application.User.Services
{
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserResolverService(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        public ClaimsPrincipal User =>
            _httpContextAccessor.HttpContext!.User;

        public string UserId =>
                User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;
        //var claim = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
        //return claim?.Value!;
    }
}