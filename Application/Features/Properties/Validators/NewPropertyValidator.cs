using Application.Models;
using FluentValidation;

namespace Application.Features.Properties.Validators
{
    public class NewPropertyValidator : AbstractValidator<NewPropertyDto>
    {
        public NewPropertyValidator()
        {
            RuleFor(npd => npd.Name)
                .NotEmpty().WithMessage("Property name is required.")
                .MaximumLength(15).WithMessage("Name should not exceed 15 characters.")
                .MinimumLength(3).WithMessage("Name should be grater than 2 characters.");
        }
    }
}
