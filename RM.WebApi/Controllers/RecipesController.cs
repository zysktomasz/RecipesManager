﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RM.Data.Models;
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
                
                return StatusCode(500, $"{ex.Message} Internal server error");
            }
        }

        // GET: api/Recipes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Recipes
        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe)
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

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Recipes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
