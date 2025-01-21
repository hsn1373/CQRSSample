using Application.Models;
using FluentValidation;

namespace Application.Features.Properties.Validators
{
    public class UpdatePropertyValidator : AbstractValidator<UpdatePropertyDto>
    {
        public UpdatePropertyValidator()
        {
            RuleFor(upd =>  upd.Name)
                .NotEmpty().WithMessage("Property Name is required")
                .MaximumLength(15).WithMessage("Name should not exceed 15 characters.")
                .MinimumLength(3).WithMessage("Name should be grater than 2 characters.");
        }
    }
}
