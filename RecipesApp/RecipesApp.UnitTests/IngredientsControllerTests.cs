using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Enums;
using RecipesApp.Domain.Models;
using RecipesApp.Presentation.Controllers;
using RecipesApp.Presentation.Dtos.IngredientDtos;
using System.Net;

namespace RecipesApp.UnitTests
{
    public class IngredientsControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new();
        private readonly Mock<IMapper> _mockMapper = new();
        private Mock<ILogger<IngredientsController>> _mockLogger = new ();

        [Fact]
        public async Task Create_Ingredient_ShouldReturnNoContentStatusCode()
        {
            // arrange
            _mockMediator
                .Setup(mediator => mediator.Send(It.IsAny<CreateIngredient>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Ingredient
                {
                    Id = 2,
                    Name = "Ing2",
                    Category = IngredientCategory.Dairy,
                    Calories = 187.75f,
                    Fats = 137.41f,
                    Carbs = 229.27f,
                    Proteins = 186.51f,
                    Approved = false,
                });

            _mockMapper
                .Setup(mapper => mapper.Map<IngredientGetDto>(It.IsAny<Ingredient>()))
                .Returns(new IngredientGetDto
                {
                    Id = 2,
                    Name = "Ing2",
                    Category = IngredientCategory.Dairy,
                    Calories = 187.75f,
                    Fats = 137.41f,
                    Carbs = 229.27f,
                    Proteins = 186.51f,
                    IngredientImage = null,
                });

            var ingredientPutPostDto = new IngredientPutPostDto
            {
                Name = "Ing2",
                Category = IngredientCategory.Dairy,
                Calories = 187.75f,
                Fats = 137.41f,
                Carbs = 229.27f,
                Proteins = 186.51f,
            };

            var ingredientsController = new IngredientsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);

            // act
            var result = await ingredientsController.CreateIngredient(ingredientPutPostDto);

            // assert
            var okResult = result as CreatedAtActionResult;

            Assert.Equal((int)HttpStatusCode.Created, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_Ingredient_By_Id_ShouldReturnOkStatusCode()
        {
            // arrange
            _mockMediator
                .Setup(mediator => mediator.Send(It.IsAny<GetIngredientById>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Ingredient
                {
                    Id = 2,
                    Name = "Ing2",
                    Category = IngredientCategory.Dairy,
                    Calories = 187.75f,
                    Fats = 137.41f,
                    Carbs = 229.27f,
                    Proteins = 186.51f,
                    Approved = false,
                    IngredientImage = null,
                });

            var ingredientDto = new IngredientGetDto
            {
                Id = 2,
                Name = "Ing2",
                Category = IngredientCategory.Dairy,
                Calories = 187.75f,
                Fats = 137.41f,
                Carbs = 229.27f,
                Proteins = 186.51f,
                IngredientImage = null,
            };

            _mockMapper
                .Setup(mapper => mapper.Map<IngredientGetDto>(It.IsAny<Ingredient>()))
                .Returns(ingredientDto);

            var ingredientsController = new IngredientsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);

            // act
            var result = await ingredientsController.GetIngredientById(2);

            // assert
            var okResult = result as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Update_Ingredient_ShouldReturnNoContentStatusCode()
        {
            // arrange
            _mockMediator
                .Setup(mediator => mediator.Send(It.IsAny<UpdateIngredient>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Ingredient
                {
                    Id = 2,
                    Name = "Ing2",
                    Category = IngredientCategory.Dairy,
                    Calories = 187.75f,
                    Fats = 137.41f,
                    Carbs = 229.27f,
                    Proteins = 186.51f,
                    Approved = false,
                });

            _mockMapper
                .Setup(mapper => mapper.Map<IngredientGetDto>(It.IsAny<Ingredient>()))
                .Returns(new IngredientGetDto
                {
                    Id = 2,
                    Name = "Ing2",
                    Category = IngredientCategory.Dairy,
                    Calories = 187.75f,
                    Fats = 137.41f,
                    Carbs = 229.27f,
                    Proteins = 186.51f,
                    IngredientImage = null,
                });

            var ingredientPutPostDto = new IngredientPutPostDto
            {
                Name = "Ing2",
                Category = IngredientCategory.Dairy,
                Calories = 187.75f,
                Fats = 137.41f,
                Carbs = 229.27f,
                Proteins = 186.51f,
            };

            var ingredientsController = new IngredientsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);

            // act
            var result = await ingredientsController.UpdateIngredient(2, ingredientPutPostDto);

            // assert
            var okResult = result as NoContentResult;

            Assert.Equal((int)HttpStatusCode.NoContent, okResult.StatusCode);
        }

        [Fact]
        public async Task Delete_Ingredient_ShouldReturnNoContentStatusCode()
        {
            // arrange
            _mockMediator
                .Setup(mediator => mediator.Send(It.IsAny<DeleteIngredient>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Ingredient
                {
                    Id = 2,
                    Name = "Ing2",
                    Category = IngredientCategory.Dairy,
                    Calories = 187.75f,
                    Fats = 137.41f,
                    Carbs = 229.27f,
                    Proteins = 186.51f,
                    Approved = false,
                    IngredientImage = null,
                });

            var ingredientDto = new IngredientGetDto
            {
                Id = 2,
                Name = "Ing2",
                Category = IngredientCategory.Dairy,
                Calories = 187.75f,
                Fats = 137.41f,
                Carbs = 229.27f,
                Proteins = 186.51f,
                IngredientImage = null,
            };

            _mockMapper
                .Setup(mapper => mapper.Map<IngredientGetDto>(It.IsAny<Ingredient>()))
                .Returns(ingredientDto);

            var ingredientsController = new IngredientsController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object);

            // act
            var result = await ingredientsController.DeleteIngredient(2);

            // assert
            var okResult = result as NoContentResult;

            Assert.Equal((int)HttpStatusCode.NoContent, okResult.StatusCode);
        }
    }
}