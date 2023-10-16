using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Abstractions.Handlers;
using Todo.Application.Abstractions.Requests;
using Todo.Application.ResultPattern;
using Todo.DataAccess.Context;
using Todo.Domain.Accounts.Models;
using Todo.Domain.Shared.ErrorHandling.Exceptions;

namespace Todo.Application.Accounts;

public record SignupAsUserCommand(string FirstName, string LastName, string Email, string Password, string? PictureUrl)
    : IApplicationRequest<Account>;

public class SignupAsUserHandler : IApplicationHandler<SignupAsUserCommand, Account>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly TodoDbContext _context;

    public SignupAsUserHandler(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager, TodoDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    public async Task<HandlerResult<Account>> Handle(SignupAsUserCommand request, CancellationToken cancellationToken)
    {
        var userAlreadySignedUpWithEmail =
            await _userManager.Users.AnyAsync(user => user.Email == request.Email, cancellationToken);

        if (userAlreadySignedUpWithEmail)
            return HandlerResultFailureHelper.IdentityFailure<Account>(FailureMessages.EmailAlreadyRegistered);

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var newIdentity = new IdentityUser { Email = request.Email, UserName = request.Email };
            var createdIdentity = await _userManager.CreateAsync(newIdentity, request.Password);
            var wasIdentityCreatedSuccessfully = createdIdentity.Succeeded;

            if (!wasIdentityCreatedSuccessfully)
            {
                await transaction.RollbackAsync(cancellationToken);
                return HandlerResultFailureHelper.TransactionFailure<Account>(FailureMessages.IdentityCannotBeCreated);
            }

            try
            {
                var newAccount = await Account.CreateAccount(
                    firstName: request.FirstName,
                    lastName: request.LastName,
                    identityId: Guid.Parse(newIdentity.Id),
                    pictureUrl: request.PictureUrl,
                    cancellationToken: cancellationToken);

                var createdUserAccount = await _context.Accounts.AddAsync(newAccount, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return HandlerResult<Account>.Success(createdUserAccount.Entity);
            }
            catch (DomainModelValidationException exception)
            {
                return HandlerResultFailureHelper.DomainValidationFailure<Account>(exception.Message);
            }
        }
        catch (Exception)
        {
            return HandlerResultFailureHelper.TransactionFailure<Account>(FailureMessages.IdentityCannotBeCreated);
        }
    }
}