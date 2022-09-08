using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlans.Commands
{
    public class CreateMealPlan : IRequest<MealPlan>
    {
        public Recipe Breakfast { get; set; }
        public Recipe Lunch { get; set; }
        public Recipe Dinner { get; set; }
    }
}
