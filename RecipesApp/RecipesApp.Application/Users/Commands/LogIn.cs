using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Users.Commands
{
    public class LogIn : IRequest<JwtResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
