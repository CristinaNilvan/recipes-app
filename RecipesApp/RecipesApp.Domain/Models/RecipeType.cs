namespace RecipesApp.Domain.Models
{
    public class RecipeType
    {
        public int Id { get; set; }
        public MealType MealType { get; set; }
        public ServingTime ServingTime { get; set; }
    }
}
