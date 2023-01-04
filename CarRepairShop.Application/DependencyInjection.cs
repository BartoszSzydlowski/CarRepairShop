using CarRepairShop.Application.User.Interfaces;
using CarRepairShop.Application.User.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarRepairShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserResolverService, UserResolverService>();

            //services.AddScoped<IValidator<ProductAddRequest>, ProductAddValidator>();
            //services.AddScoped<IValidator<ProductUpdateRequest>, ProductUpdateValidator>();
            //services.AddScoped<IValidator<ProductDeleteRequest>, ProductDeleteValidator>();

            //services.AddScoped<IValidator<OrderAddRequest>, OrderAddValidator>();
            //services.AddScoped<IValidator<OrderUpdateRequest>, OrderUpdateValidator>();
            //services.AddScoped<IValidator<OrderDeleteRequest>, OrderDeleteValidator>();

            return services;
        }
    }
}