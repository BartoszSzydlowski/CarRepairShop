using CarRepairShop.Application.Car.Requests;
using CarRepairShop.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace CarRepairShop.Application.Car.Validators
{
    public class CarUpdateValidator : AbstractValidator<CarUpdateRequest>
    {
        private readonly ICarRepository _repository;

        public CarUpdateValidator(ICarRepository repository)
        {
            _repository = repository;
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<CarUpdateRequest> context, CancellationToken cancellation = default)
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
