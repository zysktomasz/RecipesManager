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
            try
            {
                var recipe = _recipeService.GetRecipeWithIngredientsById(id);

                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        // POST: api/Recipes
        [HttpPost]
        public IActionResult Post([FromBody] RecipeWithIngredientsDto recipe)
        {
            try
            {
                if (recipe == null)
                {
                    return BadRequest("Recipe object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                _recipeService.CreateRecipe(recipe);

                return CreatedAtRoute("RecipeById", new { id = recipe.Id }, recipe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Recipes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RecipeDto modifiedRecipe)
        {
            try
            {
                _recipeService.UpdateRecipe(id, modifiedRecipe);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}\nInternal server error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _recipeService.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }

        }
    }
}
