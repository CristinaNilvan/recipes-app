using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.ApproveIngredientFeature.Commands;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Dtos.IngredientDtos;
using RecipesApp.Presentation.Dtos.RecipeDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public IngredientsController(IMediator mediator, IMapper mapper, ILogger<IngredientsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] IngredientPostDto ingredientDto)
        {
            _logger.LogInformation(LogEvents.CreateItem, "Creating ingredient");

            var command = new CreateIngredient
            {
                Name = ingredientDto.Name,
                Category = ingredientDto.Category,
                Calories = ingredientDto.Calories,
                Fats = ingredientDto.Fats,
                Carbs = ingredientDto.Carbs,
                Proteins = ingredientDto.Proteins
            };

            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<IngredientGetDto>(result);

            return CreatedAtAction(nameof(GetIngredientById), new { ingredientId = mappedResult.Id }, mappedResult);
        }

        [HttpGet]
        [Route("{ingredientId:int}")]
        public async Task<IActionResult> GetIngredientById(int ingredientId)
        {
            _logger.LogInformation(LogEvents.GetItem, "Getting ingredient {id}", ingredientId);

            var query = new GetIngredientById { IngredientId = ingredientId };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, "Ingredient {id} not found", ingredientId);
                return NotFound();
            }

            var mappedResult = _mapper.Map<IngredientGetByIdDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{ingredientName}")]
        public async Task<IActionResult> GetIngredientByName(string ingredientName)
        {
            _logger.LogInformation(LogEvents.GetItem, "Getting ingredient {name}", ingredientName);

            var query = new GetIngredientByName { IngredientName = ingredientName };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound, "Ingredient {name} not found", ingredientName);
                return NotFound();
            }

            var mappedResult = _mapper.Map<IngredientGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("all-ingredients")]
        public async Task<IActionResult> GetAllIngredients([FromQuery] PaginationParameters paginationParameters)
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting all ingredients");

            var query = new GetAllIngredients() { PaginationParameters = paginationParameters };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<IngredientGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        //[Route("approved-ingredients")] // => with/without route?
        public async Task<IActionResult> GetApprovedIngredients([FromQuery] PaginationParameters paginationParameters)
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting approved ingredients");

            var query = new GetIngredientsByApprovedStatus
            {
                PaginationParameters = paginationParameters,
                ApprovedStatus = true 
            };

            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<IngredientGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("unapproved-ingredients")]
        public async Task<IActionResult> GetUnapprovedIngredients([FromQuery] PaginationParameters paginationParameters)
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting unapproved ingredients");

            var query = new GetIngredientsByApprovedStatus
            {
                PaginationParameters = paginationParameters,
                ApprovedStatus = false
            };

            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<IngredientGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpPatch]
        [Route("{ingredientId}")]
        public async Task<IActionResult> UpdateIngredient(int ingredientId, [FromBody] IngredientPatchDto ingredientDto)
        {
            _logger.LogInformation(LogEvents.UpdateItem, "Updating ingredient {id}", ingredientId);

            var command = new UpdateIngredient
            {
                Id = ingredientId,
                Name = ingredientDto.Name,
                Category = ingredientDto.Category,
                Calories = ingredientDto.Calories,
                Fats = ingredientDto.Fats,
                Carbs = ingredientDto.Carbs,
                Proteins = ingredientDto.Proteins
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.UpdateItemNotFound, "Ingredient {id} not found", ingredientId);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch]
        [Route("unapproved-ingredients/{ingredientId}")]
        public async Task<IActionResult> ApproveIngredient(int ingredientId)
        {
            _logger.LogInformation(LogEvents.UpdateItem, "Approving ingredient {id}", ingredientId);

            var command = new ApproveIngredient { IngredientId = ingredientId };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.UpdateItemNotFound, "Ingredient {id} not found", ingredientId);
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{ingredientId}")]
        public async Task<IActionResult> DeleteIngredient(int ingredientId)
        {
            _logger.LogInformation(LogEvents.DeleteItem, "Deleting ingredient {id}", ingredientId);

            var command = new DeleteIngredient { IngredientId = ingredientId };
            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.DeleteItemNotFound, "Ingredient {id} not found", ingredientId);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [Route("{ingredientId}/image")]
        public async Task<IActionResult> AddImageToIngredient(int ingredientId, IFormFile File)
        {
            _logger.LogInformation(LogEvents.AddToItem, "Adding image to ingredient {id}", ingredientId);

            var command = new AddImageToIngredient
            {
                IngredientId = ingredientId,
                File = File,
                ContainerName = "ingredientimages"
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.AddToItemNotFound, "Ingredient {id} or image not found", ingredientId);
                return NotFound();
            }

            var mappedResult = _mapper.Map<IngredientGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{ingredientId}/image")]
        public async Task<IActionResult> RemoveImageFromIngredient(int ingredientId)
        {
            _logger.LogInformation(LogEvents.RemoveFromItem, "Removing image from ingredient {id}", ingredientId);

            var command = new RemoveImageFromIngredient
            {
                IngredientId = ingredientId,
                ContainerName = "ingredientimages"
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.RemoveFromItemNotFound, "Ingredient {id} not found", ingredientId);
                return NotFound();
            }

            var mappedResult = _mapper.Map<IngredientGetDto>(result);

            return Ok(mappedResult);
        }
    }
}
