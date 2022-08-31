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
        public async Task<IActionResult> CreateIngredient([FromBody] IngredientPutPostDto ingredient)
        {
            _logger.LogInformation(LogEvents.CreateItem, "Creating ingredient");

            var command = new CreateIngredient
            {
                Name = ingredient.Name,
                Category = ingredient.Category,
                Calories = ingredient.Calories,
                Fats = ingredient.Fats,
                Carbs = ingredient.Carbs,
                Proteins = ingredient.Proteins
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

            var mappedResult = _mapper.Map<IngredientGetDto>(result);

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
        [Route("allIngredients")]
        public async Task<IActionResult> GetAllIngredients()
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting all ingredients");

            var query = new GetAllIngredients();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<IngredientGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        //[Route("approvedIngredients")] // => with/without route?
        public async Task<IActionResult> GetApprovedIngredients()
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting approved ingredients");

            var query = new GetIngredientsByApprovedStatus { ApprovedStatus = true };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<IngredientGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("unapprovedIngredients")]
        public async Task<IActionResult> GetUnapprovedIngredients()
        {
            _logger.LogInformation(LogEvents.GetItems, "Getting unapproved ingredients");

            var query = new GetIngredientsByApprovedStatus { ApprovedStatus = false };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<IngredientGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{ingredientId}")]
        public async Task<IActionResult> UpdateIngredient(int ingredientId, [FromBody] IngredientPutPostDto ingredient)
        {
            _logger.LogInformation(LogEvents.UpdateItem, "Updating ingredient {id}", ingredientId);

            var command = new UpdateIngredient
            {
                IngredientId = ingredientId,
                Name = ingredient.Name,
                Category = ingredient.Category,
                Calories = ingredient.Calories,
                Fats = ingredient.Fats,
                Carbs = ingredient.Carbs,
                Proteins = ingredient.Proteins
            };

            var result = await _mediator.Send(command);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.UpdateItemNotFound, "Ingredient {id} not found", ingredientId);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("unapprovedIngredients/{ingredientId}")]
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
