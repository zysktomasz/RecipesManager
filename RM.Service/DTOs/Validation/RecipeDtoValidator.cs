using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace RM.Service.DTOs.Validation
{
    public class RecipeDtoValidator : AbstractValidator<RecipeDto>
    {
        public RecipeDtoValidator()
        {
            RuleFor(recipe => recipe.Title)
                .NotEmpty();
            RuleFor(recipe => recipe.Description)
                    .NotEmpty();
        }
    }
}
