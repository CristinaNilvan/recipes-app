using MediatR;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlannerFeature.Commands
{
    public class GenerateMealPlan : IRequest<MealPlan>
    {
        public MealType MealType { get; set; }
        public float Calories { get; set; }

        //delete
        public List<Recipe> Recipes { get; set; }
    }
}
