using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CarRepairShop.Application.Common.Validators
{
    public class ValidationService : IValidationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> ValidateAsync<T>(T request)
        {
            var validationResult = await _httpContextAccessor.HttpContext!.RequestServices.GetRequiredService<IValidator<T>>().ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return true;
        }
    }
}