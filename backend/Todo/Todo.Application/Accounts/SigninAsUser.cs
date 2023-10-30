using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Todo.Application.Abstractions.Handlers;
using Todo.Application.Abstractions.Requests;
using Todo.Application.Helpers;
using Todo.Application.ResultPattern;
using Todo.Application.Settings;
using Todo.DataAccess.Context;

namespace Todo.Application.Accounts;

public record SigninAsUser(string Email, string Password) : IApplicationRequest<string>;

public class SigninAsUserHandler : IApplicationHandler<SigninAsUser, string>
{
    private readonly TodoDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtSettings _jwtSettings;

    public SigninAsUserHandler(TodoDbContext context, UserManager<IdentityUser> identityUser, IOptions<JwtSettings> options)
    {
        _context = context;
        _userManager = identityUser;
        _jwtSettings = options.Value;
    }
    
    public async Task<HandlerResult<string>> Handle(SigninAsUser request, CancellationToken cancellationToken)
    {
        var existingIdentity = await _userManager.FindByEmailAsync(request.Email);
        if (existingIdentity is null)
        {
            return HandlerResultFailureHelper.NotFoundFailure<string>(FailureMessages.EmailNotFound);
        }
        
        var passwordIsValid = await _userManager.CheckPasswordAsync(existingIdentity, request.Password);
        if (!passwordIsValid)
        {
            return HandlerResultFailureHelper.IdentityFailure<string>(FailureMessages.PasswordIncorrect);
        }

        var userAccount = _context.Accounts
            .SingleOrDefault(account => account.IdentityId == Guid.Parse(existingIdentity.Id));
        
        if (userAccount is null)
        {
            return HandlerResultFailureHelper.NotFoundFailure<string>(FailureMessages.AccountNotFound);
        }

        var tokenCreator = new JwtHelper(_jwtSettings);
        var token = tokenCreator.GenerateAuthenticationToken(existingIdentity, userAccount);
        return HandlerResult<string>.Success(token);
    }
}