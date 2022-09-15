using RecipesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Domain.Models
{
    public class Ingredient
    {
        public Ingredient()
        {

        }

        public Ingredient(int id, string name, IngredientCategory category, float calories, float fats, float carbs,
            float proteins)
        {
            Id = id;
            Name = name;
            Category = category;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
            Approved = false;
        }

        public Ingredient(string name, IngredientCategory category, float calories, float fats, float carbs, float proteins)
        {
            Name = name;
            Category = category;
            Calories = calories;
            Fats = fats;
            Carbs = carbs;
            Proteins = proteins;
            Approved = false;
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public IngredientCategory Category { get; set; }

        public float Calories { get; set; }

        public float Fats { get; set; }

        public float Carbs { get; set; }

        public float Proteins { get; set; }

        public bool Approved { get; set; } = false;

        public IngredientImage IngredientImage { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}; Name : {Name}; Category : {Category}; Calories : {Calories}";
        }
    }
}
