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

        public Ingredient(string? name, IngredientCategory category, int calories, float fats, float carbs, float proteins)
        {
            Name = name;
            Category = category;
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

        public override string? ToString()
        {
            return $"{Id} {Name} {Category}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Ingredient ingredient &&
                   Id == ingredient.Id &&
                   Name == ingredient.Name &&
                   Category == ingredient.Category &&
                   Calories == ingredient.Calories &&
                   Fats == ingredient.Fats &&
                   Carbs == ingredient.Carbs &&
                   Proteins == ingredient.Proteins;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Category, Calories, Fats, Carbs, Proteins);
        }
    }
}
