using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Domain.Models
{
    public class Ingredient
    {
        private float _calories;
        private float _fats;
        private float _carbs;
        private float _proteins;

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

        public float Calories { get => _calories; set => _calories = ModelUtils.CalculateTwoDecimalFloat(value); }

        public float Fats { get => _fats; set => _fats = ModelUtils.CalculateTwoDecimalFloat(value); }

        public float Carbs { get => _carbs; set => _carbs = ModelUtils.CalculateTwoDecimalFloat(value); }

        public float Proteins { get => _proteins; set => _proteins = ModelUtils.CalculateTwoDecimalFloat(value); }

        public bool Approved { get; set; } = false;

        public List<RecipeIngredient> RecipeIngredients { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}; Name : {Name}; Category : {Category}; Calories : {Calories}";
        }
    }
}
