namespace CarRepairShop.Application.Common.Validators
{
    public interface IValidationService
    {
        Task<bool> ValidateAsync<T>(T request);
    }
}