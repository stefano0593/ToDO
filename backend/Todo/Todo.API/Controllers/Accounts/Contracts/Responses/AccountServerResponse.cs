using Todo.Domain.Accounts.Models;

namespace Todo.API.Controllers.Accounts.Contracts.Responses;

public class AccountServerResponse
{
    public AccountServerResponse(Account account)
    {
        AccountId = account.AccountId.Value;
        IdentityId = account.IdentityId;
        FirstName = account.FirstName;
        LastName = account.LastName;
    }
    public Guid AccountId { get; private set; }
    public Guid IdentityId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}