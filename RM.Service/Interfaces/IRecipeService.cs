using RM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Service.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);
        void CreateRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void Delete(Recipe recipe);
    }
}
