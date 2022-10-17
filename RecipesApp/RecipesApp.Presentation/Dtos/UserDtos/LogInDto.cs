using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.AuthDtos
{
    public class LogInDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
