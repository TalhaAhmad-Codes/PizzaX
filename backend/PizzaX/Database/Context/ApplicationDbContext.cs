using Microsoft.EntityFrameworkCore;
using PizzaX.Features.Users.Entities;

namespace PizzaX.Database.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions) { }

        /* <----- Identity Entities -----> */
        public DbSet<User> Users => Set<User>();
    }
}
