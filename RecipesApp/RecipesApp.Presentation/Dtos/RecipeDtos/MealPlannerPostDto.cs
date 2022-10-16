using RecipesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.RecipeDtos
{
    public class MealPlannerPostDto
    {
        [Required]
        public MealType MealType { get; set; }

        [Required]
        [Range(1000, 5000)]
        public float Calories { get; set; }
    }
}
