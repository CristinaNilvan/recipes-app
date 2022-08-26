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
            float servings)
        {
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Servings = ModelUtils.CalculateTwoDecimalFloat(servings);
            Approved = false;
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

        public float Servings { get; set; }

        public float Calories { get; set; } = 0;

        public float Fats { get; set; } = 0;

        public float Carbs { get; set; } = 0;

        public float Proteins { get; set; } = 0;

        public bool Approved { get; set; } = false;

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
