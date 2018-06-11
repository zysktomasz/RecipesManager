using RM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Repo.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        IEnumerable<Recipe> GetAllRecipesWithIngredients();
        Recipe GetById(int recipeId);
    }
}
