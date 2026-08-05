using Mapster;
using MediatR;
using PizzaX.Features.Identity.Users.DTOs;
using PizzaX.Features.Identity.Users.Providers.Interfaces;

namespace PizzaX.Features.Identity.Users.Queries.GetUserByEmail
{
    public sealed class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, UserResponseDto>
    {
        private readonly IUserProvider _provider;

        public GetUserByEmailHandler(IUserProvider provider)
        {
            _provider = provider;
        }

        public async Task<UserResponseDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _provider.GetByEmailAsync(request.Email, cancellationToken);
            return user.Adapt<UserResponseDto>();
        }
    }
}
