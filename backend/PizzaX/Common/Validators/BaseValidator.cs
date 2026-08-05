using FluentValidation;
using PizzaX.Common.DTOs;

namespace PizzaX.Common.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : BaseDto
    {
        protected BaseValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
