using CarRepairShop.Application.User.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Application.User.Services
{
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserResolverService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User
        {
            get
            {
                return _httpContextAccessor.HttpContext.User;
            }
        }

        public string UserId
        {
            get
            {
                var claim = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
                //return int.TryParse(claim == null ? throw new Exception("ClaimTypes.NameIdentifier is null") : claim.Value, out int result) ? result : throw new Exception("ClaimTypes.NameIdentifier is not int");
                return claim?.Value;
            }
        }
    }
}
