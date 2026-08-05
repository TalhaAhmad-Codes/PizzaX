using PizzaX.Common.Entities;
using PizzaX.Features.Identity.Users.Enums;

namespace PizzaX.Features.Identity.Users.Entities
{
    public sealed class User : BaseAuditableEntity
    {
        public byte[]? Avatar { get; set; } = null;
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
