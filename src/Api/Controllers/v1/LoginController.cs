using System.Threading.Tasks;
using Api.Models.Request.Login;
using Application.Commands.Login;
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
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> LoginUserAsync(LoginRequest loginRequest)
        {
            Log.Logger.Information("Called end point create user");

            var result = await _mediator.Send(new LoginUserCommand(loginRequest.UserLoginName, loginRequest.Password));

            if (result is false)
                return BadRequest();

            return Ok();
        }
    }
}