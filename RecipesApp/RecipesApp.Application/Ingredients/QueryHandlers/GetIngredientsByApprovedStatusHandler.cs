using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetIngredientsByApprovedStatusHandler : IRequestHandler<GetIngredientsByApprovedStatus, List<Ingredient>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetIngredientsByApprovedStatusHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Ingredient>> Handle(GetIngredientsByApprovedStatus request, CancellationToken cancellationToken)
        {
            var ingredients = (await _unitOfWork
                .IngredientRepository
                .GetByApprovedStatus(request.PaginationParameters, request.ApprovedStatus))
                .ToList();

            if (ingredients.Count != 0)
            {
                return ingredients;
            }

            return null;
        }
    }
}
