using Application.Features.Properties.Commands;
using FluentValidation;

namespace Application.Features.Properties.Validators
{
    public class UpdatePropertyRequestValidator : AbstractValidator<UpdatePropertyRequest>
    {
        public UpdatePropertyRequestValidator()
        {
            RuleFor(request => request.UpdatePropertyDto)
                .SetValidator(new UpdatePropertyValidator());
        }
    }
}
