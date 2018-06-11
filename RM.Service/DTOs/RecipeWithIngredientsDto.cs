using RM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Service.DTOs
{
    public class RecipeWithIngredientsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }

        public RecipeWithIngredientsDto()
        {
            Ingredients = new List<IngredientDto>();
        }
    }
}
