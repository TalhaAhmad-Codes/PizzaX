using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PizzaX.Common.DTOs;
using PizzaX.Common.Extensions;
using PizzaX.Database.Context;
using PizzaX.Features.Identity.Users.DTOs;

namespace PizzaX.Features.Identity.Users.Queries.GetAllUsers
{
    public sealed class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, PagedResultDto<UserResponseDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUsersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // Get the users' query
            var query = _context.Users.AsQueryable().AsNoTracking();

            // Applying all filters
            if (request.Username is not null)
                query = query.Where(u => u.Username.Contains(request.Username));

            if (request.Role.HasValue)
                query = query.Where(u => u.Role == request.Role.Value);

            // Pagination
            var users = await query
                .OrderBy(u => u.Username)
                .ProjectToType<UserResponseDto>()
                .ToPagedResultAsync(request.PageNumber, request.PageNumber, cancellationToken);
            return users;
        }
    }
}
