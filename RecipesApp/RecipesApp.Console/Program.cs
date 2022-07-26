using RecipesApp.Domain.Models;

//Added for verification
var ing01 = new Ingredient(1, "faina", 1, 1, 1, 1);
var ing02 = new Ingredient(2, "caisa", 2, 2, 2, 2);
var ing03 = new Ingredient(3, "ou", 3, 3, 3, 3);

var rec01 = new Recipe(1, "r1");
rec01.AddIngredient(ing01);

var rec02 = new Recipe(2, "r2");
rec02.AddIngredient(ing02);

var rec03 = new Recipe(3, "r3");
rec02.AddIngredient(ing03);

var mealPlan = new MealPlan();
mealPlan.Breakfast = rec01;
mealPlan.Lunch = rec02;
mealPlan.Dinner = rec03;

mealPlan.SetCalories();

Console.WriteLine($"The meal plan has {mealPlan.Calories} calories.");
Console.ReadKey();