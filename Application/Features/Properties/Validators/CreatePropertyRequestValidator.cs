using Application.Features.Properties.Commands;
using FluentValidation;

namespace Application.Features.Properties.Validators
{
    public class CreatePropertyRequestValidator : AbstractValidator<CreatePropertyRequest>
    {
        public CreatePropertyRequestValidator()
        {
            RuleFor(request => request.NewPropertyDto)
                .SetValidator(new NewPropertyValidator());
        }
    }
}
