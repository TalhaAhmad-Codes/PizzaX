using MediatR;
using PizzaX.Common.DTOs;

namespace PizzaX.Features.Identity.Users.Commands.DeleteUser
{
    public sealed class DeleteUserCommand : BaseDto, IRequest<bool>
    {
    }
}
