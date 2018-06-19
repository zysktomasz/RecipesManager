using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Data.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } // np "250g macaroni"
        public float Value { get; set; }
        public string Unit { get; set; }

        public int? RecipeId { get; set; }
        public Recipe Recipe { get; set; } // recipe that this Ingredient corresponds to
    }
}
