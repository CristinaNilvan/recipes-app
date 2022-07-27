namespace RecipesApp.Domain.Models
{
    public class Recipe
    {
        public Recipe(int id, string? name, string? author, string? description, RecipeType? type, int calories, float fats,
            float carbs, float proteins, List<Ingredient>? ingredients)
        {
            Id = id;
            Name = name;
            Author = author;
            Description = description;
            Type = type;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
            Ingredients = new List<Ingredient>();
            Ingredients.AddRange(ingredients);
        }

        public Recipe(int id, string? name, string? author, string? description, RecipeType? type)
        {
            Id = id;
            Name = name;
            Author = author;
            Description = description;
            Type = type;
        }

        //Added for verification
        public Recipe(int id, string? name)
        {
            Id = id;
            Name = name;
            Ingredients = new List<Ingredient>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public RecipeType? Type { get; set; }
        public int Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            Calories += ingredient.Calories;
            Fats += ingredient.Fats;
            Carbs += ingredient.Carbs;
            Proteins += ingredient.Proteins;
        }
    }
}
