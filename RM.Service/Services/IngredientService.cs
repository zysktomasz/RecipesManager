using RM.Data.Models;
using RM.Repo;
using RM.Service.DTOs;
using RM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Service.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IngredientDto GetIngredientById(int ingredientId)
        {
            var ingredient = _unitOfWork.Ingredients
                                        .GetById(ingredientId);

            if (ingredient == null)
                return null;

            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Value = ingredient.Value,
                Unit = ingredient.Unit
            };
        }

        public void UpdateIngredient(int ingredientId, IngredientDto modifiedIngredient)
        {
            var oldIngredient = _unitOfWork.Ingredients.GetById(ingredientId);

            oldIngredient.Name = modifiedIngredient.Name;
            oldIngredient.Value = modifiedIngredient.Value;
            oldIngredient.Unit = modifiedIngredient.Unit;


            _unitOfWork.Ingredients
                       .Update(oldIngredient);
            _unitOfWork.Complete();
        }
        
    }
}
