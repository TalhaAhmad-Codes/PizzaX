using MediatR;
using PizzaX.Common.DTOs;

namespace PizzaX.Features.Identity.Users.Commands.ResetUserPassword
{
    public sealed class ResetUserPasswordCommand : BaseDto, IRequest<bool>
    {
        public required string OTPCode { get; init; }    // Will extend later
        public required string NewPassword { get; init; }
        public required string ConfirmPassword { get; init; }
    }
}
