using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Utils;

namespace RecipesApp.Domain.Models
{
    public class Recipe
    {
        //for dummy data
        public Recipe(int id, string name, string author, string description, MealType mealType, ServingTime servingTime,
            List<Ingredient> ingredients, float calories)
        {
            Id = id;
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Calories = ModelUtils.CalculateTwoDecimalFloat(calories);
            Servings = 4;
            Ingredients = new List<Ingredient>(ingredients);
            Approved = true;
        }

        public Recipe(int id, string name, string author, string description, MealType mealType, ServingTime servingTime,
            float servings, List<Ingredient> ingredients)
        {
            Id = id;
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Servings = ModelUtils.CalculateTwoDecimalFloat(servings);
            Ingredients = new List<Ingredient>(ingredients);
            CalculateNutritionalValuesForRecipe();
            Approved = false;
        }

        public Recipe(string name, string author, string description, MealType mealType, ServingTime servingTime,
            float servings, List<Ingredient> ingredients)
        {
            Name = name;
            Author = author;
            Description = description;
            MealType = mealType;
            ServingTime = servingTime;
            Servings = ModelUtils.CalculateTwoDecimalFloat(servings);
            Ingredients = new List<Ingredient>(ingredients);
            CalculateNutritionalValuesForRecipe();
            Approved = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public MealType MealType { get; set; }
        public ServingTime ServingTime { get; set; }
        public float Servings { get; set; }
        public float Calories { get; set; }
        public float Fats { get; set; }
        public float Carbs { get; set; }
        public float Proteins { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public bool Approved { get; set; } = false;

        public override string ToString()
        {
            return $"Id : {Id}; Name : {Name}; Type : {MealType}-{ServingTime}; Calories : {Calories}";
        }

        public override bool Equals(object obj)
        {
            return obj is Recipe recipe &&
                   Id == recipe.Id &&
                   Name == recipe.Name &&
                   Author == recipe.Author &&
                   Description == recipe.Description &&
                   MealType == recipe.MealType &&
                   ServingTime == recipe.ServingTime &&
                   Calories == recipe.Calories &&
                   Fats == recipe.Fats &&
                   Carbs == recipe.Carbs &&
                   Proteins == recipe.Proteins &&
                   EqualityComparer<List<Ingredient>?>.Default.Equals(Ingredients, recipe.Ingredients);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Author);
            hash.Add(Description);
            hash.Add(MealType);
            hash.Add(ServingTime);
            hash.Add(Calories);
            hash.Add(Fats);
            hash.Add(Carbs);
            hash.Add(Proteins);
            hash.Add(Ingredients);
            return hash.ToHashCode();
        }

        private void CalculateNutritionalValuesForRecipe()
        {
            Calories = ModelUtils.CalculateTwoDecimalFloat(Ingredients.Sum(x => x.Calories));
            Fats = ModelUtils.CalculateTwoDecimalFloat(Ingredients.Sum(x => x.Fats));
            Carbs = ModelUtils.CalculateTwoDecimalFloat(Ingredients.Sum(x => x.Carbs));
            Proteins = ModelUtils.CalculateTwoDecimalFloat(Ingredients.Sum(x => x.Proteins));
        }
    }
}
