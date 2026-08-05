using MediatR;
using PizzaX.Common.DTOs;
using PizzaX.Features.Identity.Users.DTOs;
using PizzaX.Features.Identity.Users.Enums;

namespace PizzaX.Features.Identity.Users.Queries.GetAllUsers
{
    public sealed class GetAllUsersQuery : BaseFilterDto, IRequest<PagedResultDto<UserResponseDto>>
    {
        public string? Username { get; init; }
        public UserRole? Role { get; init; }
        public bool? IsActive { get; init; }
    }
}
