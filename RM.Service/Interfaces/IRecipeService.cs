using RM.Data.Models;
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
        RecipeDto GetRecipeById(int id);

        void CreateRecipe(RecipeWithIngredientsDto recipeWithIngredientsDTO);
        void UpdateRecipe(int recipeId,RecipeDto modifiedRecipe);
        void Delete(int recipeId);
    }
}
