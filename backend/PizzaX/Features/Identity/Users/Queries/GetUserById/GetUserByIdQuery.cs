using MediatR;
using PizzaX.Common.DTOs;
using PizzaX.Features.Identity.Users.DTOs;

namespace PizzaX.Features.Identity.Users.Queries.GetUserById
{
    public sealed class GetUserByIdQuery : BaseDto, IRequest<UserResponseDto> { }
}
