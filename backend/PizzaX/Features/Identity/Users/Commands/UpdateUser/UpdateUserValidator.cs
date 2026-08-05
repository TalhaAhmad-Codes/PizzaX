using FluentValidation;
using PizzaX.Common.Utilities.Length;
using PizzaX.Common.Validators;

namespace PizzaX.Features.Identity.Users.Commands.UpdateUser
{
    public sealed class UpdateUserValidator : BaseValidator<UpdateUserCommand>
    {
        public UpdateUserValidator() : base()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(MinLength.Username, MaxLength.Username).WithMessage($"Username must be between {MinLength.Username} and {MaxLength.Username} characters.");
        }
    }
}
