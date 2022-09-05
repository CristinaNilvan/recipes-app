using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using RecipesApp.Domain.Enums;
using RecipesApp.Presentation.Dtos.IngredientDtos;
using System.Net;
using System.Text;

namespace RecipesApp.IntegrationTests
{
    public class IngredientsControllerTests : IDisposable
    {
        private static WebApplicationFactory<Program> _factory;

        public IngredientsControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Create_Ingredient_ShouldReturnCreatedResponse()
        {
            var ingredientPutPostDto = new IngredientPutPostDto
            {
                Name = "New ing",
                Category = IngredientCategory.Meat,
                Calories = 50,
                Fats = 50,
                Carbs = 50,
                Proteins = 50,
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/ingredients",
                new StringContent(JsonConvert.SerializeObject(ingredientPutPostDto), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Get_Ingredient_By_Id_ShouldReturnFoundIngredient()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/ingredients/1");

            var result = await response.Content.ReadAsStringAsync();
            var ingredient = JsonConvert.DeserializeObject<IngredientGetDto>(result);

            Assert.Equal("Ing1", ingredient.Name);
            Assert.Equal(IngredientCategory.Meat, ingredient.Category);
            Assert.Equal(50, ingredient.Calories);
            Assert.Equal(50, ingredient.Fats);
            Assert.Equal(50, ingredient.Carbs);
            Assert.Equal(50, ingredient.Proteins);
            Assert.Null(ingredient.IngredientImage);
        }

        [Fact]
        public async Task Delete_Ingredient_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/ingredients/5");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

/*        [Fact]
        public async Task Update_Ingredient_ShouldReturnNoContentResponse()
        {
            var ingredientPutPostDto = new IngredientPutPostDto
            {
                Name = "Updated",
                Category = IngredientCategory.Meat,
                Calories = 50,
                Fats = 50,
                Carbs = 50,
                Proteins = 50,
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/ingredients/2",
                new StringContent(JsonConvert.SerializeObject(ingredientPutPostDto), Encoding.UTF8, "application/json"));

            var x = 3;

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }*/

        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}