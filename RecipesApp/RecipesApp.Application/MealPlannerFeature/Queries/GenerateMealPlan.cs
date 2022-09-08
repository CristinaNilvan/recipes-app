using MediatR;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlannerFeature.Queries
{
    public class GenerateMealPlan : IRequest<MealPlan>
    {
        public MealType MealType { get; set; }
        public float Calories { get; set; }
    }
}
