using MediatR;
using PizzaX.Common.DTOs;

namespace PizzaX.Features.Users.Commands.ResetUserPassword
{
    public sealed class ResetUserPasswordCommand : BaseDto, IRequest<bool>
    {
        public string OTPCode { get; init; }    // Will extend later
        public string NewPassword { get; init; }
        public string ConfirmPassword { get; init; }
    }
}
