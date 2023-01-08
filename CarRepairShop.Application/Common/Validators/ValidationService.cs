using FluentValidation;
using FluentValidation.Results;
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

        public async Task<ValidationResult> ValidateAsync<T>(T request)
        {
            return await _httpContextAccessor.HttpContext!.RequestServices.GetRequiredService<IValidator<T>>().ValidateAsync(request);
        }
    }
}
