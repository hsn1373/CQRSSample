using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.PipelineBehaviours
{
    public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                List<string> errors = new();
                var validationResults = await Task
                    .WhenAll(
                        _validators
                            .Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures  = validationResults.SelectMany(r => r.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Any())
                    errors = failures.Select(x => x.ErrorMessage).ToList();

                throw new CustomValidationException(errors, "one or more validation failure(s) occured.");
            }
            return await next();
        }
    }
}
