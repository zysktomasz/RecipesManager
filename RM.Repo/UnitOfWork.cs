using System;
using System.Collections.Generic;
using System.Text;
using RM.Repo.Interfaces;
using RM.Repo.Repositories;

namespace RM.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IRecipeRepository Recipes { get; private set; }
        public IIngredientRepository Ingredients { get; private set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Recipes = new RecipeRepository(_context);
            Ingredients = new IngredientRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
