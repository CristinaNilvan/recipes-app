﻿using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Domain.Models
{
    public class Ingredient
    {
        public Ingredient()
        {

        }

        //for dummy data
        public Ingredient(int id, string name, IngredientCategory category, float calories, float fats, float carbs, float proteins)
        {
            Id = id;
            Name = name;
            Category = category;
            Calories = ModelUtils.CalculateTwoDecimalFloat(calories);
            Fats = ModelUtils.CalculateTwoDecimalFloat(fats);
            Carbs = ModelUtils.CalculateTwoDecimalFloat(carbs);
            Proteins = ModelUtils.CalculateTwoDecimalFloat(proteins);
            Approved = true;
        }

        public Ingredient(string name, IngredientCategory category, float calories, float fats, float carbs, float proteins)
        {
            Name = name;
            Category = category;
            Calories = ModelUtils.CalculateTwoDecimalFloat(calories);
            Fats = ModelUtils.CalculateTwoDecimalFloat(fats);
            Carbs = ModelUtils.CalculateTwoDecimalFloat(carbs);
            Proteins = ModelUtils.CalculateTwoDecimalFloat(proteins);
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

        //remove
        public float Quantity { get; set; }

        //public List<Recipe> Recipes { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}; Name : {Name}; Category : {Category}; Calories : {Calories}";
        }
    }
}
