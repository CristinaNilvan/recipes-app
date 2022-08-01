using RecipesApp.Domain.Enums;

namespace RecipesApp.Domain.Models
{
    public class RecipeType
    {
        public RecipeType(MealType mealType, ServingTime servingTime)
        {
            MealType = mealType;
            ServingTime = servingTime;
        }

        public int Id { get; set; }
        public MealType MealType { get; set; }
        public ServingTime ServingTime { get; set; }

        public override string? ToString()
        {
            return $"{MealType} - {ServingTime}";
        }
    }
}
