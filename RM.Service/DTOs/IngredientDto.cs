using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Service.DTOs
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }
}
