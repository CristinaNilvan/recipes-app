﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.MealPlannerFeature.Commands;
using RecipesApp.Presentation.Dtos.MealPlanDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/mealPlans")]
    [ApiController]
    public class MealPlansController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MealPlansController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateMealPlan([FromBody] MealPlanPostDto mealPlanPostDto)
        {
            var command = new GenerateMealPlan
            {
                MealType = mealPlanPostDto.MealType,
                Calories = mealPlanPostDto.Calories
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<MealPlanGetDto>(result);

            return Ok(mappedResult);
        }
    }
}
