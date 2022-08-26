using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Domain.Models
{
    public class Recipe
    {
        public Recipe()
        {

        }

        public Recipe(string name, string author, string description, MealType mealType, ServingTime servingTime,
            float servings, List<RecipeIngredient> recipeIngredients)
        {
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Servings = ModelUtils.CalculateTwoDecimalFloat(servings);
            Approved = false;
            CalculateNutritionalValuesForRecipe(recipeIngredients);
        }

        // new used constructors
        public Recipe(int id, string name, string author, string description, MealType mealType, ServingTime servingTime,
            float servings, List<RecipeIngredient> recipeIngredients, List<RecipeWithRecipeIngredient> recipeWithRecipeIngredients)
        {
            Id = id;
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Servings = ModelUtils.CalculateTwoDecimalFloat(servings);
            Approved = false;
            RecipeWithRecipeIngredients = new List<RecipeWithRecipeIngredient>(recipeWithRecipeIngredients);
            CalculateNutritionalValuesForRecipe(recipeIngredients);
        }

        public Recipe(string name, string author, string description, MealType mealType, ServingTime servingTime,
            float servings, List<RecipeIngredient> recipeIngredients, List<RecipeWithRecipeIngredient> recipeWithRecipeIngredients)
        {
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Servings = ModelUtils.CalculateTwoDecimalFloat(servings);
            Approved = false;
            RecipeWithRecipeIngredients = new List<RecipeWithRecipeIngredient>(recipeWithRecipeIngredients);
            CalculateNutritionalValuesForRecipe(recipeIngredients);
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(70)]
        public string Author { get; set; }

        [MaxLength(10000)] // modified
        public string Description { get; set; }

        public MealType MealType { get; set; }

        public ServingTime ServingTime { get; set; }

        public float Servings { get; set; }

        public float Calories { get; set; } = 0;

        public float Fats { get; set; } = 0;

        public float Carbs { get; set; } = 0;

        public float Proteins { get; set; } = 0;

        public bool Approved { get; set; } = false;

        public List<RecipeWithRecipeIngredient> RecipeWithRecipeIngredients { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}; Name : {Name}; Type : {MealType}-{ServingTime}; Calories : {Calories}";
        }

        private void CalculateNutritionalValuesForRecipe(List<RecipeIngredient> recipeIngredients)
        {
            foreach (var recipeIngredient in recipeIngredients)
            {
                Calories += ModelUtils.CalculateNutritionalValue(recipeIngredient.Ingredient.Calories, recipeIngredient.Quantity);
                Fats += ModelUtils.CalculateNutritionalValue(recipeIngredient.Ingredient.Fats, recipeIngredient.Quantity);
                Carbs += ModelUtils.CalculateNutritionalValue(recipeIngredient.Ingredient.Carbs, recipeIngredient.Quantity);
                Proteins += ModelUtils.CalculateNutritionalValue(recipeIngredient.Ingredient.Proteins, recipeIngredient.Quantity);
            }
        }
    }
}
