using RM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Repo.Interfaces
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Ingredient GetById(int ingredientId);
    }
}
