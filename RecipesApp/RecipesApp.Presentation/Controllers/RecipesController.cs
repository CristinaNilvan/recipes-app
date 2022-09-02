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
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.RecipeDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public RecipesController(IMediator mediator, IMapper mapper, ILogger<RecipesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] RecipePutPostDto recipeDto)
        {
            _logger.LogInformation(LogEvents.CreateItem, "Creating recipe");

            var command = new CreateRecipe
            {
                Name = recipeDto.Name,
                Author = recipeDto.Author,
                Description = recipeDto.Description,
                MealType = recipeDto.MealType,
                ServingTime = recipeDto.ServingTime,
                Servings = recipeDto.Servings
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return CreatedAtAction(nameof(GetRecipeById), new { recipeId = mappedResult.Id }, mappedResult);
        }

        [HttpGet]
        [Route("{recipeId:int}")]
        public async Task<IActionResult> GetRecipeById(int recipeId)
        {
            _logger.LogInformation(LogEvents.GetItem, "Getting recipe {id}", recipeId);

            var query = new GetRecipeById { RecipeId = recipeId };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, "Recipe {id} not found", recipeId);
                return NotFound();
            }

            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{recipeName}")]
        public async Task<IActionResult> GetRecipesByName(string recipeName)
        {
            _logger.LogInformation(LogEvents.GetItem, "Getting recipe {id}", recipeName);

            var query = new GetRecipesByName { RecipeName = recipeName };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, "Recipe {id} not found", recipeName);
                return NotFound();
            }

            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("all-recipes")]
        public async Task<IActionResult> GetAllRecipes()
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting all recipes");

            var query = new GetAllRecipes();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        //[Route("approvedRecipes")] // => with/without route?
        public async Task<IActionResult> GetApprovedRecipes()
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting approved recipes");

            var query = new GetRecipesByApprovedStatus { ApprovedStatus = true };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("unapproved-recipes")]
        public async Task<IActionResult> GetUnapprovedRecipes()
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting unapproved recipes");

            var query = new GetRecipesByApprovedStatus { ApprovedStatus = false };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("recipes-finder")]
        public async Task<IActionResult> FindRecipesByIngredients([FromQuery] IEnumerable<int> ingredientIds)
        {
            _logger.LogInformation(LogEvents.GetItems, "Finding recipes by ingredients");

            var query = new FindRecipesByIngredients { IngredientIds = ingredientIds.ToList() };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("recipes-suggester")]
        public async Task<IActionResult> SuggestRecipes([FromQuery] RecipesSuggesterDto recipesSuggesterDto)
        {
            _logger.LogInformation(LogEvents.GetItems, "Finding recipes by ingredient and quantity");

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
        public async Task<IActionResult> UpdateRecipe(int recipeId, [FromBody] RecipePutPostDto recipeDto)
        {
            _logger.LogInformation(LogEvents.UpdateItem, "Updating recipe {id}", recipeId);

            var command = new UpdateRecipe
            {
                Id = recipeId,
                Name = recipeDto.Name,
                Author = recipeDto.Author,
                Description = recipeDto.Description,
                MealType = recipeDto.MealType,
                ServingTime = recipeDto.ServingTime,
                Servings = recipeDto.Servings
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.UpdateItemNotFound, "Recipe {id} not found", recipeId);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("unapproved-recipes/{recipeId}")]
        public async Task<IActionResult> ApproveRecipe(int recipeId)
        {
            _logger.LogInformation(LogEvents.UpdateItem, "Approving recipe {id}", recipeId);

            var command = new ApproveRecipe { RecipeId = recipeId };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.UpdateItemNotFound, "Recipe {id} not found", recipeId);
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{recipeId}")]
        public async Task<IActionResult> DeleteRecipe(int recipeId)
        {
            _logger.LogInformation(LogEvents.DeleteItem, "Deleting recipe {id}", recipeId);

            var command = new DeleteRecipe { RecipeId = recipeId };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.DeleteItemNotFound, "Recipe {id} not found", recipeId);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Route("{recipeId}/recipe-ingredients/{recipeIngredientId}")]
        public async Task<IActionResult> AddRecipeIngredientToRecipe(int recipeId, int recipeIngredientId)
        {
            _logger.LogInformation(LogEvents.AddToItem,
                "Adding recipe ingredient {recipeIngredientId} to recipe {id}", recipeIngredientId, recipeId);

            var command = new AddRecipeIngredientToRecipe
            {
                RecipeId = recipeId,
                RecipeIngredientId = recipeIngredientId
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.AddToItemNotFound, 
                    "Recipe {recipeId} or recipe ingredient {recipeIngredientId} not found", recipeId, recipeIngredientId);

                return NotFound();
            }

            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{recipeId}/recipe-ingredients/{recipeIngredientId}")]
        public async Task<IActionResult> RemoveRecipeIngredientFromRecipe(int recipeId, int recipeIngredientId)
        {
            _logger.LogInformation(LogEvents.RemoveFromItem, 
                "Removing recipe ingredient {recipeIngredientId} from recipe {id}", recipeIngredientId, recipeId);

            var command = new RemoveRecipeIngredientFromRecipe
            {
                RecipeId = recipeId,
                RecipeIngredientId = recipeIngredientId
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.RemoveFromItemNotFound,
                    "Recipe {recipeId} or recipe ingredient {recipeIngredientId} not found", recipeId, recipeIngredientId);

                return NotFound();
            }

            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("{recipeId}/image")]
        public async Task<IActionResult> AddImageToRecipe(int recipeId, IFormFile File)
        {
            _logger.LogInformation(LogEvents.AddToItem, "Adding image to recipe {id}", recipeId);

            var command = new AddImageToRecipe
            {
                RecipeId = recipeId,
                File = File,
                ContainerName = "recipeimages"
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.AddToItemNotFound, "Recipe {id} not found", recipeId);
                return NotFound();
            }

            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{recipeId}/image")]
        public async Task<IActionResult> RemoveImageFromRecipe(int recipeId)
        {
            _logger.LogInformation(LogEvents.RemoveFromItem, "Removing image from recipe {id}", recipeId);

            var command = new RemoveImageFromRecipe
            {
                RecipeId = recipeId,
                ContainerName = "recipeimages"
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.RemoveFromItemNotFound, "Recipe {id} or image not found", recipeId);
                return NotFound();
            }

            var mappedResult = _mapper.Map<RecipeGetDto>(result);

            return Ok(mappedResult);
        }
    }
}
