using CarRepairShop.Application.Car.Requests;
using FluentValidation;
using FluentValidation.Results;

namespace CarRepairShop.Application.Car.Validators
{
    public class CarAddValidator : AbstractValidator<CarAddRequest>
    {
        public override Task<ValidationResult> ValidateAsync(ValidationContext<CarAddRequest> context, CancellationToken cancellation = default)
        {
            //RuleFor(x => x.Price)
            //    .NotEmpty()
            //    .WithMessage("Price can't be empty");

            //RuleFor(x => x.Description)
            //    .NotEmpty()
            //    .WithMessage("Description can't be empty");

            //RuleFor(x => x.Name)
            //    .NotEmpty()
            //    .WithMessage("Name can't be empty");

            return base.ValidateAsync(context, cancellation);
        }
    }
}
