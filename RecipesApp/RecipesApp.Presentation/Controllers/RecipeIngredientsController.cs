using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.RecipeIngredients.Commands;
using RecipesApp.Application.RecipeIngredients.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.RecipeIngredientDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/recipe-ingredients")]
    [ApiController]
    public class RecipeIngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public RecipeIngredientsController(IMediator mediator, IMapper mapper, ILogger<RecipeIngredientsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [Route("{ingredientId}")]
        public async Task<IActionResult> CreateRecipeIngredient(int ingredientId, [FromBody] float quantity)
        {
            _logger.LogInformation(LogEvents.CreateItem, "Creating recipe ingredient");

            var command = new CreateRecipeIngredient
            {
                Quantity = quantity,
                IngredientId = ingredientId
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<RecipeIngredientGetDto>(result);

            return CreatedAtAction(nameof(GetRecipeIngredientById), new { recipeIngredientId = mappedResult.Id }, mappedResult);
        }

        [HttpGet]
        [Route("{recipeIngredientId}")]
        public async Task<IActionResult> GetRecipeIngredientById(int recipeIngredientId)
        {
            _logger.LogInformation(LogEvents.GetItem, "Getting recipe ingredient {id}", recipeIngredientId);

            var query = new GetRecipeIngredientById { RecipeIngredientId = recipeIngredientId };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, "Recipe ingredient {id} not found", recipeIngredientId);
                return NotFound();
            }

            var mappedResult = _mapper.Map<RecipeIngredientGetDto>(result);

            return Ok(mappedResult);
        }
    }
}
