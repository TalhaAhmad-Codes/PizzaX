using FluentValidation;
using PizzaX.Common.DTOs;
using PizzaX.Common.Utilities.Length;

namespace PizzaX.Common.Validators
{
    public abstract class BaseFilterValidator<T> : AbstractValidator<T> where T : BaseFilterDto
    {
        protected BaseFilterValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(MinLength.PageSize, MaxLength.PageSize).WithMessage($"Page size must be between {MinLength.PageSize} and {MaxLength.PageSize}.");
        }
    }
}
