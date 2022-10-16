using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.MealPlans.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.MealPlans.CommandHandlers
{
    public class CreateMealPlanHandler : IRequestHandler<CreateMealPlan, MealPlan>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMealPlanHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MealPlan> Handle(CreateMealPlan request, CancellationToken cancellationToken)
        {
            var mealPlan = new MealPlan(request.Breakfast, request.Lunch, request.Dinner, request.Calories, request.Fats,
                request.Carbs, request.Proteins);

            await _unitOfWork.MealPlanRepository.Create(mealPlan);
            await _unitOfWork.Save();

            return mealPlan;
        }
    }
}
