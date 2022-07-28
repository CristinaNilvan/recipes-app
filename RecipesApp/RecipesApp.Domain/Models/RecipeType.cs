using RecipesApp.Domain.Enums;

namespace RecipesApp.Domain.Models
{
    public class RecipeType
    {
        public int Id { get; set; }
        public MealType MealType { get; set; }
        public ServingTime ServingTime { get; set; }

        public override string? ToString()
        {
            return $"{MealType}-{ServingTime}";
        }
    }
}
