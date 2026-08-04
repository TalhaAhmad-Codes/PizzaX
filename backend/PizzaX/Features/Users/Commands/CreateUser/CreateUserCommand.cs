using MediatR;
using PizzaX.Features.Users.Enums;

namespace PizzaX.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserCommand : IRequest<Guid>
    {
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public UserRole Role { get; init; }
    }
}
