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
        IEnumerable<Recipe> GetAllRecipes();
        RecipeWithIngredientsDto GetRecipeById(int id);

        void CreateRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void Delete(Recipe recipe);
    }
}
