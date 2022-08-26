using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.ApproveRecipeFeature.Commands;
using RecipesApp.Application.FindRecipesByIngredientsFeature.Queries;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Application.SuggestRecipesFeature.Queries;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.IngredientDtos;
using RecipesApp.Presentation.Dtos.RecipeDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RecipesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{recipeId:int}")]
        public async Task<IActionResult> GetRecipeById(int recipeId)
        {
            var query = new GetRecipeById { RecipeId = recipeId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{recipeName}")]
        public async Task<IActionResult> GetRecipesByName(string recipeName)
        {
            var query = new GetRecipesByName { RecipeName = recipeName };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("AllRecipes")]
        public async Task<IActionResult> GetAllRecipes()
        {
            var query = new GetAllRecipes();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        //[Route("ApprovedRecipes")] // => with/without route?
        public async Task<IActionResult> GetApprovedRecipes()
        {
            var query = new GetRecipesByApprovedStatus { ApprovedStatus = true };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("UnapprovedRecipes")] 
        public async Task<IActionResult> GetUnapprovedRecipes()
        {
            var query = new GetRecipesByApprovedStatus { ApprovedStatus = false };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("RecipesFinder")] // => ok?
        public async Task<IActionResult> FindRecipesByIngredients([FromQuery] List<IngredientPutPostDto> ingredientPutPostDto)
        {
            var ingredients = _mapper.Map<List<Ingredient>>(ingredientPutPostDto);
            var query = new FindRecipesByIngredients { Ingredients = ingredients };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("RecipesSuggester")]
        public async Task<IActionResult> SuggestRecipes([FromQuery] RecipesSuggesterDto recipesSuggesterDto)
        {
            var query = new SuggestRecipes
            {
                IngredientName = recipesSuggesterDto.IngredientName,
                IngredientQuantity = recipesSuggesterDto.IngredientQuantity
            };

            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("UnapprovedRecipes/{recipeId}")]
        public async Task<IActionResult> ApproveRecipe(int recipeId)
        {
            var command = new ApproveRecipe { RecipeId = recipeId };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("{recipeId}")]
        public async Task<IActionResult> DeleteRecipe(int recipeId)
        {
            var command = new DeleteRecipe { RecipeId = recipeId };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }
    }
}
