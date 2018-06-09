using RM.Data.Models;
using RM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RM.Repo.Interfaces;
using RM.Repo;

namespace RM.Service.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _unitOfWork.Recipes.GetAll();
        }

        public void CreateRecipe(Recipe recipe)
        {
            _unitOfWork.Recipes.Create(recipe);
        }

        public void Delete(Recipe recipe)
        {
            _unitOfWork.Recipes.Delete(recipe);
        }

        public Recipe GetRecipeById(int id)
        {
            return GetAllRecipes().SingleOrDefault(rec => rec.Id == id);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _unitOfWork.Recipes.Update(recipe);
        }
    }
}
