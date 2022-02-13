using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Request.User;
using Api.Models.Response.User;
using Application.Commands.User;
using Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Api.Controllers.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUserAsync(CreateUserRequest userRequest)
        {
            Log.Logger.Information("Called end point create user");

            var response = await _mediator.Send(new CreateUserCommand(userRequest));

            if (response is null)
                return BadRequest();

            return Created(nameof(CreateUserAsync), (UserResponse)response);
        }

        [HttpPatch("{userId}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUserAsync(string userId, UpdateUserRequest updateUserRequest)
        {
            Log.Logger.Information("Called end point update user");

            var response = await _mediator.Send(new UpdateUserCommand(userId, updateUserRequest));

            if (response is null)
                return NotFound();

            return Ok((UserResponse)response);
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUserAsync(string userId)
        {
            Log.Logger.Information("Called end point delete user");

            var response = await _mediator.Send(new DeleteUserCommand(userId));

            if (response is false)
                return NotFound();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUsersAsync()
        {
            Log.Logger.Information("Called end point get users");

            var response = await _mediator.Send(new GetUsersQuery());
            
            return Ok(response.Select(u => (UserResponse)u));
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUserByIdAsync(string userId)
        {
            Log.Logger.Information("Called end point get user by id");

            var response = await _mediator.Send(new GetUserByIdQuery(userId));

            if (response is null)
                return NotFound();

            return Ok((UserResponse)response);
        }
    }
}