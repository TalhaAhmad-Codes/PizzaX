using MediatR;
using PizzaX.Database.Context;
using PizzaX.Features.Users.Entities;

namespace PizzaX.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CreateUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Create user
            var user = new User()
            {
                Username = request.Username.Trim(),
                Email = request.Email.Trim(),
                Password = request.Password.Trim(),
                Role = request.Role
            };

            // Insert to database
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
            
            // Return user's id
            return user.Id;
        }
    }
}
