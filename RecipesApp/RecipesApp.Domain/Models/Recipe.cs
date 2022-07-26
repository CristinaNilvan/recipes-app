﻿using RecipesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Domain.Models
{
    public class Recipe
    {
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

        public float Servings { get; set; }

        public float Calories { get; set; }

        public float Fats { get; set; }

        public float Carbs { get; set; }

        public float Proteins { get; set; }

        public bool Approved { get; set; } = false;

        public RecipeImage RecipeImage { get; set; }

        public List<RecipeWithRecipeIngredient> RecipeWithRecipeIngredients { get; set; }

        public void AddRecipeWithRecipeIngredient(RecipeWithRecipeIngredient recipeWithRecipeIngredient)
        {
            RecipeWithRecipeIngredients.Add(recipeWithRecipeIngredient);
        }

        public void RemoveRecipeWithRecipeIngredient(RecipeWithRecipeIngredient recipeWithRecipeIngredient)
        {
            RecipeWithRecipeIngredients.Remove(recipeWithRecipeIngredient);
        }

        public override string ToString()
        {
            return $"Id : {Id}; Name : {Name}; Type : {MealType}-{ServingTime}; Calories : {Calories}";
        }
    }
}
