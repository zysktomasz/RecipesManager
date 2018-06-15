using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RM.Data.Models;
using RM.Service.DTOs;
using RM.Service.Interfaces;

namespace RM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/Recipes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var recipes = _recipeService.GetAllRecipesWithIngredients();

                return Ok(recipes);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"{ex.Message}");
            }
        }

        // GET: api/Recipes/5
        [HttpGet("{id}", Name = "RecipeById")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe = _recipeService.GetRecipeWithIngredientsById(id);

            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }

        // POST: api/Recipes
        [HttpPost]
        public IActionResult Post([FromBody] RecipeWithIngredientsDto recipe)
        {
            if (recipe == null)
            {
                return BadRequest("Recipe object is null");
            }

            try
            {
                _recipeService.CreateRecipe(recipe);

                return CreatedAtRoute("RecipeById", new { id = recipe.Id }, recipe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        // PUT: api/Recipes/5
        [HttpPut("{recipeId}")]
        public IActionResult Put(int recipeId, [FromBody] RecipeDto modifiedRecipe)
        {
            var recipeToUpdate = _recipeService.GetRecipeById(recipeId);

            if (recipeToUpdate == null)
                return NotFound();

            try
            {
                _recipeService.UpdateRecipe(recipeId, modifiedRecipe);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}\nInternal server error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{recipeId}")]
        public IActionResult Delete(int recipeId)
        {
            var recipeToDelete = _recipeService.GetRecipeById(recipeId);

            if (recipeToDelete == null)
                return NotFound();

            try
            {
                _recipeService.Delete(recipeId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }

        }
    }
}
