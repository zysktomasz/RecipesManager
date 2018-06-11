using RM.Data.Models;
using RM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RM.Repo.Interfaces;
using RM.Repo;
using RM.Service.DTOs;

namespace RM.Service.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RecipeDto> GetAllRecipes()
        {
            return _unitOfWork.Recipes
                              .GetAll()
                              .Select(r => new RecipeDto
                              {
                                  Id = r.Id,
                                  Title = r.Title,
                                  Description = r.Description
                              });
        }

        public void CreateRecipe(Recipe recipe)
        {
            _unitOfWork.Recipes
                       .Create(recipe);
        }

        public void Delete(RecipeDto recipe)
        {
            var recipeToDelete = new Recipe
            {
                Id = recipe.Id
            };

            _unitOfWork.Recipes
                       .Delete(recipeToDelete);

            _unitOfWork.Complete();
        }

        public RecipeWithIngredientsDto GetRecipeWithIngredientsById(int id)
        {

            var recipe = _unitOfWork.Recipes
                                    .GetById(id);

            return new RecipeWithIngredientsDto
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients.Select(i => new IngredientDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Unit = i.Unit,
                    Value = i.Value
                })
            };
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _unitOfWork.Recipes
                       .Update(recipe);
        }

        public IEnumerable<RecipeWithIngredientsDto> GetAllRecipesWithIngredients()
        {
            return _unitOfWork.Recipes.GetAllRecipesWithIngredients()
                        .Select(r => new RecipeWithIngredientsDto
                        {
                            Id = r.Id,
                            Title = r.Title,
                            Description = r.Description,
                            Ingredients = r.Ingredients.Select(i => new IngredientDto
                            {
                                Id = i.Id,
                                Name = i.Name,
                                Unit = i.Unit,
                                Value = i.Value
                            })
                        }).AsEnumerable();
        }
    }
}
