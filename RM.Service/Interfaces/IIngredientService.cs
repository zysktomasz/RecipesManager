using RM.Repo.Interfaces;
using RM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Service.Interfaces
{
    public interface IIngredientService
    {
        IngredientDto GetIngredientById(int ingredientId);

        void UpdateIngredient(int ingredientId, IngredientDto modifiedRecipe);
    }
}
