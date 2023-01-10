using CarRepairShop.Application.Common.Validators;
using CarRepairShop.Application.Order.Interfaces;
using CarRepairShop.Application.Order.Requests;
using CarRepairShop.Application.Order.Services;
using CarRepairShop.Application.Order.Validators;
using CarRepairShop.Application.User.Interfaces;
using CarRepairShop.Application.User.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CarRepairShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserResolverService, UserResolverService>();

            services.AddScoped<IValidationService, ValidationService>();

            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IValidator<OrderAddRequest>, OrderAddValidator>();
            services.AddScoped<IValidator<OrderUpdateRequest>, OrderUpdateValidator>();
            services.AddScoped<IValidator<OrderDeleteRequest>, OrderDeleteValidator>();
            services.AddScoped<IValidator<OrderUpdateStatusRequest>, OrderUpdateStatusValidator>();

            return services;
        }
    }
}