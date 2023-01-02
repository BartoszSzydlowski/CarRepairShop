using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShop.Application.User.Interfaces
{
    public interface IUserResolverService
    {
        ClaimsPrincipal User { get; }

        string UserId { get; }
    }
}
