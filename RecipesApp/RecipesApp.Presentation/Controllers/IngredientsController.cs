using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Application.ApproveIngredientFeature.Commands;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Presentation.Dtos.IngredientDtos;

namespace RecipesApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IngredientsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] IngredientPutPostDto ingredient)
        {
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
            var query = new GetIngredientById { IngredientId = ingredientId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<IngredientGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{ingredientName}")]
        public async Task<IActionResult> GetIngredientByName(string ingredientName)
        {
            var query = new GetIngredientByName { IngredientName = ingredientName };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<IngredientGetDto>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("allIngredients")]
        public async Task<IActionResult> GetAllIngredients()
        {
            var query = new GetAllIngredients();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<IngredientGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        //[Route("approvedIngredients")] // => with/without route?
        public async Task<IActionResult> GetApprovedIngredients()
        {
            var query = new GetIngredientsByApprovedStatus { ApprovedStatus = true };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<IngredientGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("unapprovedIngredients")]
        public async Task<IActionResult> GetUnapprovedIngredients()
        {
            var query = new GetIngredientsByApprovedStatus { ApprovedStatus = false };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<IngredientGetDto>>(result);

            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{ingredientId}")]
        public async Task<IActionResult> UpdateIngredient(int ingredientId, [FromBody] IngredientPutPostDto ingredient)
        {
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
                return NotFound();

            return NoContent();
        }

        [HttpPut]
        [Route("unapprovedIngredients/{ingredientId}")]
        public async Task<IActionResult> ApproveIngredient(int ingredientId)
        {
            var command = new ApproveIngredient { IngredientId = ingredientId };

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [Route("{ingredientId}")]
        public async Task<IActionResult> DeleteIngredient(int ingredientId)
        {
            var command = new DeleteIngredient { IngredientId = ingredientId };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();
        }
    }
}
