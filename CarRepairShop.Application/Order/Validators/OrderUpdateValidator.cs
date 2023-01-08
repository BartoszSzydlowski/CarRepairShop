using CarRepairShop.Application.Order.Requests;
using CarRepairShop.Application.User.Interfaces;
using CarRepairShop.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace CarRepairShop.Application.Order.Validators
{
    public class OrderUpdateValidator : AbstractValidator<OrderUpdateRequest>
    {
        private readonly IOrderRepository _repository;
        private readonly IUserResolverService _userResolverService;

        public OrderUpdateValidator(IOrderRepository repository, IUserResolverService userResolverService)
        {
            _repository = repository;
            _userResolverService = userResolverService;
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<OrderUpdateRequest> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id)
                .MustAsync(OrderExists)
                .WithMessage("Order doesn't exist");

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

            RuleFor(x => x)
                .MustAsync(UserHasPermissions)
                .WithMessage("No permissions to update order");

            return base.ValidateAsync(context, cancellation);
        }

        private async Task<bool> UserHasPermissions(OrderUpdateRequest request, CancellationToken cancellation)
        {
            var order = await _repository.Get(request.Id);
            var user = _userResolverService.User;

            if (order.CreatedBy == _userResolverService.UserId)
            {
                return true;
            }

            if (user.Claims.Any(x => x.Value == "Admin"))
            {
                return true;
            }

            return false;
        }

        private async Task<bool> OrderExists(int id, CancellationToken cancellation)
        {
            return await _repository.Get(id) != null;
        }
    }
}