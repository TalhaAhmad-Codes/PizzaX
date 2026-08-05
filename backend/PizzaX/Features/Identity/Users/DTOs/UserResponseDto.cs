using PizzaX.Common.DTOs;
using PizzaX.Features.Identity.Users.Enums;

namespace PizzaX.Features.Identity.Users.DTOs
{
    public sealed class UserResponseDto : BaseDto
    {
        public byte[]? Avatar { get; init; }
        public required string Username { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public UserRole Role { get; init; }
        public bool IsActive { get; init; }
    }
}
