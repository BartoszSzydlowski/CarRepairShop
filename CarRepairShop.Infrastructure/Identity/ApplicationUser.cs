using Microsoft.AspNetCore.Identity;

namespace CarRepairShop.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}