using FluentValidation;
using Todo.Domain.Accounts.Models;
using Todo.Domain.Shared.Validators;

namespace Todo.Domain.Accounts.Validators;

public class AccountValidator : DomainAbstractValidator<Account>
{
    public AccountValidator()
    {
        RuleFor(account => account.AccountId)
            .NotEmpty()
                .WithMessage(RuleFailureMessages.PropertyRequired);

        RuleFor(account => account.IdentityId)
            .NotEmpty()
                .WithMessage(RuleFailureMessages.PropertyRequired);

        RuleFor(account => account.FirstName)
            .NotEmpty()
                .WithMessage(RuleFailureMessages.PropertyRequired)
            .MaximumLength(RuleConstants.AccountNameMaxLength)
                .WithMessage(RuleFailureMessages.PropertyMaxLengthExceeded);

        RuleFor(account => account.LastName)
            .NotEmpty()
                .WithMessage(RuleFailureMessages.PropertyRequired)
            .MaximumLength(RuleConstants.AccountNameMaxLength)
                .WithMessage(RuleFailureMessages.PropertyMaxLengthExceeded);
    }
}