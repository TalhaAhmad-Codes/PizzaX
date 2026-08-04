using FluentValidation;
using PizzaX.Common.Utilities.Length;

namespace PizzaX.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            // Username validation
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(MinLength.Username, MaxLength.Username).WithMessage($"Username must be between {MinLength.Username} and {MaxLength.Username} characters.");

            // Email validation
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            // Password validation
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(MinLength.Password, MaxLength.Password).WithMessage($"Password must be between {MinLength.Password} and {MaxLength.Password} characters.");

            // Role validation
            RuleFor(u => u.Role)
                .IsInEnum().WithMessage("Invalid user role.");
        }
    }
}
