using System.Security.Claims;

namespace CarRepairShop.Application.User.Interfaces
{
    public interface IUserResolverService
    {
        ClaimsPrincipal User { get; }

        string UserId { get; }
    }
}