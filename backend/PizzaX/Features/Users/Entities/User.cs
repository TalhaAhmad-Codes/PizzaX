using PizzaX.Common.Entities;
using PizzaX.Features.Users.Enums;

namespace PizzaX.Features.Users.Entities
{
    public sealed class User : BaseAuditableEntity
    {
        public byte[]? Avatar { get; set; } = null;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
