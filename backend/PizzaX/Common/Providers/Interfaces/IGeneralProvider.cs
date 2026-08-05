using PizzaX.Common.Entities;

namespace PizzaX.Common.Providers.Interfaces
{
    public interface IGeneralProvider<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
