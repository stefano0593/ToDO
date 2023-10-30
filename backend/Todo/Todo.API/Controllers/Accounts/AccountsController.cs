using Microsoft.AspNetCore.Mvc;
using Todo.API.API.Controllers;
using Todo.API.Controllers.Accounts.Contracts;
using Todo.API.Controllers.Accounts.Contracts.Requests;
using Todo.API.Controllers.Accounts.Contracts.Responses;
using Todo.Application.Accounts;

namespace Todo.API.Controllers.Accounts;

public class AccountsController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> SignupAsUser([FromBody] UserSignupRequest request)
    {
        var userSignupCommand = new SignupAsUserCommand(
            FirstName: request.FirstName,
            LastName: request.LastName,
            Email: request.Email,
            Password: request.Password,
            PictureUrl: request.PictureUrl);

        var commandResult = await Mediator.Send(userSignupCommand);
        return commandResult.IsSuccess && commandResult.Payload is not null? 
            Ok(new AccountServerResponse(commandResult.Payload)) : 
            HandleApiErrorResponse(commandResult.FailureReason);
    }
    
    [HttpPost]
    [Route("signin")]
    public async Task<IActionResult> SignInAsUser([FromBody] LoginRequest request)
    {
        var userSignupCommand = new SigninAsUser(
            Email: request.Email,
            Password: request.Password);

        var commandResult = await Mediator.Send(userSignupCommand);
        return commandResult.IsSuccess && commandResult.Payload is not null? 
            Ok(commandResult.Payload) : 
            HandleApiErrorResponse(commandResult.FailureReason);
    }
}