using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetIngredientByIdHandler : IRequestHandler<GetIngredientById, Ingredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetIngredientByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ingredient> Handle(GetIngredientById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.IngredientRepository.GetById(request.IngredientId);
        }
    }
}