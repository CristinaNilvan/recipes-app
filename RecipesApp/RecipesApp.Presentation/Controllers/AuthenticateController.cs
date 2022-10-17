using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.Users.Commands;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.AuthDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto registerDto)
        {
            var command = new RegisterAdmin
            {
                Username = registerDto.Username,
                Password = registerDto.Password,
            };

            var result = await _mediator.Send(command);

            if (result.Status == "Error")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn([FromBody] LogInDto logInDto)
        {
            var command = new LogIn
            {
                Username = logInDto.Username,
                Password = logInDto.Password,
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
