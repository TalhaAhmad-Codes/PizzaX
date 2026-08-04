using MediatR;
using PizzaX.Common.DTOs;

namespace PizzaX.Features.Users.Commands.UpdateUser
{
    public sealed class UpdateUserCommand : BaseDto, IRequest<bool>
    {
        public byte[]? Avatar { get; init; }
        public string Username { get; init; }
    }
}
