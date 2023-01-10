using CarRepairShop.Application.Order.Requests;
using CarRepairShop.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace CarRepairShop.Application.Order.Validators
{
    public class OrderUpdateStatusValidator : AbstractValidator<OrderUpdateStatusRequest>
    {
        private readonly IOrderRepository _repository;

        public OrderUpdateStatusValidator(IOrderRepository repository)
        {
            _repository = repository;
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<OrderUpdateStatusRequest> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id)
                .MustAsync(OrderExists)
                .WithMessage("Order doesn't exist");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price can't be empty");

            RuleFor(x => x.OrderStatus)
                .NotEmpty()
                .WithMessage("Order status can't be empty");

            return base.ValidateAsync(context, cancellation);
        }

        private async Task<bool> OrderExists(int id, CancellationToken cancellation)
        {
            return await _repository.Get(id) != null;
        }
    }
}