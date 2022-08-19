﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.QueryHandlers
{
    public class GetIngredientByIdHandler : IRequestHandler<GetIngredientById, Ingredient>
    {
        private readonly IIngredientRepository _repository;

        public GetIngredientByIdHandler(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ingredient> Handle(GetIngredientById request, CancellationToken cancellationToken)
        {
            return await _repository.GetIngredientById(request.IngredientId);
        }
    }
}