using Todo.Domain.Accounts.Identifiers;
using Todo.Domain.Accounts.Validators;

namespace Todo.Domain.Accounts.Models;

public class Account
{
    private Account(string firstName, string lastName, string? pictureUrl, Guid identityId)
    {
        FirstName = firstName;
        LastName = lastName;
        PictureUrl = pictureUrl;
        IdentityId = identityId;
    }

    public AccountId AccountId { get; private set; } = new(Guid.NewGuid());
    public Guid IdentityId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? PictureUrl { get; private set; }
    public string? BlaBla { get; private set; }

    public static async Task<Account> CreateAccount(string firstName, string lastName, string? pictureUrl, Guid identityId,
        CancellationToken cancellationToken)
    {
        var accountValidator = new AccountValidator();
        var newAccount = new Account(firstName, lastName, pictureUrl, identityId);
        await accountValidator.ValidateDomainModelAsync(newAccount, cancellationToken);
        return newAccount;
    }
}