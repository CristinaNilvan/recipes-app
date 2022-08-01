using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Models;
using RecipesApp.Domain.Enums;

namespace RecipesApp.Console
{
    internal class PopulateLists
    {
        public static List<Ingredient> PopulateIngredients()
        {
            return new List<Ingredient>()
            {
                new Ingredient(1, "ing1", IngredientCategory.Fruit, 30, 15, 20, 15),
                new Ingredient(2, "ing2", IngredientCategory.Meat, 30, 15, 20, 15),
                new Ingredient(3, "ing3", IngredientCategory.Fruit, 30, 15, 20, 15),
                new Ingredient(4, "ing4", IngredientCategory.Meat,30, 15, 20, 15),
                new Ingredient(5, "ing5", IngredientCategory.Vegetable, 30, 15, 20, 15),
                new Ingredient(6, "ing6", IngredientCategory.Others, 30, 15, 20, 15),
                new Ingredient(7, "ing7", IngredientCategory.Dairy, 30, 15, 20, 15),
                new Ingredient(8, "ing8", IngredientCategory.Herbs, 30, 15, 20, 15),
                new Ingredient(9, "ing9", IngredientCategory.Vegetable, 30, 15, 20, 15),
                new Ingredient(10, "ing10", IngredientCategory.Dairy, 30, 15, 20, 15)
            };
        }

        public static List<Recipe> PopulateRecipes()
        {
            var normalBreakfast = new RecipeType(MealType.Normal, ServingTime.Breakfast);
            var normalLunch = new RecipeType(MealType.Normal, ServingTime.Lunch);
            var normalDinner = new RecipeType(MealType.Normal, ServingTime.Dinner);

            var vegetarianBreakfast = new RecipeType(MealType.Vegetarian, ServingTime.Breakfast);
            var vegetarianLunch = new RecipeType(MealType.Vegetarian, ServingTime.Lunch);
            var vegetarianDinner = new RecipeType(MealType.Vegetarian, ServingTime.Dinner);

            var veganBreakfast = new RecipeType(MealType.Vegan, ServingTime.Breakfast);
            var veganLunch = new RecipeType(MealType.Vegan, ServingTime.Lunch);
            var veganDinner = new RecipeType(MealType.Vegan, ServingTime.Dinner);

            return new List<Recipe>()
            {
                new Recipe(1, "rec1", "auth1", "desc1", normalBreakfast, PopulateIngredients(), 560),
                new Recipe(2, "rec2", "auth2", "desc2", normalBreakfast, PopulateIngredients(), 490),
                new Recipe(3, "rec3", "auth3", "desc3", normalBreakfast, PopulateIngredients(), 350),
                new Recipe(4, "rec4", "auth4", "desc4", normalLunch, PopulateIngredients(), 600),
                new Recipe(5, "rec5", "auth5", "desc5", normalLunch, PopulateIngredients(), 470),
                new Recipe(6, "rec6", "auth6", "desc6", normalLunch, PopulateIngredients(), 500),
                new Recipe(7, "rec7", "auth7", "desc7", normalDinner, PopulateIngredients(), 600),
                new Recipe(8, "rec8", "auth8", "desc8", normalDinner, PopulateIngredients(), 380),
                new Recipe(9, "rec9", "auth9", "desc9", normalDinner, PopulateIngredients(), 580),
                new Recipe(10, "rec10", "auth10", "desc10", normalDinner, PopulateIngredients(), 420),
            };
        }
    }
}
