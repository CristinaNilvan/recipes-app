using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Domain.Models
{
    public class Recipe
    {
        private float _servings;
        private float _calories;
        private float _fats;
        private float _carbs;
        private float _proteins;

        public Recipe()
        {

        }

        public Recipe(int id, string name, string author, string description, MealType mealType, ServingTime servingTime,
            float servings)
        {
            Id = id;
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Servings = servings;
            Approved = false;
        }

        public Recipe(string name, string author, string description, MealType mealType, ServingTime servingTime,
            float servings)
        {
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Servings = servings;
            Approved = false;
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(70)]
        public string Author { get; set; }

        [MaxLength(10000)]
        public string Description { get; set; }

        public MealType MealType { get; set; }

        public ServingTime ServingTime { get; set; }

        public float Servings { get => _servings; set => _servings = ModelUtils.CalculateTwoDecimalFloat(value); }

        public float Calories { get => _calories; set => _calories = ModelUtils.CalculateTwoDecimalFloat(value); }

        public float Fats { get => _fats; set => _fats = ModelUtils.CalculateTwoDecimalFloat(value); }

        public float Carbs { get => _carbs; set => _carbs = ModelUtils.CalculateTwoDecimalFloat(value); }

        public float Proteins { get => _proteins; set => _proteins = ModelUtils.CalculateTwoDecimalFloat(value); }

        public bool Approved { get; set; } = false;

        public RecipeImage RecipeImage { get; set; }

        public List<RecipeWithRecipeIngredient> RecipeWithRecipeIngredients { get; set; }

        public void AddRecipeWithRecipeIngredient(RecipeWithRecipeIngredient recipeWithRecipeIngredient)
        {
            RecipeWithRecipeIngredients.Add(recipeWithRecipeIngredient);

            Calories += ModelUtils.CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Calories,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);

            Fats += ModelUtils.CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Fats,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);

            Carbs += ModelUtils.CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Carbs,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);

            Proteins += ModelUtils.CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Proteins,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
        }

        public void RemoveRecipeWithRecipeIngredient(RecipeWithRecipeIngredient recipeWithRecipeIngredient)
        {
            RecipeWithRecipeIngredients.Remove(recipeWithRecipeIngredient);

            Calories -= ModelUtils.CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Calories,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);

            Fats -= ModelUtils.CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Fats,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);

            Carbs -= ModelUtils.CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Carbs,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);

            Proteins -= ModelUtils.CalculateNutritionalValue(recipeWithRecipeIngredient.RecipeIngredient.Ingredient.Proteins,
                recipeWithRecipeIngredient.RecipeIngredient.Quantity);
        }

        public override string ToString()
        {
            return $"Id : {Id}; Name : {Name}; Type : {MealType}-{ServingTime}; Calories : {Calories}";
        }
    }
}
