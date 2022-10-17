using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.AuthDtos
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
