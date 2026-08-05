using MediatR;
using PizzaX.Common.DTOs;

namespace PizzaX.Features.Identity.Users.Commands.UpdateUser
{
    public sealed class UpdateUserCommand : BaseDto, IRequest<bool>
    {
        public byte[]? Avatar { get; init; }
        public required string Username { get; init; }
    }
}
