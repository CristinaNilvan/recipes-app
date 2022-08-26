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
            return await _unitOfWork.IngredientRepository.GetByApprovedStatus(request.ApprovedStatus);
        }
    }
}
