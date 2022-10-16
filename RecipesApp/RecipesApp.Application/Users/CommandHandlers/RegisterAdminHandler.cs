using Azure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RecipesApp.Application.Users.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Users.CommandHandlers
{
    public class RegisterAdminHandler : IRequestHandler<RegisterAdmin, RegisterResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterAdminHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<RegisterResponse> Handle(RegisterAdmin request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists != null)
            {
                return new RegisterResponse
                { 
                    Status = "Error",
                    Message = "User already exists!" 
                };
            }

            User user = new User()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return new RegisterResponse
                {
                    Status = "Error",
                    Message = "User creation failed! Please check user details and try again."
                };
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return new RegisterResponse 
            { 
                Status = "Success", 
                Message = "User created successfully!" 
            };
        }
    }
}
