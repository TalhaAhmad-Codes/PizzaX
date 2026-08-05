using MediatR;
using PizzaX.Features.Identity.Users.DTOs;

namespace PizzaX.Features.Identity.Users.Queries.GetUserByEmail
{
    public sealed class GetUserByEmailQuery : IRequest<UserResponseDto>
    {
        public required string Email { get; init; }
    }
}
