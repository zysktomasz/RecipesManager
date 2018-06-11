using Microsoft.EntityFrameworkCore;
using RM.Data.Models;
using RM.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RM.Repo.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private ApplicationContext context { get; }

        public RecipeRepository(DbContext context) // DbContext instead of concrete implementation to avoid DI
            : base(context as ApplicationContext)
        {
        }

        public IEnumerable<Recipe> GetAllRecipesWithIngredients()
        {
            return _context.Recipes
                           .Include(r => r.Ingredients)
                           .AsEnumerable();
        }

        public Recipe GetById(int recipeId)
        {
            var recipe = _context.Recipes
                                 .Include(r => r.Ingredients)
                                 .SingleOrDefault(r => r.Id == recipeId);

            if (recipe == null)
            {
                throw new ArgumentNullException("Entity Null!");
            }

            return recipe;
        }
    }
}
