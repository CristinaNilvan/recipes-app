using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RecipesApp.Application.Settings;
using RecipesApp.Application.Users.Commands;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.AuthDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static RecipesApp.Presentation.Dtos.AuthDtos.RegisterResponseDto;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(IMediator mediator,
        UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _mediator = mediator;

            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
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
    }
}
