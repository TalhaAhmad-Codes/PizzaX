using PizzaX.Common.DTOs;
using PizzaX.Features.Users.Enums;

namespace PizzaX.Features.Users.DTOs
{
    public sealed class UserResponseDto : BaseDto
    {
        public byte[]? Avatar { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public UserRole Role { get; init; }
        public bool IsActive { get; init; }
    }
}
