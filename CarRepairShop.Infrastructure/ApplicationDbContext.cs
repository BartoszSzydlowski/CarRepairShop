using CarRepairShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}