using MediatR;
using PizzaX.Common.DTOs;
using PizzaX.Features.Users.DTOs;
using PizzaX.Features.Users.Enums;

namespace PizzaX.Features.Users.Queries.GetAllUsers
{
    public sealed class GetAllUsersQuery : IRequest<PagedResultDto<UserResponseDto>>
    {
        public string? Username { get; init; }
        public UserRole? Role { get; init; }
        public bool? IsActive { get; init; }
    }
}
