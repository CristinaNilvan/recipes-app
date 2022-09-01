using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.MealPlannerFeature.Commands;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.MealPlanDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/mealPlans")]
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
        public async Task<IActionResult> GenerateMealPlan([FromBody] MealPlanPostDto mealPlanDto)
        {
            _logger.LogInformation(LogEvents.GenerateItem, "Generating meal plan");

            var command = new GenerateMealPlan
            {
                MealType = mealPlanDto.MealType,
                Calories = mealPlanDto.Calories
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<MealPlanGetDto>(result);

            return Ok(mappedResult);
        }
    }
}
