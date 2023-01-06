using CarRepairShop.Application.Car.Requests;
using CarRepairShop.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace CarRepairShop.Application.Car.Validators
{
    public class CarDeleteValidator : AbstractValidator<CarDeleteRequest>
    {
        private readonly ICarRepository _repository;

        public CarDeleteValidator(ICarRepository repository)
        {
            _repository = repository;
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<CarDeleteRequest> context, CancellationToken cancellation = default)
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
