using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RM.Service.DTOs;
using RM.Service.Interfaces;

namespace RM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPut("{ingredientId}")]
        public IActionResult UpdateIngredient(int ingredientId, [FromBody] IngredientDto modifiedIngredient)
        {
            // TODO: find a way to avoid having to load ingredient twice
            var ingredientToUpdate = _ingredientService.GetIngredientById(ingredientId);

            if (ingredientToUpdate == null)
                return NotFound();

            _ingredientService.UpdateIngredient(ingredientId, modifiedIngredient);

            return NoContent();
        }
    }
}