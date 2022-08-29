using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.ApproveRecipeFeature.Commands;
using RecipesApp.Application.FindRecipesByIngredientsFeature.Queries;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Application.Recipes.Queries;
using RecipesApp.Application.SuggestRecipesFeature.Queries;
using RecipesApp.Presentation.Dtos.RecipeDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;

        public RecipesController(IMediator mediator, IMapper mapper, IBlobService blobService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _blobService = blobService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] RecipePutPostDto recipe)
        {
            var command = new CreateRecipe
            {
                Name = recipe.Name,
                Author = recipe.Author,
                Description = recipe.Description,
                MealType = recipe.MealType,
                ServingTime = recipe.ServingTime,
                Servings = recipe.Servings
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return CreatedAtAction(nameof(GetRecipeById), new { recipeId = mappedResult.Id }, mappedResult);
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
        [Route("allRecipes")]
        public async Task<IActionResult> GetAllRecipes()
        {
            var query = new GetAllRecipes();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        //[Route("approvedRecipes")] // => with/without route?
        public async Task<IActionResult> GetApprovedRecipes()
        {
            var query = new GetRecipesByApprovedStatus { ApprovedStatus = true };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("unapprovedRecipes")]
        public async Task<IActionResult> GetUnapprovedRecipes()
        {
            var query = new GetRecipesByApprovedStatus { ApprovedStatus = false };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("recipesFinder")]
        public async Task<IActionResult> FindRecipesByIngredients([FromQuery] IEnumerable<int> ingredientIds)
        {
            var query = new FindRecipesByIngredients { IngredientIds = ingredientIds.ToList() };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("recipesSuggester")]
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
        [Route("{recipeId}")]
        public async Task<IActionResult> UpdateRecipe(int recipeId, [FromBody] RecipePutPostDto recipe)
        {
            var command = new UpdateRecipe
            {
                RecipeId = recipeId,
                Name = recipe.Name,
                Author = recipe.Author,
                Description = recipe.Description,
                MealType = recipe.MealType,
                ServingTime = recipe.ServingTime,
                Servings = recipe.Servings
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpPut]
        [Route("unapprovedRecipes/{recipeId}")]
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

        [HttpPost]
        [Route("{recipeId}/recipeIngredients/{recipeIngredientId}")]
        public async Task<IActionResult> AddRecipeIngredientToRecipe(int recipeId, int recipeIngredientId)
        {
            var command = new AddRecipeIngredientToRecipe
            {
                RecipeId = recipeId,
                RecipeIngredientId = recipeIngredientId
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{recipeId}/recipeIngredients/{recipeIngredientId}")]
        public async Task<IActionResult> RemoveRecipeIngredientFromRecipe(int recipeId, int recipeIngredientId)
        {
            var command = new RemoveRecipeIngredientFromRecipe
            {
                RecipeId = recipeId,
                RecipeIngredientId = recipeIngredientId
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("{recipeId}/image")]
        public async Task<IActionResult> AddImageToRecipe(int recipeId, IFormFile File)
        {
            var command = new AddImageToRecipe
            {
                RecipeId = recipeId,
                File = File,
                ContainerName = "recipeimages"
            };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return Ok(mappedResult);
        }
    }
}
