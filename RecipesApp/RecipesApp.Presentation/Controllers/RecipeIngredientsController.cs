using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.RecipeIngredients.Commands;
using RecipesApp.Application.RecipeIngredients.Queries;
using RecipesApp.Presentation.Dtos.RecipeIngredientDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RecipeIngredientsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("{ingredientId}")] 
        public async Task<IActionResult> CreateRecipeIngredient(int ingredientId,
            [FromBody] float quantity)
        {
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
            var query = new GetRecipeIngredientById { RecipeIngredientId = recipeIngredientId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<RecipeIngredientGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{ingredientId}")] 
        public async Task<IActionResult> GetRecipeIngredientsByIgredientId(int ingredientId)
        {
            var query = new GetRecipeIngredientsByIngredientId { IngredientId = ingredientId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<RecipeIngredientGetDto>>(result);

            return Ok(mappedResult);
        }
    }
}
