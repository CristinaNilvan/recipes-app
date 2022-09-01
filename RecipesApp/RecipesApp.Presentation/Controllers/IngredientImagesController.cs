using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.IngredientImages.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/ingredientImages")]
    [ApiController]
    public class IngredientImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public IngredientImagesController(IMediator mediator, IMapper mapper, ILogger<IngredientImagesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("ingredients/{ingredientId}")] // => ??
        public async Task<IActionResult> GetIngredientImageUrlByIgredientId(int ingredientId)
        {
            _logger.LogInformation(LogEvents.GetItem, "Getting ingredient image by ingredient id {id}", ingredientId);

            var query = new GetIngredientImageUrlByIngredientId { IngredientId = ingredientId };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning(LogEvents.GetItemNotFound,
                    "Ingredient image with ingredient id {id} not found", ingredientId);

                return NotFound();
            }

            return Ok(result);
        }
    }
}
