using Microsoft.EntityFrameworkCore;
using PizzaX.Common.Entities;
using PizzaX.Common.Exceptions;
using PizzaX.Common.Providers.Interfaces;
using PizzaX.Database.Context;

namespace PizzaX.Common.Providers
{
    public abstract class GeneralProvider<T> : IGeneralProvider<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GeneralProvider(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(id, cancellationToken)
                ?? throw new NotExistsException();

            return entity;
        }
    }
}
