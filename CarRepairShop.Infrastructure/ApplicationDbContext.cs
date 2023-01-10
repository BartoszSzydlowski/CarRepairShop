using CarRepairShop.Application.User.Interfaces;
using CarRepairShop.Domain.Models;
using CarRepairShop.Domain.Models.Common;
using CarRepairShop.Infrastructure.Extensions;
using CarRepairShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IUserResolverService _userResolverService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserResolverService userResolverService)
        : base(options)
            => _userResolverService = userResolverService;

        public DbSet<Order> Orders { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity
                    && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((AuditableEntity)entry.Entity).LastModified = DateTime.Now;
                ((AuditableEntity)entry.Entity).LastModifiedBy = _userResolverService.UserId;

                if (entry.State == EntityState.Added)
                {
                    ((AuditableEntity)entry.Entity).Created = DateTime.Now;
                    ((AuditableEntity)entry.Entity).CreatedBy = _userResolverService.UserId;
                }
            }

            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SeedDatabase();
        }
    }
}