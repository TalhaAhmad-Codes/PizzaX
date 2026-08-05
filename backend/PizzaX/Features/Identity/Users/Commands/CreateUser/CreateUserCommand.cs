using MediatR;
using PizzaX.Features.Identity.Users.Enums;

namespace PizzaX.Features.Identity.Users.Commands.CreateUser
{
    public sealed class CreateUserCommand : IRequest<Guid>
    {
        public required string Username { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public UserRole Role { get; init; }
    }
}
