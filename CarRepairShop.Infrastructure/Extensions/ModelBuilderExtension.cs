using CarRepairShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedDatabase(this ModelBuilder builder)
        {
            var adminname = "testAdmin@test.com";
            var adminId = Guid.NewGuid().ToString();
            var adminRoleId = Guid.NewGuid().ToString();
            var adminRoleName = "Admin";

            var username = "testUser@test.com";
            var userId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();
            var userRoleName = "User";

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = adminRoleName,
                    NormalizedName = adminRoleName.ToUpper(),
                    Id = adminRoleId
                }
            );

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = userRoleName,
                    NormalizedName = userRoleName.ToUpper(),
                    Id = userRoleId
                }
            );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = userId,
                    Email = username,
                    PasswordHash = hasher.HashPassword(null, "test"),
                    UserName = username,
                    NormalizedEmail = username.ToUpper(),
                    NormalizedUserName = username.ToUpper(),
                    Name = "TestName",
                    Surname = "TestSurname",
                    PhoneNumber = "123456789"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = userId
                }
            );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = adminId,
                    Email = adminname,
                    PasswordHash = hasher.HashPassword(null, "test"),
                    UserName = adminname,
                    NormalizedEmail = adminname.ToUpper(),
                    NormalizedUserName = adminname.ToUpper(),
                    Name = "TestName",
                    Surname = "TestSurname",
                    PhoneNumber = "123456789"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                }
            );
        }
    }
}