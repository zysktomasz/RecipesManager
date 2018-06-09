using RM.Data.Models;
using RM.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Repo.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public ApplicationContext context
        {
            get { return context as ApplicationContext; }
        }

        public RecipeRepository(ApplicationContext context) 
            : base(context)
        {
        }
    }
}
