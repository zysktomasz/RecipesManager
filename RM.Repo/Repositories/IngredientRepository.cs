﻿using Microsoft.EntityFrameworkCore;
using RM.Data.Models;
using RM.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RM.Repo.Repositories
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        private ApplicationContext context { get; }

        public IngredientRepository(DbContext context) 
            : base(context as ApplicationContext)
        {
        }

        public Ingredient GetById(int ingredientId)
        {
            var ingredient = _context.Ingredients
                                     .AsNoTracking()
                                     .SingleOrDefault(i => i.Id == ingredientId);

            return ingredient;
        }
    }
}
