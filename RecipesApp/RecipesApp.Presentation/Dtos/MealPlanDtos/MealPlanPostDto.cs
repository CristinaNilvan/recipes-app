using RecipesApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Presentation.Dtos.MealPlanDtos
{
    public class MealPlanPostDto
    {
        [Required]
        public Recipe Breakfast { get; set; }

        [Required]
        public Recipe Lunch { get; set; }

        [Required]
        public Recipe Dinner { get; set; }

        [Required]
        public float Calories { get; set; }

        [Required]
        public float Fats { get; set; }

        [Required]
        public float Carbs { get; set; }

        [Required]
        public float Proteins { get; set; }
    }
}
