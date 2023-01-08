namespace CarRepairShop.Application.Common.Validators
{
    public interface IValidationService
    {
        //Task<ValidationResult> ValidateAsync<T>(T request);

        Task<bool> ValidateAsync<T>(T request);
    }
}