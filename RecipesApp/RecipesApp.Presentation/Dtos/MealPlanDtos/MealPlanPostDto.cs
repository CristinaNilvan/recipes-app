using RecipesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.MealPlanDtos
{
    public class MealPlanPostDto
    {
        [Required]
        public MealType MealType { get; set; }

        [Required]
        [Range(1000, 3000)]
        public float Calories { get; set; }
    }
}
