using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.CommandHandlers
{
    public class RecipesSuggesterUtils
    {
        public static List<Recipe> FilterByIngredientName(string ingredientName, List<Recipe> recipes)
        {
            var filteredRecipes = new List<Recipe>();
            
            foreach (var recipe in recipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (ingredient.Name == ingredientName)
                    {
                        filteredRecipes.Add(recipe);
                    }
                }
            }

            return filteredRecipes;
        }

        public static List<Recipe> FilterByIngredientQuantity(float ingredientQuantity, List<Recipe> recipes)
        {
            var filteredRecipes = new List<Recipe>();

            foreach (var recipe in recipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (ingredient.Quantity >= ingredientQuantity)
                    {
                        filteredRecipes.Add(recipe);
                    }
                }
            }

            return filteredRecipes;
        }
    }
}
