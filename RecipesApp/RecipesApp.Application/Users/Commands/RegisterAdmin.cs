using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Users.Commands
{
    public class RegisterAdmin : IRequest<RegisterResponse>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
