using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Data.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Descripton { get; set; } // np "250g macaroni"
        public Recipe Recipe { get; set; } // recipe that this Ingredient corresponds to
    }
}
