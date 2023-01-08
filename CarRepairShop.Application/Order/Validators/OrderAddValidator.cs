using CarRepairShop.Application.Order.Requests;
using CarRepairShop.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace CarRepairShop.Application.Order.Validators
{
    public class OrderAddValidator : AbstractValidator<OrderAddRequest>
    {
        private readonly IOrderRepository _repository;

        public OrderAddValidator(IOrderRepository repository)
        {
            _repository = repository;
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<OrderAddRequest> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price can't be empty");

            RuleFor(x => x.ServiceType)
                .NotEmpty()
                .WithMessage("Service type can't be empty");

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model can't be empty");

            RuleFor(x => x.Manufacturer)
                .NotEmpty()
                .WithMessage("Manufacturer can't be empty");

            RuleFor(x => x.Mileage)
                .NotEmpty()
                .WithMessage("Mileage can't be empty");

            RuleFor(x => x.VinNumber)
                .NotEmpty()
                .WithMessage("Vin number can't be empty");

            RuleFor(x => x.LicensePlateNumber)
                .NotEmpty()
                .WithMessage("License plate number can't be empty");

            return base.ValidateAsync(context, cancellation);
        }
    }
}