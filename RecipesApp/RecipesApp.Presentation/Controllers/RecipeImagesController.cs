using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.RecipeImages.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/recipe-images")]
    [ApiController]
    public class RecipeImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public RecipeImagesController(IMediator mediator, IMapper mapper, ILogger<RecipeImagesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("recipes/{recipeId}")] // => ??
        public async Task<IActionResult> GetRecipeImageUrlByRecipeId(int recipeId)
        {
            _logger.LogInformation(LogEvents.GetItem, "Getting recipe image by ingredient id {id}", recipeId);

            var query = new GetRecipeImageUrlByRecipeId { RecipeId = recipeId };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound,
                    "Recipe image with recipe id {id} not found", recipeId);

                return NotFound();
            }

            return Ok(result);
        }
    }
}
