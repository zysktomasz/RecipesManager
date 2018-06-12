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

        public void CreateRecipe(RecipeWithIngredientsDto recipeWithIngredientsDTO)
        {
            // mapping
            var recipeToCreate = new Recipe
            {
                Title = recipeWithIngredientsDTO.Title,
                Description = recipeWithIngredientsDTO.Description,
                Ingredients = recipeWithIngredientsDTO.Ingredients.Select(i => new Ingredient
                {
                    Id = i.Id,
                    Name = i.Name,
                    Unit = i.Unit,
                    Value = i.Value
                }).ToList()
            };

            _unitOfWork.Recipes
                       .Create(recipeToCreate);
            _unitOfWork.Complete();

            // map just created entities' Ids to recipeWithIngredientsDto input DTOs
            // to show them (Ids) in a response
            recipeWithIngredientsDTO.Id = recipeToCreate.Id;
            recipeWithIngredientsDTO.Ingredients = recipeToCreate.Ingredients
                                                                 .Select(i => new IngredientDto
                                                                 {
                                                                     Id = i.Id,
                                                                     Name = i.Name,
                                                                     Unit = i.Unit,
                                                                     Value = i.Value
                                                                 });
        }

        public void Delete(int recipeId)
        {
            var recipeToDelete = _unitOfWork.Recipes
                                    .GetById(recipeId);

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
