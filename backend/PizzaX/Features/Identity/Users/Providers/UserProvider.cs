using PizzaX.Common.Providers;
using PizzaX.Database.Context;
using Microsoft.EntityFrameworkCore;
using PizzaX.Common.Exceptions;
using PizzaX.Features.Identity.Users.Entities;
using PizzaX.Features.Identity.Users.Providers.Interfaces;

namespace PizzaX.Features.Identity.Users.Providers
{
    public sealed class UserProvider : GeneralProvider<User>, IUserProvider
    {
        public UserProvider(ApplicationDbContext context) : base(context) { }

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
            => await _dbSet.AnyAsync(u => u.Email == email, cancellationToken);

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var user = _dbSet.FirstOrDefault(u => u.Email == email)
                ?? throw new NotExistsException();

            return user;
        }
    }
}
