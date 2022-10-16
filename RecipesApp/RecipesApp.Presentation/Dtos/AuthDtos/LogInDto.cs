using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.AuthDtos
{
    public class LogInDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
