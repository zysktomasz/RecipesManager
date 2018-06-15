using FluentValidation;

namespace RM.Service.DTOs.Validation
{
    public class RecipeWithIngredientsDtoValidator : AbstractValidator<RecipeWithIngredientsDto>
    {
        public RecipeWithIngredientsDtoValidator()
        {
            // Recipe properties validation
            RuleFor(recipe => recipe.Title)
                .NotEmpty();
            RuleFor(recipe => recipe.Description)
                .NotEmpty();

            // Recipe.Ingredients collection validation
            RuleFor(recipe => recipe.Ingredients)
                .SetCollectionValidator(new IngredientDtoValidator());
        }
    }
}
