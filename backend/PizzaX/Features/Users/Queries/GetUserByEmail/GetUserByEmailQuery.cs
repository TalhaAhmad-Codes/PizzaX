using MediatR;
using PizzaX.Features.Users.DTOs;

namespace PizzaX.Features.Users.Queries.GetUserByEmail
{
    public sealed class GetUserByEmailQuery : IRequest<UserResponseDto>
    {
        public string Email { get; init; }
    }
}
