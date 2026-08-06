using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaX.Common.Exceptions;
using PizzaX.Features.Identity.Users.Commands.CreateUser;
using PizzaX.Features.Identity.Users.Commands.DeleteUser;
using PizzaX.Features.Identity.Users.Commands.UpdateUser;
using PizzaX.Features.Identity.Users.Queries.GetAllUsers;
using PizzaX.Features.Identity.Users.Queries.GetUserById;

namespace PizzaX.Features.Identity.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController : ControllerBase
    {
        protected readonly ISender _sender;

        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _sender.Send(request, cancellationToken);
                return Ok(user);
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }

        /*[HttpGet]
        public async Task<IActionResult> GetByEmailAsync([FromQuery] GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _mediator.Send(request, cancellationToken);
                return Ok(user);
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }*/

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = await _sender.Send(request, cancellationToken);
                return Ok(userId);
            }
            catch (InvalidRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return result ? Ok("User has been updated successfully") : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return result ? Ok("User has been removed successfully") : NotFound();
        }
    }
}
