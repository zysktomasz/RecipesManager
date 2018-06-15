using FluentValidation;

namespace RM.Service.DTOs.Validation
{
    public class RecipeWithIngredientsDtoValidator : AbstractValidator<RecipeWithIngredientsDto>
    {
        public RecipeWithIngredientsDtoValidator()
        {
            RuleFor(recipe => recipe.Title)
                .NotEmpty();
            RuleFor(recipe => recipe.Description)
                .NotEmpty();
        }
    }
}
