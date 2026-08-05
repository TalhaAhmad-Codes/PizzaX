using Microsoft.EntityFrameworkCore;
using PizzaX.Common.DTOs;

namespace PizzaX.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResultDto<T>> ToPagedResultAsync<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default
        ) where T : class
        {
            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new()
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
