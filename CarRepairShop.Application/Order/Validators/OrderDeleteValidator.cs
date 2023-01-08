using CarRepairShop.Application.Order.Requests;
using CarRepairShop.Application.User.Interfaces;
using CarRepairShop.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Security.Claims;

namespace CarRepairShop.Application.Order.Validators
{
    public class OrderDeleteValidator : AbstractValidator<OrderDeleteRequest>
    {
        private readonly IOrderRepository _repository;
        private readonly IUserResolverService _userResolverService;

        public OrderDeleteValidator(IOrderRepository repository, IUserResolverService userResolverService)
        {
            _repository = repository;
            _userResolverService = userResolverService;
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<OrderDeleteRequest> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id)
                .MustAsync(OrderExists)
                .WithMessage("Order doesn't exist");

            RuleFor(x => x)
            .MustAsync(UserHasPermissions)
            .WithMessage("No permissions to delete order");

            return base.ValidateAsync(context, cancellation);
        }

        private async Task<bool> UserHasPermissions(OrderDeleteRequest request, CancellationToken cancellation)
        {
            var order = await _repository.Get(request.Id);
            var user = _userResolverService.User;
            //var userRoles = user.Claims.Where(x => x.Type == ClaimTypes.Role);

            if (order.CreatedBy == _userResolverService.UserId)
            {
                return true;
            }

            //if (user.Claims.Any(x => x.Value == "Admin"))
            if (user.Claims.Where(x => x.Value == "Admin") != null)
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
