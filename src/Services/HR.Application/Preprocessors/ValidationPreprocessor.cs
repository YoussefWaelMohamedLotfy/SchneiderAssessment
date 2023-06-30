using FluentValidation;

using HR.Application.Extensions;

using MediatR.Pipeline;

namespace HR.Application.Preprocessors;

internal sealed class ValidationPreprocessor<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : IValidatableRequest
{
    private readonly IValidator<TRequest> _validator;

    public ValidationPreprocessor(IValidator<TRequest> validator)
        => _validator = validator;

    public async Task Process(TRequest request, CancellationToken cancellationToken)
        => await _validator.ValidateAndThrowAsync(request, cancellationToken);
}
