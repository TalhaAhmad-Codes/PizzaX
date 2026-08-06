using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaX.Features.Identity.Users.Entities;
using PizzaX.Features.Identity.Users.Enums;
using PizzaX.Common.Utilities.Length;
using Microsoft.EntityFrameworkCore;

namespace PizzaX.Features.Identity.Users.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Username
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(MaxLength.Username);

            // Email
            builder.Property(u => u.Email)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            // Password
            builder.Property(u => u.PasswordHash)
                .IsRequired();

            // Role
            builder
               .Property(u => u.Role)
               .HasConversion<string>()
               .HasColumnName("Role")
               .IsRequired()
               .HasDefaultValue(UserRole.Customer);

            // IsActive
            builder.Property(u => u.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
