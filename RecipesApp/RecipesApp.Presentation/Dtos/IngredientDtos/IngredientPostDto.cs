using RecipesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.IngredientDtos
{
    public class IngredientPostDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public IngredientCategory Category { get; set; }

        [Required]
        [Range(1, 1000)]
        public float Calories { get; set; }

        [Required]
        [Range(1, 500)]
        public float Fats { get; set; }

        [Required]
        [Range(1, 500)]
        public float Carbs { get; set; }

        [Required]
        [Range(1, 500)]
        public float Proteins { get; set; }
    }
}
