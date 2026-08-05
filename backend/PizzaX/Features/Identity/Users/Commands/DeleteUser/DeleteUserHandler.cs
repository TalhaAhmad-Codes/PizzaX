using MediatR;
using PizzaX.Common.Exceptions;
using PizzaX.Database.Context;
using PizzaX.Features.Identity.Users.Providers.Interfaces;

namespace PizzaX.Features.Identity.Users.Commands.DeleteUser
{
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _provider;

        public DeleteUserHandler(ApplicationDbContext context, IUserProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _provider.GetByIdAsync(request.Id, cancellationToken);

                _context.Users.Remove(user);
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
