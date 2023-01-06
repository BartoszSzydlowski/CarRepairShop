using CarRepairShop.Application.Car.Interfaces;
using CarRepairShop.Application.Car.Requests;
using CarRepairShop.Application.Car.Services;
using CarRepairShop.Application.Car.Validators;
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
            //services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserResolverService, UserResolverService>();

            services.AddScoped<IValidator<CarAddRequest>, CarAddValidator>();
            services.AddScoped<IValidator<CarUpdateRequest>, CarUpdateValidator>();
            services.AddScoped<IValidator<CarDeleteRequest>, CarDeleteValidator>();

            //services.AddScoped<IValidator<OrderAddRequest>, OrderAddValidator>();
            //services.AddScoped<IValidator<OrderUpdateRequest>, OrderUpdateValidator>();
            //services.AddScoped<IValidator<OrderDeleteRequest>, OrderDeleteValidator>();

            return services;
        }
    }
}