using MediatR;
using PizzaX.Common.DTOs;
using PizzaX.Features.Users.DTOs;

namespace PizzaX.Features.Users.Queries.GetUserById
{
    public sealed class GetUserByIdQuery : BaseDto, IRequest<UserResponseDto>
    {
    }
}
