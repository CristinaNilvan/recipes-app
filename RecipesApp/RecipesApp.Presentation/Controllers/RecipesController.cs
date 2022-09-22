using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.ApproveRecipeFeature.Commands;
using RecipesApp.Application.FindRecipesByIngredientsFeature.Queries;
using RecipesApp.Application.MealPlannerFeature.Queries;
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
        public async Task<IActionResult> CreateRecipe([FromBody] RecipePostDto recipeDto)
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
        public async Task<IActionResult> GetRecipesByName(string recipeName,
            [FromQuery] PaginationParameters paginationParameters)
        {
            _logger.LogInformation(LogEvents.GetItem, "Getting recipes with name {name}", recipeName);

            var query = new GetRecipesByName
            {
                PaginationParameters = paginationParameters,
                RecipeName = recipeName
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemsNotFound, "Recipes with name {name} not found", recipeName);
                return NotFound();
            }

            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("all-recipes")]
        public async Task<IActionResult> GetAllRecipes([FromQuery] PaginationParameters paginationParameters)
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting all recipes");

            var query = new GetAllRecipes() { PaginationParameters = paginationParameters };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemsNotFound, "Recipes not found");
                return NotFound();
            }

            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        //[Route("approvedRecipes")] // => with/without route?
        public async Task<IActionResult> GetApprovedRecipes([FromQuery] PaginationParameters paginationParameters)
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting approved recipes");

            var query = new GetRecipesByApprovedStatus
            {
                PaginationParameters = paginationParameters,
                ApprovedStatus = true
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemsNotFound, "Approved recipes not found");
                return NotFound();
            }

            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("unapproved-recipes")]
        public async Task<IActionResult> GetUnapprovedRecipes([FromQuery] PaginationParameters paginationParameters)
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting unapproved recipes");

            var query = new GetRecipesByApprovedStatus
            {
                PaginationParameters = paginationParameters,
                ApprovedStatus = false
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemsNotFound, "Unapproved recipes not found");
                return NotFound();
            }

            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("find-recipes")]
        public async Task<IActionResult> FindRecipesByIngredients([FromQuery] IEnumerable<int> ingredientIds)
        {
            _logger.LogInformation(LogEvents.GetItems, "Finding recipes by ingredients");

            var query = new GetFoundRecipesByIngredients
            {
                IngredientIds = ingredientIds.ToList()
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemsNotFound, "Can't find recipes with at least one of the ingredients");
                return NotFound();
            }

            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("suggest-recipes")]
        public async Task<IActionResult> SuggestRecipes([FromQuery] RecipesSuggesterDto recipesSuggesterDto,
            [FromQuery] PaginationParameters paginationParameters)
        {
            _logger.LogInformation(LogEvents.GetItems, "Finding recipes by ingredient and quantity");

            var query = new GetSuggestedRecipes
            {
                PaginationParameters = paginationParameters,
                IngredientName = recipesSuggesterDto.IngredientName,
                IngredientQuantity = recipesSuggesterDto.IngredientQuantity
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemsNotFound, "Can't find recipes with a matching quantity");
                return NotFound();
            }

            var mappedResult = _mapper.Map<List<RecipeGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("generate-meal-plan")]
        public async Task<IActionResult> GetMealPlanFromRecipes([FromQuery] MealPlannerPostDto mealPlannerDto)
        {
            _logger.LogInformation(LogEvents.GenerateItem, "Generating meal plan from recipes");

            var query = new GetMealPlanFromRecipes
            {
                MealType = mealPlannerDto.MealType,
                Calories = mealPlannerDto.Calories
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GenerateItemNotFound, "Can't find recipes to generate meal plan");
                return NotFound();
            }

            var mappedResult = _mapper.Map<MealPlannerGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpPatch]
        [Route("{recipeId}")]
        public async Task<IActionResult> UpdateRecipe(int recipeId, [FromBody] RecipePatchDto recipeDto)
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

        [HttpPatch]
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
