using Mapster;
using MediatR;
using PizzaX.Features.Identity.Users.DTOs;
using PizzaX.Features.Identity.Users.Providers.Interfaces;

namespace PizzaX.Features.Identity.Users.Queries.GetUserById
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
    {
        private readonly IUserProvider _provider;

        public GetUserByIdHandler(IUserProvider provider)
        {
            _provider = provider;
        }

        public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _provider.GetByIdAsync(request.Id, cancellationToken);
            return user.Adapt<UserResponseDto>();
        }
    }
}
