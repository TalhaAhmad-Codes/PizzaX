using MediatR;
using PizzaX.Common.Exceptions;
using PizzaX.Database.Context;
using PizzaX.Features.Identity.Users.Providers.Interfaces;

namespace PizzaX.Features.Identity.Users.Commands.UpdateUser
{
    public sealed class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _provider;

        public UpdateUserHandler(ApplicationDbContext context, IUserProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Get user entity
                var user = await _provider.GetByIdAsync(request.Id, cancellationToken);

                // Update user entity
                user.Avatar = request.Avatar;
                user.Username = request.Username;

                // Save changes to the database
                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (NotExistsException)
            {
                return false;
            }
        }
    }
}
