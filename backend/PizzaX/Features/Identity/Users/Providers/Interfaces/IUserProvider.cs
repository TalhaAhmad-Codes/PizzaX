using PizzaX.Common.Providers.Interfaces;
using PizzaX.Features.Identity.Users.Entities;

namespace PizzaX.Features.Identity.Users.Providers.Interfaces
{
    public interface IUserProvider : IGeneralProvider<User>
    {
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
