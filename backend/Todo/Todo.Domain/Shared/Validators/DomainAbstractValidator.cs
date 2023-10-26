using FluentValidation;
using Todo.Domain.Shared.ErrorHandling.Exceptions;

namespace Todo.Domain.Shared.Validators;

public abstract class DomainAbstractValidator<TEntity> : AbstractValidator<TEntity>
{
    public virtual async Task ValidateDomainModelAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var validationResult = await ValidateAsync(entity, cancellationToken);
        if (validationResult.IsValid) { return; }
        var errorMessage = validationResult.Errors.Single().ErrorMessage;
        throw new DomainModelValidationException(errorMessage);
    }
}