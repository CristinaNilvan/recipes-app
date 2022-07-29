using RecipesApp.Domain.Enums;

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

        //Added for FileAssignment
        public Ingredient(int id, string? name)
        { 
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public IngredientCategory Category { get; set; }
        public int Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public double Quantity { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Ingredient ingredient &&
                   Id == ingredient.Id &&
                   Name == ingredient.Name &&
                   Category == ingredient.Category &&
                   Calories == ingredient.Calories;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Category, Calories, Fats, Carbs, Proteins, Quantity);
        }

        public override string? ToString()
        {
            return $"{Id} {Name} {Category} {Calories}";
        }
    }
}
