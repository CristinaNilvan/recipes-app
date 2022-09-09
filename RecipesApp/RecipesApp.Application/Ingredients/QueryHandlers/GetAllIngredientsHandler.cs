﻿using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetAllIngredientsHandler : IRequestHandler<GetAllIngredients, List<Ingredient>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllIngredientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Ingredient>> Handle(GetAllIngredients request, CancellationToken cancellationToken)
        {
            var ingredients = (await _unitOfWork
                .IngredientRepository
                .GetAll(request.PaginationParameters))
                .ToList();

            if (ingredients.Count != 0)
            {
                return ingredients;
            }

            return null;
        }
    }
}
