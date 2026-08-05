using FluentValidation;
using PizzaX.Common.Utilities.Length;
using PizzaX.Common.Validators;

namespace PizzaX.Features.Identity.Users.Queries.GetAllUsers
{
    public sealed class GetAllUsersValidator : BaseFilterValidator<GetAllUsersQuery>
    {
        public GetAllUsersValidator() : base()
        {
            RuleFor(u => u.Username)
                .MaximumLength(MaxLength.Username).WithMessage($"Username must not exceed {MaxLength.Username} characters.").When(u => u.Username is not null);

            RuleFor(u => u.Role)
                .IsInEnum().WithMessage("Invalid user role.").When(u => u.Role is not null);
        }
    }
}
