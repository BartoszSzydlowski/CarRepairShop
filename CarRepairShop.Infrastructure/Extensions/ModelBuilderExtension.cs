using CarRepairShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedDatabase(this ModelBuilder builder)
        {
            var userId = Guid.NewGuid().ToString();
            var username = "test@test.com";
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = userId,
                    Email = "test@test.com",
                    PasswordHash = hasher.HashPassword(null, "test"),
                    UserName = username,
                    NormalizedEmail = username.ToUpper(),
                    NormalizedUserName = username.ToUpper(),
                    Name = "TestName",
                    Surname = "TestSurname",
                    PhoneNumber = "123456789"
                }
            );
        }
    }
}