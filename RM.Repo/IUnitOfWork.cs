using RM.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Repo
{
    public interface IUnitOfWork
    {
        IRecipeRepository Recipes { get; }
        IIngredientRepository Ingredients { get; }

        void Complete();
    }
}
