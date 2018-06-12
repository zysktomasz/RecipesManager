﻿using RM.Data.Models;
using RM.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Service.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<RecipeWithIngredientsDto> GetAllRecipesWithIngredients();
        IEnumerable<RecipeDto> GetAllRecipes();
        RecipeWithIngredientsDto GetRecipeWithIngredientsById(int id);

        void CreateRecipe(RecipeWithIngredientsDto recipeWithIngredientsDTO);
        void UpdateRecipe(Recipe recipe);
        void Delete(int recipeId);
    }
}
