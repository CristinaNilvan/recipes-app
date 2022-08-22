using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetIngredientByNameHandler : IRequestHandler<GetIngredientByName, Ingredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetIngredientByNameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ingredient> Handle(GetIngredientByName request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.IngredientRepository.GetIngredientByName(request.IngredientName);
        }
    }
}
