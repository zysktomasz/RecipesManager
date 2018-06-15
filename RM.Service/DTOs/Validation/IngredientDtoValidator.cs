using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RM.Service.DTOs.Validation
{
    public class IngredientDtoValidator : AbstractValidator<IngredientDto>
    {
        public IngredientDtoValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(i => i.Value)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(i => i.Unit)
                .NotEmpty()
                .MaximumLength(30);
        }
    }
}
