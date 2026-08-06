using MediatR;
using PizzaX.Common.Exceptions;
using PizzaX.Common.Utilities;
using PizzaX.Database.Context;
using PizzaX.Features.Identity.Users.Entities;
using PizzaX.Features.Identity.Users.Providers.Interfaces;

namespace PizzaX.Features.Identity.Users.Commands.CreateUser
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProvider _provider;

        public CreateUserHandler(IUserProvider provider, ApplicationDbContext context)
        {
            _provider = provider;
            _context = context;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Check for email registeration
            var isRegistered = await _provider.ExistsByEmailAsync(request.Email, cancellationToken);

            if (isRegistered)
                throw new InvalidRequestException($"Email: {request.Email} is already registered.");

            // Create user
            //Console.WriteLine($"Request Role: {request.Role} ({(int)request.Role})");
            var user = new User()
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = PasswordHasher.Hash(request.Password),
                Role = request.Role
            };
            //Console.WriteLine($"User Role: {user.Role} ({(int)user.Role})");

            // Insert to database
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            // Return user's id
            return user.Id;
        }
    }
}
