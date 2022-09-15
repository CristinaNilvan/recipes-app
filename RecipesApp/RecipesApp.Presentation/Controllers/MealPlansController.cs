using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.MealPlans.Commands;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.MealPlanDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/meal-plans")]
    [ApiController]
    public class MealPlansController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public MealPlansController(IMediator mediator, IMapper mapper, ILogger<MealPlansController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMealPlan([FromBody] MealPlanPostDto mealPlanDto)
        {
            _logger.LogInformation(LogEvents.CreateItem, "Creating meal plan");

            var command = new CreateMealPlan
            {
                Breakfast = mealPlanDto.Breakfast,
                Lunch = mealPlanDto.Lunch,
                Dinner = mealPlanDto.Dinner,
                Calories = mealPlanDto.Calories,
                Fats = mealPlanDto.Fats,
                Carbs = mealPlanDto.Carbs,
                Proteins = mealPlanDto.Proteins
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<MealPlanGetDto>(result);

            return Ok(mappedResult);
        }
    }
}
