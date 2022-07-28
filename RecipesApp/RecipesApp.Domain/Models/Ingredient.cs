namespace RecipesApp.Domain.Models
{
    public class Ingredient
    {
        public Ingredient(int id, string? name, IngredientCategory category, int calories, float fats, float carbs, float proteins)
        {
            Id = id;
            Name = name;
            Category = category;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
        }

        //Added for verification
        public Ingredient(int id, string? name, int calories, float fats, float carbs, float proteins)
        {
            Id = id;
            Name = name;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public IngredientCategory Category { get; set; }
        public int Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public double Quantity { get; set; }
    }
}
